using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class BackPack : MonoBehaviour
{
    [SerializeField]
    private List<Item> itemList = new List<Item>();
    [SerializeField]
    private List<GameObject> itemUIList = new List<GameObject>();

    [SerializeField]
    private GameObject itemUIPrefab;
    [SerializeField]
    private GameObject itemMenu;
    [SerializeField]
    private GameObject detailMenu;
    [SerializeField]
    private CreateItemMenu createMenu;
    [SerializeField]
    SurveyProgress sp;

    private bool isCustom = false;
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
            int score = PlayerPrefs.GetInt(item.Identifier, 0);
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

        GameObject ui = Instantiate(itemUIPrefab, itemMenu.transform);
        itemUIList.Add(ui);
        ui.GetComponent<ItemUI>().Initializae(item, this);

        sp.ProgressCheck();
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        SaveData.RemoveItem(item);

        for(int i = 0; i < itemUIList.Count;i++)
        {
            if(itemUIList[i].GetComponent<ItemUI>().item == item)
            {
                GameObject obj = itemUIList[i];
                itemUIList.Remove(obj);
                Destroy(obj);
                break;
            }
        }
    }
    public void DetailSet(Item item)
    {   
        if(isCustom)
        {
            createMenu.SetCreateItem(item);
            detailMenu.SetActive(false);
            return;
        }
        if (detailMenu == null) return;

        Transform backscreenTf = detailMenu.transform.GetChild(0);
        ItemUI itemUI = backscreenTf.GetChild(0).GetComponent<ItemUI>();
        itemUI.Initializae(item, null);
        var info = backscreenTf.GetChild(1).GetComponent<TextMeshProUGUI>();
        info.text = item.Info;
        detailMenu.SetActive(true);
    }
    public void ToggleCreateMenu()
    {
        isCustom = !isCustom;

        createMenu.gameObject.SetActive(isCustom);
    }
}
