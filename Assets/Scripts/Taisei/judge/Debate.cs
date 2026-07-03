using UnityEngine;


[CreateAssetMenu(fileName = "CreateDebate", menuName = "ScriptableObject/Debate")]
public class Debate : ScriptableObject
{
    //先にしゃべる言葉
    [SerializeField]
    [TextArea(5,5)]
    private string statement;
    public string Statement
    {
        get { return statement; }
    }
    //会話者
    [SerializeField]
    private string speaker;
    public string Speaker
    {
        get { return speaker; }
    }
    //アクションタイプ、アイテムを提示するか、四択から選択
    [SerializeField]
    private DebateAction actionType;
    public DebateAction ActionType
    {
        get { return actionType; }
    }
    //四択の選択肢、アイテム提示の時は設定しない
    [SerializeField]
    private string[] choiceText = new string[4];
    public string[] ChoiceText
    {
        get { return choiceText; }
    }
    //四択の正解番号、アイテム提示の時は設定しない
    [SerializeField]
    private int answerChoice;
    public int AnswerChoice
    {
        get { return answerChoice; }
    }
    //アイテム提示の正解アイテム、四択の場合は設定しない
    [SerializeField]
    private Item answerItem;
    public Item AnswerItem
    {
        get { return answerItem; }
    }
    //選択後の会話
    [SerializeField]
    [TextArea(5, 5)]
    private string answerText;
    public string AnswerText
    {
        get { return answerText; }
    }
}
public enum DebateAction
{
    choice,
    selectitem

}