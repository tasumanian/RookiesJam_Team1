using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpIventer : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    Ivent ivent;
    public Ivent Ivent
    {
        get { return ivent; }
    }

    [SerializeField]
    BackPack backPack;
    public BackPack BackPack
    {
        set { backPack = value; }
    }

    [SerializeField]
    Dialog dialog;
    public Dialog Dialog
    {
        set {  dialog = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("hoge");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // Debug.Log("hoge");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ActionIvent();
    }
    public void ActionIvent()
    {
        //イベント実行
        Debug.Log(ivent.GetItem.ItemName + "をゲット");
        backPack.AddItem(ivent.GetItem);

        dialog.TextSet(ivent.Content);

        SaveData.CheckIvent(ivent);

        gameObject.SetActive(false);
    }

}
