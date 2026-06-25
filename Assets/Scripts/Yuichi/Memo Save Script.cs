using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MemoSaveScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI text;

    void Start()
    {
        inputField = inputField.GetComponent<TMP_InputField>();
        text = text.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // 入力欄に文字を打ち込んでいる状態（フォーカスがある時）だけ反応する
        if (inputField.isFocused && Keyboard.current != null)
        {
            // 左右どちらかの「Ctrl」キーがポンと押された瞬間を判定
            if (Keyboard.current.leftCtrlKey.wasPressedThisFrame ||
                Keyboard.current.rightCtrlKey.wasPressedThisFrame)
            {
                // 現在のカーソル位置（文字を打っている場所）を取得
                int cursorPosition = inputField.caretPosition;

                // 安全ガード：文字が空っぽの時でもエラーが出ないようにする [表1.3.4]
                if (cursorPosition < 0) cursorPosition = 0;
                if (cursorPosition > inputField.text.Length) cursorPosition = inputField.text.Length;

                // カーソルのある場所に改行「\n」を差し込み、カーソルを1歩進める
                inputField.text = inputField.text.Insert(cursorPosition, "\n");
                inputField.caretPosition = cursorPosition + 1;
            }
        }
    }

    public void InputText()
    {
        // 入力された文字を表示用のテキストにそのままコピーする
        text.text = inputField.text;
        Debug.Log("aaa" + inputField.text);
    }
}

