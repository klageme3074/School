using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerINVENTORY: PlayerFSM
{
    public GameObject inventory;
    public Text hintText1;
    public Text hintText2;
    public Text hintText3;
    public override void BeginState()
    {
        base.BeginState();
        inventory.SetActive(true);
        if (manager.gettingItem[0])
            hintText1.color = Color.white;
        if (manager.gettingItem[1])
            hintText2.color = Color.white;
        if (manager.gettingItem[2])
            hintText3.color = Color.white;
    }

    public override void EndState()
    {
        inventory.SetActive(false);
        base.EndState();
    }
    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape)) manager.SetState(PlayerState.MOVE);
    }

    public void setStateMove()
    {
        manager.SetState(PlayerState.MOVE);
    }
}