using System.Collections;
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
    [SerializeField]
    private SurveyProgress sp;
    [SerializeField]
    private Animator ani;
    [SerializeField]
    private AudioClip missSE;
    [SerializeField]
    private AudioClip correctSE;
    [SerializeField]
    private SoundManager soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CreateItem()
    {
        if (Aitem.Item == null || Bitem.Item == null)
        {
            //合成失敗を表示
            Debug.Log("失敗");
            soundManager.PlaySE(missSE);

            return;
        }

       Item[] itemData = Resources.LoadAll<Item>("Items");
        foreach (Item item in itemData)
        {
            if (item.Attribute != Attribute.creation)
                continue;

            ani.SetTrigger("craft");

            Debug.Log(item.ItemName);
            //素材と選択アイテムが等しい時
            if ((item.MaterialAItem == Aitem.Item && item.MaterialBItem == Bitem.Item)
                || (item.MaterialAItem == Bitem.Item && item.MaterialBItem == Aitem.Item))
            {
                Debug.Log("itemCreate");
                //アイテム生成
                CreatedItem.Initializae(item, null);
                CreatedItem.gameObject.SetActive(true);

                button.onClick.AddListener(() => backpack.AddItem(item));
                button.onClick.AddListener(() => sp.ProgressCheck());
                button.onClick.AddListener(() => CreatedItem.RemoveDetail());
                button.onClick.AddListener(() => button.onClick.RemoveAllListeners());

                //アイテム削除
                backpack.RemoveItem(Aitem.Item);
                Aitem.RemoveDetail();
                backpack.RemoveItem(Bitem.Item);
                Bitem.RemoveDetail();

                StartCoroutine(CraftSE(true));
                return;

            }
        }
        StartCoroutine(CraftSE(false));
        Debug.Log("失敗");
        return;
    }
    IEnumerator CraftSE(bool correct)
    {
        yield return new WaitForSeconds(1.0f);

        if(correct)
        {
            soundManager.PlaySE(correctSE);
        }
        else
        {
            soundManager.PlaySE(missSE);
        }
        yield return new WaitForSeconds(0.3f);
        ani.SetTrigger("craft");
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
