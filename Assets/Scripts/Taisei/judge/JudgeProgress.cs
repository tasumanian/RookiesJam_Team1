using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JudgeProgress : MonoBehaviour
{

    [SerializeField]
    List<Debate> debateList;
    //討論の情報のリスト

    private int nowProgress;
    //現在のdebateListのindex

    [SerializeField]
    GameObject[] buttons;
    //4択の選択肢

    [SerializeField]
    Dialog dialog;

    [SerializeField]
    private string[] contexts;
    //討論終了後のテキスト内容

    [SerializeField]
    private ItemUI item;
    //提示するアイテムのUI

    [SerializeField]
    private GameObject Text;
    //上の文字

    private JudgeState State = JudgeState.NotReady;
    //フラグ管理をenum化
    private enum JudgeState
    {
        NotReady,
        Start,
        Answered,
        End
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowProgress = 0;
        DebateStart();
    }
    private void FixedUpdate()
    {
        if (!dialog.IsEnd || State == JudgeState.NotReady)
            return;

        if (State == JudgeState.Answered)
        {
            DebateStart();
            State = JudgeState.NotReady;
        }

        if (State == JudgeState.Start)
        {
            //actionに応じて表示
            if (debateList[nowProgress].ActionType == DebateAction.choice)
            { 
                //4択の場合、ボタンの表示
                ButtonPopup();
            }
            else //アイテム選択の場合、ボタンの非表示化
            {
                foreach (GameObject button in buttons)
                {
                    button.SetActive(false);
                }

                Text.SetActive(true);
                //上部テキストの表示
            }
            State = JudgeState.NotReady;
            //Stateを待機に
        }
        if (State == JudgeState.End)
        {
            //エンドロールへ
            SceneManager.LoadScene("EndRollScene");
            State = JudgeState.NotReady;
        }
    }
    public void DebateStart() //privateからpublicに変更しました。
    {
        if(nowProgress >= debateList.Count)
        {
            //討論が終了したら

            dialog.TextListSet(contexts, "");
            State = JudgeState.End;
            //終了時用のテキストを表示
            return;
        }
        
        dialog.TextSet(debateList[nowProgress].Statement, debateList[nowProgress].Speaker);
        //相手の供述を表示

        State = JudgeState.Start;
        //フラグを更新
    }
    private void ButtonPopup()//ボタンの表示
    {
        for (int count = 0; count < buttons.Length; count++)
        {
            buttons[count].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = debateList[nowProgress].ChoiceText[count];
            //ボタンのテキストを変更

            buttons[count].SetActive(true);
            //表示化
        }
    }

    public void Choise(int index) //選択したボタンをindexで管理
    {
        if (debateList[nowProgress].ActionType != DebateAction.choice)
            return;

        if (debateList[nowProgress].AnswerChoice == index)
        {// 正解なら

            //アニメーションとか入れるかも
            dialog.TextSet(debateList[nowProgress].AnswerText,"あなた");
            NextDebate();
            //テキストを表示して、次の討論へ

            //一応非表示化
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
            }
        }
        else
        {
            //失敗したときダイアログスクリプトに処理を飛ばす
            if (dialog != null)
            {
                dialog.SetFailureText("私はこの選択で正しいのか……？");
            }

            // 元の質問に戻す関数
            DebateStart();
        }
    }
    public void ShowItem()
    {

        if (nowProgress > debateList.Count-1)
            return;
        if (debateList[nowProgress].ActionType != DebateAction.selectitem)
            return;

        if (debateList[nowProgress].AnswerItem == item.Item)
        {// 正解なら
            //アニメーションとか入れるかも
            dialog.TextSet(debateList[nowProgress].AnswerText, "あなた");
            NextDebate();
            //テキストを表示して 、次の討論へ
        }
        else
        {
            if(dialog != null)
            {
                dialog.SetFailureText("私はこの選択で正しいのか……？");
            }

            // 元の質問に戻す
            DebateStart();
        }
    }
    public void NextDebate()
    {
        nowProgress++;
        State = JudgeState.Start;
        //次の討論へ
    }
}
