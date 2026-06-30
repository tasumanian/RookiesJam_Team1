using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CreatePhase", menuName = "ScriptableObject/Phase")]
public class Phase : ScriptableObject
{

    [SerializeField]
    List<Item> needItems;
    public List<Item> NeedItems
    {
        get { return needItems; }
    }
    [SerializeField]
    List<Ivent> needIvents;
    public List<Ivent> NeedIvents
    {
        get { return needIvents; }
    }
    [SerializeField]
    [TextArea(5,5)]
    private string context;
    public string Context
    {
        get { return context;  }
    }
}
