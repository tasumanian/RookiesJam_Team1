using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    // セリフのテキスト枠を登録する場所。
    [SerializeField] private GameObject button;
    // 逆三角が入っているボタンを登録する場所。
    [SerializeField] private SkipGuideScript skipGuideScript;
    // 案内用テキストのスクリプトを登録する場所。

    [TextArea(5, 5)]
    [SerializeField] private string[] msgTexts;
    // これから作る複数のセリフを入れておくリストの箱。

    private int currentTextIndex = 0;
    // 今何番目のセリフを読んでいるか数えるカウンター。
    private float msgSpeed = 0.1f;
    // 文字が出るスピード（0.1秒）。
    private bool isTextComplete = false;
    // 文字が最後まで出終わったかを記録するスイッチ。

    void Start()
    {
        currentTextIndex = 0;
        // カウンターを最初の0番目にセットする。
        StartNewDialog();
        // 新しい文章を表示する処理を呼び出す。
    }

    void Update()
    {
        if (isTextComplete == false)
        // もし文字が流れている途中なら。
        {
            if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
            // もしスペースキーが押されたら。
            {
                StopAllCoroutines();
                // 文字を出すタイピング演出を強制終了する。
                DialogText.text = msgTexts[currentTextIndex];
                // メッセージを一瞬で全表示する。
                button.SetActive(true);
                // 隠していた逆三角ボタンを表示する。

                skipGuideScript.ShowNextGuide();
                // 案内表示を「クリックしてつぎへ」に変更。
                isTextComplete = true;
                // タイピング演出が終わったことを記録する。
            }
        }
        else
        // そうではなく、すでに文字が出終わっているなら。
        {
            if (UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame)
            // もしマウスの左クリックが押されたら。
            {
                currentTextIndex++;
                // カウンターを1つ進めて、次の文章の番号にする。
                if (currentTextIndex < msgTexts.Length)
                // もし次の文章がまだリストに残っているなら。
                {
                    StartNewDialog();
                    // 次の文章を表示する処理をもう一度おこなう。
                }
                else
                // もう次の文章が残っていない（会話が全部終わった）なら。
                {
                    DialogText.text = "";
                    // 画面のセリフを消して空にする。
                    button.SetActive(false);
                    // 逆三角ボタンを隠す。
                    skipGuideScript.ShowEndGuide();
                    // 案内表示を完全に消してもらう。
                }
            }
        }
    }

    void StartNewDialog()
    {
        isTextComplete = false;
        // 新しい文章なので、まだ出終わっていない状態にする。
        DialogText.text = "";
        // 画面の文字を一度リセットして空にする。
        button.SetActive(false);
        // 逆三角ボタンを新しく隠し直す設定。

        skipGuideScript.ShowSkipGuide();
        // 案内表示を最初の「スキップ」に戻してもらう。
        StartCoroutine(TypeDisplay());
        // 新しいセリフのタイピング演出をスタートさせる。
    }

    IEnumerator TypeDisplay()
    {
        foreach (char item in msgTexts[currentTextIndex].ToCharArray())
        // 用意した文章を1文字ずつに分解して順番に処理する。
        {
            DialogText.text += item;
            // 分解した文字を、画面に一文字ずつ表示する。
            yield return new WaitForSeconds(msgSpeed);
            // 次の文字を出すまで、0.1秒だけ待つ。
        }
        button.SetActive(true);
        // 最後まで文字が出し終わったら逆三角ボタンを表示する。
        skipGuideScript.ShowNextGuide();
        // 読み終わったので案内表示を「つぎへ」に変えてもらう。
        isTextComplete = true;
        // 自力で最後まで出し終わったので、ここでもスイッチをONにする。
    }
    
    //追加点
    public void TextSet(string text)
    {

        //ログ表示などをするならListのほうがいいかも
        msgTexts[currentTextIndex] = text;

        StartNewDialog();
    }
}
