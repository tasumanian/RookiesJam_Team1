using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    [SerializeField]
    private List<Item> itemList = new List<Item>();
    //所持しているアイテムのリスト
    [SerializeField]
    private List<GameObject> itemUIList = new List<GameObject>();
    //バックパック内のアイテムの表記UI

    [SerializeField]
    private GameObject itemUIPrefab;

    [SerializeField]
    private GameObject itemMenu;
    //メニュー画面
    [SerializeField]
    private GameObject detailMenu;
    //詳細画面
    [SerializeField]
    private CreateItemMenu createMenu;
    //合成用画面
    [SerializeField]
    private SurveyProgress sp;
    //進捗管理

    private bool isCraft = false;
    //合成モードかどうか
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BackPackLoad();
        //バックパックのロード
    }

    // Update is called once per frame
    public void BackPackLoad() //バックパックのロード
    {
        itemList.Clear();

        Item[] itemData = Resources.LoadAll<Item>("Items");
        //リソースファイルから前アイテムを取得

        foreach (Item item in itemData)
        {
            int score = PlayerPrefs.GetInt("I" + item.Identifier, 0);

            if (score == 1) //持っている場合
            {
                //アイテムを追加
                Debug.Log("Has" + item.ItemName);
                AddItem(item);
            }
        }
    }

    public void AddItem(Item item)
    {
        
        itemList.Add(item);
        SaveData.AddItem(item);
        //リストとセーブデータにアイテムを追加

        GameObject ui = Instantiate(itemUIPrefab, itemMenu.transform);
        itemUIList.Add(ui);
        ui.GetComponent<ItemUI>().Initializae(item, this);
        //UIの生成、リストに追加、初期化

        if (sp != null)
        {
            sp.ProgressCheck();
            //進捗確認
        }    
    }
    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
        SaveData.RemoveItem(item);
        //アイテムを削除

        for(int i = 0; i < itemUIList.Count;i++)
        {
            if(itemUIList[i].GetComponent<ItemUI>().Item == item)
            {//リスト内から同一のアイテムのものを削除

                GameObject obj = itemUIList[i];
                itemUIList.Remove(obj);
                Destroy(obj);
                break;
            }
        }
    }
    public void DetailSet(Item item)
    {   
        if(isCraft)
        {
            //合成モード時はクラフトメニューを開く

            createMenu.SetCreateItem(item);
            detailMenu.SetActive(false);

            return;
        }
        if (detailMenu == null) return;

        Transform backscreenTf = detailMenu.transform.GetChild(0);
        ItemUI itemUI = backscreenTf.GetChild(0).GetComponent<ItemUI>();
        itemUI.Initializae(item, null);
        //UIの初期化
        var info = backscreenTf.GetChild(1).GetComponent<TextMeshProUGUI>();
        info.text = item.Info;
        //アイテムの詳細情報を設定

        detailMenu.SetActive(true);
    }
    public void ToggleCreateMenu()
    {
        isCraft = !isCraft;
        //クラフトモードの切り替え

        createMenu.gameObject.SetActive(isCraft);
        //表示変更
    }
}
