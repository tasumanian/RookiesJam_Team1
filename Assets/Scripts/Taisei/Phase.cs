using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CreatePhase", menuName = "ScriptableObject/Phase")]
public class Phase : ScriptableObject
{
    //必要なアイテム
    [SerializeField]
    List<Item> needItems; 
    public List<Item> NeedItems
    {
        get { return needItems; }
    }
    //必要なイベント
    [SerializeField]
    List<Ivent> needIvents;
    public List<Ivent> NeedIvents
    {
        get { return needIvents; }
    }
    //クリア時に表示するテキスト
    [SerializeField]
    [TextArea(5,5)]
    private string context;
    public string Context
    {
        get { return context;  }
    }
}
