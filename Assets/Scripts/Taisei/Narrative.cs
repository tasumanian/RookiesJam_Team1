using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Narrative : MonoBehaviour
{
    [SerializeField]
    private List<string> contexts;
    //地のふみ用のテキストリスト

    [SerializeField]
    private int cutTiming;
    //地のふみの切り替えタイミング

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private Dialog dialog;

    [SerializeField]
    private string[] tutorialTexts;
    //プレイヤーが喋る用のテキスト

    [SerializeField]
    private GameObject Panel;
    //地のふみのGameObj

    [SerializeField]
    private GameObject tutorialImage;
    //チュートリアル用画像

    [SerializeField]
    private AriaMove ariaMove;
    [SerializeField]
    private Sprite YoukanSprite;
    [SerializeField]
    private GameObject YoukanImage;
    [SerializeField]
    private SpriteRenderer sR;
    public SpriteRenderer SR { get { return sR; } }
    [SerializeField]
    private AudioClip SESound;
    //

    [SerializeField]
    private AudioClip PopupSound;
    //雷の音、館の表示時用

    [SerializeField]
    private SoundManager soundManager;
    //SEとBGMの管理

    [SerializeField]
    private TMP_FontAsset font;
    //変更用font

    private int currentIndex = 0;
    //contextsのindex

    private TutorialState State = TutorialState.NotReady;
    //フラグ管理をenum化
    private enum TutorialState
    {
        NotReady,
        Start,
        Mid,
        Ended
    }
    public void StartTutorial()
    {
        OpenPanel();
        //地のふみを表示
        soundManager.PlayBGM(0);
    }
    public void NextText()
    {
        if (State == TutorialState.NotReady) //世界観の説明
        {
            if (currentIndex < cutTiming) //カットタイミングまで
            {
                text.text = contexts[currentIndex];
                currentIndex++;
            }
            else
            {
                ClosePanel();
                currentIndex++;

                //キャラクターのしゃべるシーンへ
                dialog.TextListSet(tutorialTexts, "あなた");
                State = TutorialState.Start;
            }
        }
        else //Stateはmidのはず
        {
            if (currentIndex < contexts.Count) //カットタイミング以降
            {
                text.text = contexts[currentIndex];
                currentIndex++;
            }
            else
            {
                ClosePanel();
                //地のふみの終了
                soundManager.StartBGM();
                //BGMの再生
                YoukanImage.SetActive(false);
                //館の表示終了
                ariaMove.ChangeAria(6);
                //街中シーンへ移行
                StartCoroutine(Wait());

                State = TutorialState.NotReady;
            }
        }
    }
    public void ClosePanel() //地の文を閉じる
    {
        Panel.SetActive(false);
    }
    public void OpenPanel() //地の文を表示
    {
        Panel.SetActive(true);
        NextText();
    }
    private void Update()
    {
        if (!dialog.IsEnd || State == TutorialState.NotReady)
            return;

        if (State == TutorialState.Start)
        {
            YoukanImage.SetActive(true);
            //館の全画面表示および演出
            soundManager.PlaySE(PopupSound);
            soundManager.StopBGM();
            text.font = font;

            sR.sprite = YoukanSprite;
            //ゲーム用の画面も館にしておく

            OpenPanel();
            //地の文を表示

            State = TutorialState.Mid; //館表示後、操作説明へ
        }
        if (State == TutorialState.Ended)
        {
            SaveData.SaveProgress(-1); //進行度を保存

            dialog.TextSet("調査を始めよう", "");
            soundManager.PlayBGM(1);

            //捜査シーンへ
            ariaMove.ChangeAria(0);
            State = TutorialState.NotReady;
        }
    }
    public void EndTutorial() //操作説明終了
    {
        dialog.TextSet("着くようだな", "");
        State = TutorialState.Ended;
        //表示後、捜査シーンへ
        tutorialImage.SetActive(false);

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        //シーン変更まで待機

        soundManager.PlaySE(SESound);
        //街中の騒音っぽいやつ
        tutorialImage.SetActive(true);
        //操作説明の表示
    }

}
