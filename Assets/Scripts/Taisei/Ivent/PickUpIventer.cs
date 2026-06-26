using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PickUpIventer : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField]
    Ivent ivent;

    [SerializeField]
    BackPack backPack;

    [SerializeField]
    Dialog dialog;
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

        gameObject.SetActive(false);
    }

}
