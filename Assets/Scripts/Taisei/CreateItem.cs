using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CreateItem", menuName = "ScriptableObject/CreateItem")]

public class CreateItem : ScriptableObject
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
    [SerializeField]
    private List<Item> materialItems;
    public List<Item> MaterialItems
    {
        get { return materialItems; }
    }
}
