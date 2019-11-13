using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSMManager))]
public class PlayerFSM : MonoBehaviour {

    protected FSMManager manager;

    private void Awake()
    {
        manager = GetComponent<FSMManager>();
    }

    public virtual void BeginState() { }

    public virtual void EndState() { }
}
