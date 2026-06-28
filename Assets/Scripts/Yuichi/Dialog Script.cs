using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    // 画面のテキスト枠を登録する場所。
    [SerializeField] private GameObject button;
    // 進行用の逆三角ボタンを登録する場所。
    [SerializeField] private SkipGuideScript skipGuideScript;
    // スキップガイドスクリプトを登録する場所。

    [SerializeField] private TextMeshProUGUI NameText;
    // 名前用のテキスト枠を登録する場所。

    [TextArea(5, 5)]
    [SerializeField] private List<string> msgTexts = new List<string>();
    // 文字が入るたびに、自動で引き出しが増えるセリフの箱。

    [SerializeField] private List<string> speakerNames = new List<string>();
    // セリフに合わせて自動で引き出しが増える名前の箱。

    private int currentTextIndex = 0;
    // 今何番目のセリフを読んでいるかを数えるカウンター。
    private float msgSpeed = 0.1f;
    // 文字が出るスピード（0.1秒）。
    private bool isTextComplete = false;
    // 文字が出終わった状態にするためのスイッチ。

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
                // 現在のインデックスがリストの範囲内かチェック
                if (currentTextIndex >= 0 && currentTextIndex < msgTexts.Count)
                {
                    StopAllCoroutines();
                    // 文字を出すタイピング演出（コルーチン）を強制終了する。
                    DialogText.text = msgTexts[currentTextIndex];
                    // メッセージを一瞬で全表示する。
                    button.SetActive(true);
                    // 隠していた逆三角ボタンを表示する。
                    skipGuideScript.ShowNextGuide();
                    // 案内表示をクリックしてつぎへに変更。
                    isTextComplete = true;
                    // 文字が出終わった状態にする。
                }
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

                if (currentTextIndex < msgTexts.Count)
                // もし次の文章がまだリストに残っているなら。
                {
                    StartNewDialog();
                    // 次の文章を表示する処理をもう一度おこなう。
                }
                else
                // 会話が全部終わったなら。
                {
                    DialogText.text = "";
                    // 画面のセリフを消して空にする。
                    NameText.text = "";
                    // 画面の名前も消して空にする。
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
        if (msgTexts.Count == 0) return;
        // リストの中身が空っぽなら、エラーを防ぐために処理をスルーする。

        isTextComplete = false;
        // 新しい文章なので、まだ出終わっていない状態にする。
        DialogText.text = "";
        // 画面の文字を一度リセットして空にする。
        button.SetActive(false);
        // 逆三角ボタンを新しく隠し直す設定。

        if (currentTextIndex < speakerNames.Count)
        // 次の番号の名前が登録されていれば。
        {
            NameText.text = speakerNames[currentTextIndex];
            // 名前用のテキスト枠を書き換える。
        }

        skipGuideScript.ShowSkipGuide();
        // 案内表示を最初のスキップに戻してもらう。
        StartCoroutine(TypeDisplay());
        // 新しいセリフのタイピング演出をスタートさせる。
    }

    IEnumerator TypeDisplay()
    // 時間差で文字を出すコルーチンの台本
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
        // 読み終わったので案内表示をつぎへに変えてもらう。
        isTextComplete = true;
        // 自力で最後まで出し終わったので、ここでもスイッチをONにする。
    }

    public void TextSet(string text)
    // 外部から新しいセリフを流し込んで、新しく再生し直す機能。
    {
        StopAllCoroutines();
        // 動いているタイピング演出（コルーチン）をすべて停止する。

        msgTexts.Add(text);
        // 引数の文字列をセリフ用リストの末尾に追加。

        speakerNames.Add("");
        // 空の文字列を名前用リストの末尾に追加し、セリフと名前の数を揃える。

        currentTextIndex = msgTexts.Count - 1;
        // カウンターを最後尾の要素番号に設定。

        StartNewDialog();
        // 上書きした文章で、新しく会話の演出をスタートさせる。
    }
}
