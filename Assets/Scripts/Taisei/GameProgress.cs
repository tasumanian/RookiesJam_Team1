using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    [SerializeField]
    List<Phase> phases;

    int nowPhase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nowPhase = PlayerPrefs.GetInt("Progress", 0);
    }

    public void ProgressCheck()
    {
        foreach (Item item in phases[nowPhase].NeedItems)
        {
            int score = PlayerPrefs.GetInt(item.Identifier, 0);
            if (score == 0) //条件を満たしていない場合
            {
                return;
            }
        }
        foreach (Ivent ivent in phases[nowPhase].NeedIvents)
        {
            int score = PlayerPrefs.GetInt("A" + ivent.Identifier, 0);
            if (score == 0) //条件を満たしていない場合
            {
                return;
            }
        }
        //両条件をクリアしている場合
        NextPhase();
    }
    public void NextPhase()
    {
        nowPhase++;
        SaveData.SaveProgress(nowPhase);

    }
}
