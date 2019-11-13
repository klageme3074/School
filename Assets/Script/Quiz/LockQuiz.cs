using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockQuiz : Quiz {
    bool[] pushedButton;
    bool[] answer;
    int count;
    int ButtonCount;
    private void Awake()
    {
        initQuize();
    }
    void initQuize()
    {
        count = 0;
        ButtonCount = 6;
        isClear = false;
        pushedButton = new bool[ButtonCount];
        answer = new bool[ButtonCount];

        for (int i = 0; i < ButtonCount; i++)
        {
            answer[i] = false;
            pushedButton[i] = false;
        }

        int answerSize = QuestManager.GetInstance().AnswerSize;
        for(int i = 0; i < answerSize; i++)
        {
            answer[QuestManager.GetInstance().Answer[i]-1] = true;
        }

    }

    public void GetLockClear()
    {
        count = 0;
        for(int i = 0; i < ButtonCount; i++)
        {
            if (answer[i] == pushedButton[i])
                count++;
        }

        if(count==ButtonCount)
            isClear = true;
    }

    public void PushButton1() { pushedButton[0] = pushedButton[0] ? false : true; }
    public void PushButton2() { pushedButton[1] = pushedButton[1] ? false : true; }
    public void PushButton3() { pushedButton[2] = pushedButton[2] ? false : true; }
    public void PushButton4() { pushedButton[3] = pushedButton[3] ? false : true; }
    public void PushButton5() { pushedButton[4] = pushedButton[4] ? false : true; }
    public void PushButton6() { pushedButton[5] = pushedButton[5] ? false : true; }

}
