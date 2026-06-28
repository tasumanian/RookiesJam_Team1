using UnityEngine;


[CreateAssetMenu(fileName = "CreateDebate", menuName = "ScriptableObject/Debate")]
public class Debate : ScriptableObject
{
    [SerializeField]
    private string statement;
    public string Statement
    {
        get { return statement; }
    }
    [SerializeField]
    private string speaker;
    public string Speaker
    {
        get { return speaker; }
    }
    [SerializeField]
    private DebateAction actionType;
    public DebateAction ActionType
    {
        get { return actionType; }
    }
    [SerializeField]
    private string[] choiceText = new string[4];
    public string[] ChoiceText
    {
        get { return choiceText; }
    }
    [SerializeField]
    private int answerChoice;
    public int AnswerChoice
    {
        get { return answerChoice; }
    }
    [SerializeField]
    private Item answerItem;
    public Item AnswerItem
    {
        get { return answerItem; }
    }
}
public enum DebateAction
{
    choice,
    selectitem

}