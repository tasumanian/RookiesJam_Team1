using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpilogueProgress : MonoBehaviour
{
    [SerializeField] private Dialog dialogScript;
    // 既存の会話システム（Dialog）を登録する場所。

    [SerializeField] private GameObject nameWindow;
    // 後日談ではいらない名前枠のUIなどを登録して隠すための場所。

    [SerializeField] private Animator whiteOutAnimator;
    // 画面を白く染めるアニメーションのコントローラーを登録する場所。

    [TextArea(5, 5)]
    [SerializeField] private string[] epilogueTexts;
    // 後日談で流したい文章をまとめて入れておく箱。

    private bool isCheckingEnd = false;
    // 後日談の終了チェックを開始したかどうかのスイッチ。

    void Start()
    {
        if (whiteOutAnimator != null)
        // もし画面を白く染めるコンローラーが登録されていれば。
        {
            UnityEngine.UI.Image img = whiteOutAnimator.GetComponent<UnityEngine.UI.Image>();
            if (img != null)
            {
                Color color = img.color;
                color.a = 0f;
                img.color = color;
                // ゲーム開始時に白い画面の透明度を強制的にゼロにして隠す設定。
            }
        }

        if (nameWindow != null)
        {
            nameWindow.SetActive(false);
            // 後日談では不要な名前枠を画面から非表示にする設定。
        }

        if (dialogScript != null && epilogueTexts.Length > 0)
        {
            dialogScript.TextListSet(epilogueTexts, "");
            // 既存のDialogに文章を流し込んで再生してもらう処理。

            isCheckingEnd = true;
            // 文章を流し込んだので、終了チェックのスイッチをONにする。
        }
    }

    void Update()
    {
        // 終了チェックがON、かつ、Dialog側の会話が完全に終わった（IsEndがtrueになった）なら。
        if (isCheckingEnd && dialogScript != null && dialogScript.IsEnd)
        {
            isCheckingEnd = false;
            // 【超重要】1回でも条件を満たしたらすぐにスイッチをOFFにして、命令の連打（暴走）を絶対に防ぐ設定。

            StartCoroutine(PlayWhiteOutAnimation());
            // 後日談がすべて終わったので、ホワイトアウト演出を始める処理を呼び出す。
        }
    }

    private IEnumerator PlayWhiteOutAnimation()
    {
        if (whiteOutAnimator != null)
        {
            whiteOutAnimator.Play("whiteOutAnimation");
            // Animator内の実際の箱の名前（whiteOutAnimation）と完全に一致させて再生する処理。

            yield return null;
            // アニメーションの再生が始まるまで1フレームだけ待つ設定。

            // アニメーションが再生中（進行度が1.0未満）の間は、ここでじっと待つ設定。
            while (whiteOutAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                yield return null;
            }
        }

        // アニメーションが100%再生し終わった（完全に真っ白になった）瞬間にシーンを切り替える処理。
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScene");
    }

}
