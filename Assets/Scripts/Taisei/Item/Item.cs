using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]

public class Item : ScriptableObject
{
    //識別番号
    [SerializeField]
    private string identifier;
    public string Identifier
    {
        get { return identifier; }
    }
    //名前
    [SerializeField]
    private string itemName;
    public string ItemName 
    {
        get { return itemName; }
    }

    //詳細情報
    [SerializeField]
    private string info;
    public string Info
    {
        get { return info; }
    }

    //見た目
    [SerializeField]
    private Sprite visual;
    public Sprite Visual
    {
        get { return visual; }
    }

    //属性
    [SerializeField]
    private Attribute attribute;
    public Attribute Attribute
    {
        get { return attribute; }
    }

    //クラフト素材A(クラフトしないなら設定しない)
    [SerializeField]
    private Item materialAItem;
    public Item MaterialAItem
    {
        get { return materialAItem; }
    }

    //クラフト素材B(クラフトしないなら設定しない)
    [SerializeField]
    private Item materialBItem;
    public Item MaterialBItem
    {
        get { return materialBItem; }
    }
}

//アイテムの属性
//追加する場合は名前とカンマを追加すること
public enum Attribute
{
    hage,
    hige,
    huge,
    hege,
    hoge,
    creation

}
