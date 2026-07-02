using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JudgeProgress : MonoBehaviour
{

    [SerializeField]
    List<Debate> debateList;

    private int nowProgress;

    [SerializeField]
    GameObject[] buttons;

    private const int JUDGEPHASE = 5;

    [SerializeField]
    Dialog dialog;
    [SerializeField]
    private string[] contexts;
    [SerializeField]
    private ItemUI item;
    [SerializeField]
    private GameObject Text;

    private bool isAnswered = false;
    private bool isPopup = false;
    private bool isEnd = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DebateStart();
    }
    private void Update()
    {
        if (isAnswered && dialog.IsEnd)
        {
            DebateStart();
            isAnswered = false;
        }
        if (isPopup && dialog.IsEnd)
        {
            ButtonPopup();
            isPopup = false;
        }
        if (isEnd && dialog.IsEnd)
        {
            //エンドロール
            SceneManager.LoadScene("EndRollScene");
            isEnd = false;
        }
    }
    public void DebateStart() //privateからpublicに変更しました。
    {
        if(nowProgress >= debateList.Count)
        {
            dialog.TextListSet(contexts, "");
            isEnd = true;
            return;
        }
        //相手の供述を表示
        dialog.TextSet(debateList[nowProgress].Statement, debateList[nowProgress].Speaker);

        //actionに応じて表示
        if (debateList[nowProgress].ActionType == DebateAction.choice)
        {//ボタンの表示
            isPopup = true;
        }else
        {
            foreach (GameObject button in buttons)
            {
                button.SetActive(false);
           
            }
            Text.SetActive(true);
        }
    }
    private void ButtonPopup()
    {
        for (int count = 0; count < buttons.Length; count++)
        {
            buttons[count].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                = debateList[nowProgress].ChoiceText[count];

            buttons[count].SetActive(true);
        }
    }

    public void Choise(int index)
    {
        if (debateList[nowProgress].ActionType != DebateAction.choice)
            return;

        if (debateList[nowProgress].AnswerChoice == index)
        {// 正解なら
            //アニメーションとか入れるかも
            dialog.TextSet(debateList[nowProgress].AnswerText,"あなた");
            NextDebate();
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
    

        if (debateList[nowProgress].ActionType != DebateAction.selectitem)
            return;

        if (debateList[nowProgress].AnswerItem == item.Item)
        {// 正解なら
            //アニメーションとか入れるかも
            dialog.TextSet(debateList[nowProgress].AnswerText, "あなた");
            NextDebate();
        }
        else
        {
            if(dialog != null)
            {
                dialog.SetFailureText("私はこの選択で正しいのか……？");
            }

            // 元の質問に戻す関数
            DebateStart();
        }
    }
    public void NextDebate()
    {
        nowProgress++;
        isAnswered = true;
    }
}
