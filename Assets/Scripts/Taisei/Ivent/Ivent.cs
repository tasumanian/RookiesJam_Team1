using UnityEngine;

[CreateAssetMenu(fileName = "CreateItem", menuName = "ScriptableObject/Ivent")]
public class Ivent : ScriptableObject
{
    //識別番号
    [SerializeField]
    private string identifier;
    public string Identifier
    {
        get { return identifier; }
    }
    //会話内容
    [SerializeField]
    [TextArea(5, 5)]
    private string[] content;
    public string[] Content
    {
        get { return content; }
    }
    //会話者
    [SerializeField]
    private string speaker;
    public string Speaker
    {
        get { return speaker; }
    }
    //獲得アイテム
    [SerializeField]
    private Item getItem;
    public Item GetItem
    {
        get { return getItem; }
    }
    //前提フェーズ
    [SerializeField]
    private Phase terms;
    public Phase Terms
    {
        get { return terms;  }
    }
}
//イベントタイプ、会話型か拾う形か
public enum IventType
{
    Talk,
    PickUp
}
