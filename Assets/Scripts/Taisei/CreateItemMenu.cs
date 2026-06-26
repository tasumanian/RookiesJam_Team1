using UnityEngine;
using UnityEngine.UI;

public class CreateItemMenu : MonoBehaviour
{
    [SerializeField]
    private ItemUI Aitem;
    [SerializeField]
    private ItemUI Bitem;
    [SerializeField]
    private ItemUI CreatedItem;
    [SerializeField]
    private Button button;
    [SerializeField]
    private BackPack backpack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CreateItem()
    {
        if (Aitem.item == null || Bitem.item == null)
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
            if ((item.MaterialAItem == Aitem.item && item.MaterialBItem == Bitem.item)
                || (item.MaterialAItem == Bitem.item && item.MaterialBItem == Aitem.item))
            {
                Debug.Log("itemCreate");
                //アイテム生成
                CreatedItem.Initializae(item, null);
                CreatedItem.gameObject.SetActive(true);

                button.onClick.AddListener(() => backpack.AddItem(item));

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
        if (Aitem.item == null)
        {
            Aitem.Initializae(item, null);
            return;
        }
        //既にある場合は削除
        if(Aitem.item == item)
        {
            Aitem.RemoveDetail();
            return;
        }
        //Bも同様
        if (Bitem.item == null)
        {
            Bitem.Initializae(item, null);
            return;
        }
        if (Bitem.item == item)
        {
            Bitem.RemoveDetail();
            return;
        }
        //既に入っていることを表示する場合はここ


    }
}
