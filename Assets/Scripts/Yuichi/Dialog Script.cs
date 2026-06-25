using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    // 画面のテキスト枠を登録する場所。
    [SerializeField] private GameObject button;
    // 次へ進むためのボタンを登録する場所。

    [TextArea(5, 5)]
    // 文章を打ちやすくする設定
    [SerializeField] private string msgText;
    // 表示したいメッセージを入れておく箱
    private float msgSpeed = 0.1f;
    // 文字が出るスピード （0.1秒）

    void Start()
    {
        DialogText.text = "";
        // 画面の文字をリセットして空にする。
        button.SetActive(false);
        // 最初はボタンを隠しておく設定。

        StartCoroutine(TypeDisplay());
        // タイピング演出の時間差処理をスタートさせる。
    }

    void Update()
    {
        if (UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
        // もしスペースキーが押されたら。
        {
            StopAllCoroutines();
            // 文字を出すタイピング演出を強制終了する。
            DialogText.text = msgText;
            // メッセージを一瞬で全表示する。
            button.SetActive(true);
            // 隠していたボタンを表示する。
        }
    }

    IEnumerator TypeDisplay()
    //時間差で文字を出す台本
    {
        foreach (char item in msgText.ToCharArray())
        // 用意した文章を1文字ずつに分解して順番に処理する。
        {
            DialogText.text += item;
            // 分解した文字を、画面に一文字ずつ表示する。
            yield return new WaitForSeconds(msgSpeed);
            // 次の文字を出すまで、0.1秒だけ待つ。
        }
        button.SetActive(true);
        // 最後まで文字が出し終わったらボタンを表示する。
    }
}
