using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObject/Item")]

public class Item : ScriptableObject
{
    //識別番号
    [SerializeField]
    private int identifier;
    public int Identifier
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
    [SerializeField]
    private string info;
    public string Info
    {
        get { return info; }
    }
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
}

//アイテムの属性
//追加する場合は名前とカンマを追加すること
public enum Attribute
{
    hage,
    hige,
    huge,
    hege,
    hoge

}
