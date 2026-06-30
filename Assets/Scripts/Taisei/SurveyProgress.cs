using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SurveyProgress : MonoBehaviour
{
    [SerializeField]
    List<Phase> phases;
    [SerializeField]
    AriaMove ariaMove;
    int nowPhase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        nowPhase = PlayerPrefs.GetInt("Progress", 0);
        //テスト用
        nowPhase = 1;

        PhaseLoad();
    }

    public void ProgressCheck()
    {
        Debug.Log("procheck" + nowPhase);
        foreach (Item item in phases[nowPhase].NeedItems)
        {
            int score = PlayerPrefs.GetInt(item.Identifier, 0);
            if (score == 0) //条件を満たしていない場合
            {
                Debug.Log(item.Identifier);
                return;
            }
        }
        foreach (Ivent ivent in phases[nowPhase].NeedIvents)
        {
            int score = PlayerPrefs.GetInt("A" + ivent.Identifier, 0);
            if (score == 0) //条件を満たしていない場合
            {
                Debug.Log("A" + ivent.Identifier);
                return;
            }
        }
        //両条件をクリアしている場合
        Debug.Log("correct");
        NextPhase();
    }
    public void NextPhase()
    {
        nowPhase++;
        SaveData.SaveProgress(nowPhase);
        PhaseLoad();
    }
    public void PhaseLoad()
    {
        Debug.Log("now" + nowPhase);
        if(nowPhase == 0)
        {
           //チュートリアルを実施
           //ariaMove.ChangeAria(6);
        }
        if (nowPhase == 1)
        {
            ariaMove.IsSecondPhase = false;
            ariaMove.ChangeAria(0);
        }
        if (nowPhase == 2)
        {
            ariaMove.IsSecondPhase = true;
            ariaMove.ChangeAria(0);
        }


    }
}
