using System;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditorInternal.ReorderableList;

public class SurveyProgress : MonoBehaviour
{
    [SerializeField]
    private List<Phase> phases; 
    //フェーズを格納するリスト、最後は必ずphase2(裁判フェーズ行き)にすること

    [SerializeField]
    AriaMove ariaMove;
    [SerializeField]
    private Dialog dialog;

    [SerializeField]
    private GameObject button;
    //裁判フェーズへ行くボタン

    [SerializeField]
    private Narrative narrative;
    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private Sprite defaultsc;
    //デフォルトの画像(執務室)

    bool[] isProgress;
    //進捗状況を確認する用

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        isProgress = new bool[phases.Count];
        //確認用の初期化

        for (int i = 0; i < isProgress.Length;i++)
        {
            int isproceed = PlayerPrefs.GetInt("P" + i.ToString(), 0);
            //進捗状況を取得

            if (isproceed == 1) //進捗状況がある場合
            {
                isProgress[i] = true;

                if (isProgress[isProgress.Length - 1])
                {//最後のフェーズをクリアした場合

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
    }
    void Start()
    {
        int progress = PlayerPrefs.GetInt("P-1", 0);
        //チュートリアルがプレイ済みか

        if(progress == 1) //プレイ済みなら
        {
            narrative.SR.sprite = defaultsc;
            //ゲーム画面をデフォルトに
            ariaMove.ChangeAria(0);
            //執務室に移行
            soundManager.PlayBGM(1);
        }
        else
        {
            //チュートリアル開始
            narrative.StartTutorial();
        }
    }
    public void ProgressCheck()
    {
        bool breakFlag = false;
        //ループ解除用

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
                    break;
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
                    break;
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
    public void PasedPhase(int index) //進捗状況を更新
    {
        SaveData.SaveProgress(index);
        //進捗状況を保存

        Debug.Log(ariaMove.gameObject);
        Debug.Log(phases[index].name);

        dialog.TextSet(phases[index].Context, "");
        //テキストを表示

        if (isProgress[isProgress.Length -1])
        { //最後のフェーズをクリアした場合
            //裁判フェーズへ
            button.SetActive(true);

        }
        ariaMove.passedPhase.Add(phases[index]);

        ariaMove.ChangeAria(-1);
    }
}
