using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static void AddItem(Item item)
    {
        //1は所持していることを表す
        PlayerPrefs.SetInt(item.Identifier,1);
    }
    public static void RemoveItem(Item item)
    {
        //アイテムを削除
        PlayerPrefs.DeleteKey(item.Identifier);
    }
    public static void SaveProgress(int progress)
    {
        //進捗状況を保存
        PlayerPrefs.SetInt("P" + progress.ToString(), 1);
    }
    public static void MemoSave(string memo)
    {
        //メモ帳を保存
        Debug.Log("メモ帳を保存しました" + memo);
        PlayerPrefs.SetString("Memo", memo);
    }
    public static void CheckIvent(Ivent ivent)
    {
        //1は所持していることを表す
        PlayerPrefs.SetInt("A" + ivent.Identifier, 1);
    }
    public static void Initialize()
    {
        PlayerPrefs.DeleteAll();
        //全初期化
    }
}
