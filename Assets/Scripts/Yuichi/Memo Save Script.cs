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
        //入力欄のオブジェクトから、TextMeshProのコンポーネントを認識させる。

        text = text.GetComponent<TextMeshProUGUI>();
        //表示用テキストのオブジェクトから、TextMeshProのコンポーネントを認識させる。
    }

    void Update()
    {

        if (inputField.isFocused && Keyboard.current != null)
        {
            //入力欄の中にカーソルが存在し、文字を打ち込める状態のときだけ反応します。

            if (Keyboard.current.leftCtrlKey.wasPressedThisFrame || Keyboard.current.rightCtrlKey.wasPressedThisFrame)
            {
                //キーボードのCtrlが押された瞬間を読み取る。

                inputField.text += "\n";
                //今入っている文字の最後に\nを直接書き込みします。

                inputField.caretPosition = inputField.text.Length;
                //改行した直後にすぐ文字を打てるように、カーソルを文章の最後へ強制移動させる。
            }
        }
    }

    public void InputText()
    {

        text.text = inputField.text;
        //入力欄に打ち込まれた全ての文字を、そのまま画面上の表示用テキストに上書きコピーします。

        Debug.Log("aaa" + inputField.text);
        //文字が保存・反映されたタイミングでUnityのコンソール画面に「aaa＋実際の文字」をログ出力する。
    }

}
