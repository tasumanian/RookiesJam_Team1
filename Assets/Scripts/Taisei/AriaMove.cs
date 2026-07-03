using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AriaMove : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mapList;
    //マップが格納されているリスト
    [SerializeField]
    Animator ani;
    //暗転、光転するアニメーション
    [SerializeField]
    BackPack backpack;
    [SerializeField]
    Dialog dialog;
    [SerializeField]
    GameObject nowAria;
    //現在のマップ
    [SerializeField]
    SoundManager soundManager;
    [SerializeField]
    TextMeshProUGUI roomName;
    //左上に表示するやつ
    int nowIndex = 0;
    //現在のマップのindex
    public List<Phase> passedPhase;
    // 完了したフェーズのリスト

    IEnumerator ChangeAnimation(int index)
    {
        ani.SetTrigger("BrackOut");
        yield return new WaitForSeconds(1.5f);
        //暗転

        Destroy(nowAria);
        //現在のマップを削除

        nowAria = Instantiate(mapList[index],gameObject.transform);
        nowAria.GetComponent<IventChecker>().IventLoad(passedPhase, backpack, dialog,soundManager);
        roomName.text = nowAria.GetComponent<IventChecker>().RoomName;
        //新しいマップを生成、イベントロード、Name取得

        yield return new WaitForSeconds(0.5f);
        ani.SetTrigger("RightChange");
        //光転
    }
    public void ChangeAria(int index) //こっちで受け取ってから、アニメーションに投げる
    {
        if (index == -1) //-1は現在のマップを再度表示する
        {
            StartCoroutine(ChangeAnimation(nowIndex));
        }
        else
        {
            StartCoroutine(ChangeAnimation(index));
            nowIndex = index;
        }
    }
}
