using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpIventer : MonoBehaviour , IPointerClickHandler
{
    //実行するイベント
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
    private AudioClip SE;
    private SoundManager soundManager;
    public SoundManager SoundManager
    {
        set { soundManager = value; }
    }

    [SerializeField]
    Dialog dialog;
    public Dialog Dialog
    {
        set {  dialog = value; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void OnPointerClick(PointerEventData eventData)
    {
        //クリックされたらイベントを実行
        ActionIvent();
    }
    public void ActionIvent()
    {

        Debug.Log(ivent.GetItem.ItemName + "をゲット");
        backPack.AddItem(ivent.GetItem);
        //イベントに設定されたアイテムを入手

        soundManager.PlaySE(SE);

        dialog.TextListSet(ivent.Content,ivent.Speaker);
        //ダイアログにテキストを入力

        SaveData.CheckIvent(ivent);
        //イベント終了をセーブ

        gameObject.SetActive(false);
        //非表示化
    }

}
