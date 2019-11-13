using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerQUIZ : PlayerFSM
{
    int quizIndex;
    LockQuiz lockQuiz;
    public GameObject LockQuizUI;
    public GameObject TextBookQuizUI;
    public Text text;
    private void Awake()
    {
        lockQuiz = GetComponentInChildren<LockQuiz>();
        
    }

    public override void BeginState()
    {
        base.BeginState();
        text.text = " ";
        if (manager == null)
            manager = GetComponent<FSMManager>();
        if (manager.quizKind == QuizKind.LOCK)
        {
            LockQuizUI.SetActive(true);
        }
        else if (manager.quizKind == QuizKind.TEXTBOOK)
        {
            TextBookQuizUI.SetActive(true);
        }
    }

    public override void EndState()
    {
        base.EndState();
        LockQuizUI.SetActive(false);
        TextBookQuizUI.SetActive(false);
    }

    private void Update()
    {
        if (manager.quizKind == QuizKind.LOCK)
        {
            if (lockQuiz.isClear)
            {
                //퀴즈를 풀었다면. 나중에 손볼필요있음
                manager.quizKind = QuizKind.TEXTBOOK;
                manager.gettingItem[(int)itemCode.LETTER] = true;
                Destroy(GetComponent<PlayerMOVE>().lockQuizObj.gameObject);
                manager.SetState(PlayerState.MOVE);
            }
        }
    }

    public void Cancel()
    {
        manager.SetState(PlayerState.MOVE);
    }
}
