using System.Collections.Generic;
using UnityEngine;

public class SaveData : ScriptableObject
{
    [SerializeField]
    private List<Item> backPack;
    public List<Item> BackPack
    {
        get { return backPack; }
    }
    public void AddItem(Item item)
    {
        backPack.Add(item);
    }
    public void RemoveItem(Item item)
    {
        backPack.Remove(item);
    }
    [SerializeField]
    private Scene nowScene;
    public Scene NowScene
    {
        get { return nowScene; }
    }
public enum Scene
{
    tutorial,
    search1,
    search2,
    judge
}
}
