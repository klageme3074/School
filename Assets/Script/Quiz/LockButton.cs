using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LockButton : MonoBehaviour {
    bool isPushed;
    private void Awake()
    {
        isPushed = false;
    }
    public void ClickButton()
    {
        if (!isPushed)
        {
            GetComponent<Image>().color = new Color(0, 0, 0);
            isPushed = true;
        }
        else
        {
            GetComponent<Image>().color = new Color(1, 1, 1);
            isPushed = false;
        }

    }
}
