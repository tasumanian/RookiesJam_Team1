using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    private GameObject screen;
    [SerializeField]
    private SpriteRenderer sR;
    public SpriteRenderer SR { get { return sR; } }
    [SerializeField]
    private AudioClip SESound;
    [SerializeField]
    private AudioClip PopupSound;
    [SerializeField]
    private SoundManager soundManager;

    private int currentIndex = 0;
    private bool isTutorialStarted = false;
    private bool isTutorialEnded = false;
    private bool isTutorialMid = false;
    public void StartTutorial()
    {
        Panel.SetActive(true);
        NextText();
        soundManager.PlayBGM(0);

        SaveData.SaveProgress(-1);
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
            screen.SetActive(true);
            soundManager.PlaySE(PopupSound);
            soundManager.StopBGM();
            contexts.Add("<color=red>町外れの洋館で起きた化け物による殺人事件の解決</color>");
            contexts.Add("向かうとするか、、");
            contexts.Add("はげ");
            sR.sprite = Youkan;
            OpenPanel();
            isTutorialStarted = false;
            isTutorialMid = true;
        }
        if(isTutorialMid && currentIndex >= contexts.Count)
        {
            soundManager.StartBGM();
            screen.SetActive(false);
            Panel.SetActive(false);
            ariaMove.ChangeAria(6);
            StartCoroutine(Wait());

            isTutorialMid = false;
        }
        if (isTutorialEnded && dialog.IsEnd)
        {
            dialog.TextSet("調査を始めよう", "");
            soundManager.PlayBGM(1);
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
        soundManager.PlaySE(SESound);
        tutorialImage.SetActive(true);
    }

}
