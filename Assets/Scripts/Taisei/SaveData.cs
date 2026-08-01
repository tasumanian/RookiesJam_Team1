using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public static void AddItem(Item item) //アイテムのついか
    {

        PlayerPrefs.SetInt("I" + item.Identifier,1);
        //1は所持していることを表す
    }
    public static void RemoveItem(Item item)//アイテムの削除
    {

        PlayerPrefs.DeleteKey("I" + item.Identifier);
        //アイテムを削除
    }
    public static void SaveProgress(int progress)
    {
        
        PlayerPrefs.SetInt("P" + progress.ToString(), 1);
        //進捗状況を保存
    }
    public static void MemoSave(string memo)
    {
    
        Debug.Log("メモ帳を保存しました" + memo);
        PlayerPrefs.SetString("Memo", memo);
        //メモ帳を保存
    }
    public static void CheckIvent(Ivent ivent) //イベントが実行されたら、記録
    {
        
        PlayerPrefs.SetInt("A" + ivent.Identifier, 1);
    }
    public static void Initialize()
    {
        PlayerPrefs.DeleteAll();
        //全初期化
    }
}
