using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class SurveyProgress : MonoBehaviour
{
    [SerializeField]
    public List<Phase> phases;
    [SerializeField]
    AriaMove ariaMove;
    [SerializeField]
    private Dialog dialog;
    [SerializeField]
    private GameObject button;
    [SerializeField]
    private Narrative narrative;
    [SerializeField]
    private Sprite defaultsc;
    [SerializeField]
    private SoundManager soundManager;

    bool[] isProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        isProgress = new bool[phases.Count];
        for (int i = 0; i < isProgress.Length;i++)
        {
            int isproceed = PlayerPrefs.GetInt("P" + i.ToString(), 0);

            if(isproceed == 1)
            {
                isProgress[i] = true;
                if (isProgress[isProgress.Length - 1])
                {
                    dialog.TextSet(phases[isProgress.Length - 1].Context, "");
                    //裁判フェーズへ
                    button.SetActive(true);

                }
            }
            else
            {
                isProgress[i] = false;
            }
        }
        //テスト用
    }
    void Start()
    {
        int progress = PlayerPrefs.GetInt("P-1", 0);
        if(progress == 1)
        {
            narrative.SR.sprite = defaultsc;
            ariaMove.ChangeAria(0);
        }
        else
        {
            narrative.StartTutorial();
            soundManager.PlayBGM(1);
        }
    }
    public void ProgressCheck()
    {
        bool breakFlag = false;
        for (int i = 0; i < phases.Count; i++)
        {
            breakFlag = false;

            if (isProgress[i])
                continue;

            foreach (Item item in phases[i].NeedItems)
            {
                int score = PlayerPrefs.GetInt(item.Identifier, 0);
                if (score == 0) //条件を満たしていない場合
                {
                    Debug.Log(item.Identifier);
                    breakFlag = true;
                }
            }
            if(breakFlag)
                continue;

            foreach (Ivent ivent in phases[i].NeedIvents)
            {
                int score = PlayerPrefs.GetInt("A" + ivent.Identifier, 0);
                if (score == 0) //条件を満たしていない場合
                {
                    Debug.Log("A" + ivent.Identifier);
                    breakFlag = true;
                }
            }
            if (breakFlag)
                continue;

            //両条件をクリアしている場合
            Debug.Log("correct" + i);
            isProgress[i] = true;
            PasedPhase(i);

        }
    }
    public void PasedPhase(int index)
    {
        SaveData.SaveProgress(index);

        Debug.Log(ariaMove.gameObject);
        Debug.Log(phases[index].name);

        dialog.TextSet(phases[index].Context, "");
        if (isProgress[isProgress.Length -1])
        {
            //裁判フェーズへ
            button.SetActive(true);

        }
        ariaMove.passedPhase.Add(phases[index]);

        ariaMove.ChangeAria(-1);
    }
}
