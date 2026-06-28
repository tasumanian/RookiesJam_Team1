using UnityEngine;

[CreateAssetMenu(fileName = "CreateItem", menuName = "ScriptableObject/Ivent")]
public class Ivent : ScriptableObject
{
    [SerializeField]
    private string identifier;
    public string Identifier
    {
        get { return identifier; }
    }
    [SerializeField]
    [TextArea(5, 5)]
    private string content;
    public string Content
    {
        get { return content; }
    }
    [SerializeField]
    private string speaker;
    public string Speaker
    {
        get { return speaker; }
    }
    [SerializeField]
    private Item getItem;
    public Item GetItem
    {
        get { return getItem; }
    }
}
public enum IventType
{
    Talk,
    PickUp
}
