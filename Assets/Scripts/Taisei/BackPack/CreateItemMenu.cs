using UnityEngine;
using UnityEngine.UI;

public class CreateItemMenu : MonoBehaviour
{
    [SerializeField]
    private ItemUI Aitem; //選択アイテムA
    [SerializeField]
    private ItemUI Bitem;　//選択アイテムB
    [SerializeField]
    private ItemUI CreatedItem;　//完成アイテム
    [SerializeField]
    private Button button;
    [SerializeField]
    private BackPack backpack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CreateItem()
    {
        if (Aitem.Item == null || Bitem.Item == null)
        {
            //合成失敗を表示
            Debug.Log("失敗");
            return;
        }
        Item[] itemData = Resources.LoadAll<Item>("Items");
        foreach (Item item in itemData)
        {
            if (item.Attribute != Attribute.creation)
                continue;

            Debug.Log(item.ItemName);
            //素材と選択アイテムが等しい時
            if ((item.MaterialAItem == Aitem.Item && item.MaterialBItem == Bitem.Item)
                || (item.MaterialAItem == Bitem.Item && item.MaterialBItem == Aitem.Item))
            {
                //アニメーション


                Debug.Log("itemCreate");
                //アイテム生成
                CreatedItem.Initializae(item, null);
                CreatedItem.gameObject.SetActive(true);

                button.onClick.AddListener(() => backpack.AddItem(item));
                button.onClick.AddListener(() => CreatedItem.RemoveDetail());
                button.onClick.AddListener(() => button.onClick.RemoveAllListeners());

                //アイテム削除
                backpack.RemoveItem(Aitem.Item);
                Aitem.RemoveDetail();
                backpack.RemoveItem(Bitem.Item);
                Bitem.RemoveDetail();

                return;
            }
        }
        Debug.Log("失敗");
        return;
    }
    public void SetCreateItem(Item item)
    {
        Debug.Log("item" + item);
        //空の場合、アイテムを設定
        if (Aitem.Item == null)
        {
            Aitem.Initializae(item, null);
            return;
        }
        //既にある場合は削除
        if(Aitem.Item == item)
        {
            Aitem.RemoveDetail();
            return;
        }
        //Bも同様
        if (Bitem.Item == null)
        {
            Bitem.Initializae(item, null);
            return;
        }
        if (Bitem.Item == item)
        {
            Bitem.RemoveDetail();
            return;
        }
        //既に入っていることを表示する場合はここ


    }
}
