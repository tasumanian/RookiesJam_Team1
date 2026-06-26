using UnityEngine;
using TMPro;

public class SkipGuideScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI guideText;
    // 文字を登録する場所。

    public void ShowSkipGuide()
    // 文字を表示する処理。
    {
        guideText.text = "Spaceをおしてスキップ";
    }

    public void ShowNextGuide()
    // 上に同様
    {
        guideText.text = "クリックしてつぎへ";
    }

    public void ShowEndGuide()
    // 上に同様
    {
        guideText.text = "";
    }
}
