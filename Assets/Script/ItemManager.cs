using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemCode
{
    HINT1 = 0,
    HINT2,
    HINT3,
    LETTER,
    ENDINGTEXTBOOK,
    TEXTBOOK
}

public class ItemManager : MonoBehaviour
{
    int itemSize;
    public int ItemSize { get { return itemSize; } }

    int hintSize;
    public int HintSize { get { return hintSize; } }
    
    public Item[] items;
    private static ItemManager instance;
    public static ItemManager GetInstance()
    {
        return instance;
    }


    private void Awake()
    {
        instance = this;
        itemSize = 7;
        hintSize = 3;
        init();
    }

    void init()
    {
        for (int i = 0; i < itemSize; i++)
            items[i].Code = (itemCode)i;
        items[6].Code = itemCode.TEXTBOOK;
        for (int i = 0; i < itemSize; i++)
        {
            items[i].InitItem();
            items[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
       
    }


}
