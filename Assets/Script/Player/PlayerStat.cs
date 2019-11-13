using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour {
    [SerializeField]
    private float turnSpeed;
    public float TurnSpeed { get { return turnSpeed; } }
    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
    [SerializeField]
    private float runSpeed;
    public float RunSpeed { get { return runSpeed; } }
    [SerializeField]
    private float reserchDistance;
    public float ReserchDistance { get { return reserchDistance; } }

   
}
