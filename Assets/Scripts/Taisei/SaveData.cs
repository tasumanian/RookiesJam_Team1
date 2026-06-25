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
        PlayerPrefs.DeleteKey(item.Identifier);
    }
    public static void SetProgress(int progress)
    {
        PlayerPrefs.SetInt("progress", progress);
    }
    public void MemoSave(string memo)
    {
        PlayerPrefs.SetString("Memo", memo);
    }
}
