using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AriaMove : MonoBehaviour
{
    [SerializeField]
    List<GameObject> mapList;
    //マップが格納されているリスト
    [SerializeField]
    CanvasGroup fadePanel;
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

    [SerializeField]
    private AudioClip clip;
    // 完了したフェーズのリスト

    static bool isMoving = false;

    IEnumerator ChangeAnimation(int index)
    {
        if (isMoving)
        {
            yield return null;
        }
        else
        {
            isMoving = true;
            if(!(index == 6 || index == 7))
            { 
                soundManager.PlaySE(clip);
            }

            StartCoroutine(FadeOut());

            yield return new WaitForSeconds(1f);
            //暗転

            Destroy(nowAria);
            //現在のマップを削除

            nowAria = Instantiate(mapList[index], gameObject.transform);
            nowAria.GetComponent<IventChecker>().IventLoad(passedPhase, backpack, dialog, soundManager);
            roomName.text = nowAria.GetComponent<IventChecker>().RoomName;
            //新しいマップを生成、イベントロード、Name取得

            yield return new WaitForSeconds(0.2f);

            StartCoroutine(FadeIn());
            //光転
            isMoving = false;
        }
    }
    public void ChangeAria(int index) //こっちで受け取ってから、アニメーションに投げる
    {
        if(nowIndex == index)
        {
            return;
        }
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
    private IEnumerator FadeOut()
    {
        fadePanel.gameObject.SetActive(true);
        for (float i = 0; i < 1; i += Time.unscaledDeltaTime)
        {
            fadePanel.alpha = i;
            yield return null;
        }
    }
    private IEnumerator FadeIn()
    {
        for (float i = 1; i > 0; i -= Time.unscaledDeltaTime)
        {
            fadePanel.alpha = i;
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);
    }
}
