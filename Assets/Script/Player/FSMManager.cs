using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    MOVE = 0,
    INVENTORY,
    QUIZ
}

[RequireComponent(typeof(PlayerStat))]
[ExecuteInEditMode]
public class FSMManager : MonoBehaviour
{
    private bool isinit = false;
    private Dictionary<PlayerState, PlayerFSM> states = new Dictionary<PlayerState, PlayerFSM>();
    public PlayerState startState = PlayerState.MOVE;

    [SerializeField]
    private PlayerState currentState;
    public PlayerState CurrentState { get { return currentState; } }

    public QuizKind quizKind { get; set; }

    private PlayerStat stat;
    public PlayerStat Stat { get { return stat; } }

    private int clickLayer;
    public int ClickLayer { get { return clickLayer; } }


    public bool[] gettingItem { get; set; }
    public int preTextBook;
    // Use this for initialization
    void Awake ()
    {
        gettingItem = new bool[7];
        for (int i = 0; i < 7; i++)
            gettingItem[i] = false;
        Cursor.visible = false;
        Cursor.visible = true;
        clickLayer = (1 << 9);
        stat = GetComponent<PlayerStat>();
        PlayerState[] statValues = (PlayerState[])System.Enum.GetValues(typeof(PlayerState));
        foreach(PlayerState s in statValues)
        {
            System.Type FSMType = System.Type.GetType("Player" + s.ToString());
            PlayerFSM state = (PlayerFSM)GetComponent(FSMType);
            if (null == state)
            {
                state = (PlayerFSM)gameObject.AddComponent(FSMType);
            }
            states.Add(s, state);
            state.enabled = false;
        }
        quizKind = QuizKind.LOCK;
        preTextBook = -1;
    }
	

    public void Start()
    {
        SetState(startState);
        isinit = true;
    }

    public void SetState(PlayerState newState)
    {
        if (isinit)
        {
            states[currentState].enabled = false;
            states[currentState].EndState();
        }
        currentState = newState;
        states[currentState].BeginState();
        states[currentState].enabled = true;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.visible = true;
        };
    }

}
