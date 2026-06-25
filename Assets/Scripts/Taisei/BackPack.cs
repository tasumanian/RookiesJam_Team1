using UnityEngine;
using System.Collections.Generic;

public class BackPack : MonoBehaviour
{
    [SerializeField]
    private List<Item> itemList = new List<Item>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackPackLoad();
    }

    // Update is called once per frame
    public void BackPackLoad()
    {
        itemList.Clear();

        Item[] itemData = Resources.LoadAll<Item>("Items");
        foreach (Item item in itemData)
        {
            int score = PlayerPrefs.GetInt(item.Identifier.ToString(), 0);
            if (score == 1) //持っている場合
            {
                AddItem(item);
            }
        }
    }
    public void AddItem(Item item)
    {
        itemList.Add(item);
        SaveData.AddItem(item);
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        SaveData.RemoveItem(item);
    }
}
