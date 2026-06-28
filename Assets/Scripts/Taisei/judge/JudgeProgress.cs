using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JudgeProgress : MonoBehaviour
{
    [SerializeField]
    private Dialog mydialog;

    [SerializeField]
    List<Debate> debateList;

    private int nowProgress;

    [SerializeField]
    GameObject[] buttons;

    private const int JUDGEPHASE = 5;

    [SerializeField]
    Dialog dialog;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowProgress = PlayerPrefs.GetInt("Progress", JUDGEPHASE) - JUDGEPHASE;
        DebateStart();
    }
    public void DebateStart() //privateからpublicに変更しました。
    {
        //相手の供述を表示
        dialog.TextSet(debateList[nowProgress].Statement, debateList[nowProgress].Speaker);

        //actionに応じて表示
        if (debateList[nowProgress].ActionType == DebateAction.choice)
        {//ボタンの表示
            for(int count= 0; count < buttons.Length;count++)
            {
                buttons[count].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text
                    = debateList[nowProgress].ChoiceText[count];

                buttons[count].SetActive(true);
            }
        }
    }
    public void Choise(int index)
    {
        if (debateList[nowProgress].ActionType != DebateAction.choice)
            return;

        if (debateList[nowProgress].AnswerChoice == index)
        {// 正解なら
            //アニメーションとか入れるかも
            NextDebate();
        }
        else
        {
            //失敗したときダイアログスクリプトに処理を飛ばす
            if (mydialog != null)
            {
                mydialog.SetFailureText("私はこの選択で正しいのか……？");
            }

            // 元の質問に戻す関数
            DebateStart();
        }
    }
    public void ShowItem(Item item)
    {
    
        if (debateList[nowProgress].ActionType != DebateAction.selectitem)
            return;

        if (debateList[nowProgress].AnswerItem == item)
        {// 正解なら
            //アニメーションとか入れるかも
            NextDebate();
        }
        else
        {
            //失敗
        }
    }
    public void NextDebate()
    {
        nowProgress++;
        DebateStart();
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }

    }
}
