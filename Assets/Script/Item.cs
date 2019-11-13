using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    [SerializeField]
    itemCode code;
    public itemCode Code { get { return code; } set { code = value; } }
    string hint;
    public string Hint { get { return hint; } }
    int answer;
    public int Answer { get { return answer; } }

    public void InitItem()
    {
        int size = ItemManager.GetInstance().ItemSize;
        int hintSize = ItemManager.GetInstance().HintSize;
        for(int i = 0; i < size; i++)
        {
            if (i < hintSize && code == (itemCode)i)
            {
                hint = QuestManager.GetInstance().Hint[i];
                answer = QuestManager.GetInstance().Answer[i];
            }
        }
    }
}
