using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Button button;

    public Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initializae(Item item, BackPack backpack)
    {
        this.item = item;
        icon.sprite = item.Visual;
        text.text = item.ItemName;
        if(backpack != null) 
        {
            button.onClick.AddListener(() => backpack.DetailSet(item));
        }
    }
    public void RemoveDetail()
    {
        item = null;
        icon.sprite = null;
        text.text = null;
        if (button != null)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}

