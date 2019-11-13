using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuizKind
{
    LOCK = 0,
    TEXTBOOK
}

public class QuestManager : MonoBehaviour {

    [SerializeField]
    int[] answer;
    public int[] Answer { get { return answer; } }
    [SerializeField]
    string[] hint;
    public string[] Hint { get { return hint; } }

    int answerSize;
    public int AnswerSize { get { return answerSize; } }

    public Text HintText;

    int hintSize;
    public int HintSize { get { return hintSize; } }

    public FSMManager manager;

    private static QuestManager instance;
    public static QuestManager GetInstance() { return instance; }


    private void Awake()
    {
        instance = this;
        hintSize = 3;
        answerSize = hintSize;
        HintText.text = " ";
    }

    public void SetHint1()
    {
        if (manager.gettingItem[0])
            HintText.text = hint[0];
    }

    public void SetHint2()
    {
        if (manager.gettingItem[1])
            HintText.text = hint[1];
    }

    public void SetHint3()
    {
        if (manager.gettingItem[2])
            HintText.text = hint[2];
    }
    
}
