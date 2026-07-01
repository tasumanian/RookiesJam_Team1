using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
public class Narrative : MonoBehaviour
{
    [SerializeField]
    private List<string> contexts;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Dialog dialog;
    [SerializeField]
    private string[] tutorialTexts;
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject tutorialImage;
    [SerializeField]
    private AriaMove ariaMove;
    [SerializeField]
    private Sprite Youkan;
    [SerializeField]
    private GameObject Screen;
    [SerializeField]
    private SpriteRenderer SR;
    private int currentIndex = 0;
    private bool isTutorialStarted = false;
    private bool isTutorialEnded = false;
    private bool isTutorialMid = false;
    private void Start()
    {
        NextText();
    }
    public void NextText()
    {
        if (currentIndex < contexts.Count)
        {
            text.text = contexts[currentIndex];
            currentIndex++;
        }
        else
        {
            ClosePanel();
            if(!isTutorialMid)
            Tutorial();
        }
    }
    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
    public void OpenPanel()
    {
        Panel.SetActive(true);
        NextText();
    }
    private void Tutorial()
    {
        dialog.TextListSet(tutorialTexts, "");
        isTutorialStarted = true;
    }
    private void Update()
    {
        if (isTutorialStarted && dialog.IsEnd)
        {
            Screen.SetActive(true);
            contexts.Add("<color=red>町外れの洋館で起きた化け物による殺人事件の解決</color>");
            contexts.Add("、、向かうとするか");
            contexts.Add("はげ");
            SR.sprite = Youkan;
            OpenPanel();
            isTutorialStarted = false;
            isTutorialMid = true;
        }
        if(isTutorialMid && currentIndex >= contexts.Count)
        {
            Screen.SetActive(false);
            Panel.SetActive(false);
            ariaMove.ChangeAria(6);
            StartCoroutine(Wait());

            isTutorialMid = false;
        }
        if (isTutorialEnded && dialog.IsEnd)
        {
            ariaMove.ChangeAria(0);
            isTutorialEnded = false;
        }
    }
    public void EndTutorial()
    {
        dialog.TextSet("着くようだな", "");
        isTutorialEnded = true;
        tutorialImage.SetActive(false);

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
      
        tutorialImage.SetActive(true);
    }

}
