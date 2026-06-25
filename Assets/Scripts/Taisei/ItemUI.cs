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

    private GameObject detailObj;
    public Item item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initializae(Item item,GameObject infoobj)
    {
        this.item = item;
        icon.sprite = item.Visual;
        text.text = item.ItemName;
        if (infoobj != null)
        {
            detailObj = infoobj;
        }
        if(button != null) 
        {
            button.onClick.AddListener(DetailSet);
        }
    }
    public void DetailSet()
    {
        if (detailObj == null) return;

        Transform backscreenTf = detailObj.transform.GetChild(0);
        ItemUI itemUI = backscreenTf.GetChild(0).GetComponent<ItemUI>();
        itemUI.Initializae(item, null);
        var info = backscreenTf.GetChild(1).GetComponent<TextMeshProUGUI>();
        info.text = item.Info;
        detailObj.SetActive(true);
    }
}
