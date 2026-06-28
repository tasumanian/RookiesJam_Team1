using System.Collections.Generic;
using UnityEngine;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowProgress = PlayerPrefs.GetInt("Progress", JUDGEPHASE) - JUDGEPHASE;
    }
    private void DebateStart()
    {
        //相手の供述を表示
        dialog.TextSet(debateList[nowProgress].Statement);
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
