using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBookQuiz : Quiz
{
    public Text text;
    int answer;
    FSMManager manager;
    private void Awake()
    {
        answer = (int)itemCode.ENDINGTEXTBOOK;
        manager = GetComponentInParent<FSMManager>();
    }

    public void getClearButton()
    {
        if (manager.CurrentState == PlayerState.QUIZ)
        {
            if (manager.preTextBook == answer)
            {
                text.text = "게임끝!";
            }
            else if (manager.preTextBook == -1)
            {
                text.text = "교과서없음";
            }
            else if (manager.preTextBook == -2)
            {
                text.text = "이거아님";
                manager.preTextBook = -1;
            }
        }
    }
}
