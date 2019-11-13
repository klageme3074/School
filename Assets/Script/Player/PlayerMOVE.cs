using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMOVE : PlayerFSM {
    
    Rigidbody myRigidbody;
    Camera camera;
    public GameObject lockQuizObj;
    public GameObject textBookQuizObj;
    // Use this for initialization
    public override void BeginState()
    {
        base.BeginState();
        myRigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        Cursor.visible = false;
    }

    public override void EndState()
    {
        base.EndState();
        Cursor.visible = true;
    }

    public void Move()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * manager.Stat.MoveSpeed;
        //달리기
        if (Input.GetKey(KeyCode.LeftShift)) moveVelocity = moveInput.normalized * manager.Stat.RunSpeed;
        
        transform.Translate(Vector3.forward * moveVelocity.z * Time.deltaTime);
        transform.Translate(Vector3.right * moveVelocity.x * Time.deltaTime);

        myRigidbody.velocity = Vector3.zero;
    }

    public void LookAt()
    {
         Vector3 LookX = new Vector3(0, Input.GetAxis("Mouse X"), 0);
         transform.Rotate(LookX * manager.Stat.TurnSpeed);
        
         Vector3 LookY = new Vector3(Input.GetAxis("Mouse Y"), 0, 0);
         camera.transform.Rotate(-LookY * manager.Stat.TurnSpeed);
    }
    

    public void FixedUpdate()
    {
        Move();
        LookAt();
        ReserchItem();
        ReserchQuiz();
        if (Input.GetKeyDown(KeyCode.I))
        {
            QuestManager.GetInstance().HintText.text = " ";
            manager.SetState(PlayerState.INVENTORY);
        }

    }

    void ReserchItem()
    {
        int itemCount = ItemManager.GetInstance().ItemSize;
        int hintCount = ItemManager.GetInstance().HintSize;
        
        for (int i = 0; i < itemCount; i++)
        {
            if (ItemManager.GetInstance().items[i] != null)
            {
                if (Vector3.Distance(ItemManager.GetInstance().items[i].transform.position, transform.position) < manager.Stat.ReserchDistance)
                {
                    //여기에 아이템 먹을수 있다 ui 추가
                    ItemGetUIDraw(i);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (i < hintCount && manager.quizKind == QuizKind.LOCK)//먹은 아이템이 힌트면 ui의 텍스트 변경 후 인벤토리를 열어줌
                        {
                            QuestManager.GetInstance().HintText.text = QuestManager.GetInstance().Hint[i];
                            manager.gettingItem[i] = true;
                            manager.SetState(PlayerState.INVENTORY);
                            Destroy(ItemManager.GetInstance().items[i].gameObject);
                        }
                        else if (manager.quizKind == QuizKind.TEXTBOOK)
                        {
                            if (manager.preTextBook == -1)
                            {
                                if (i == (int)itemCode.ENDINGTEXTBOOK)
                                    manager.preTextBook = (int)itemCode.ENDINGTEXTBOOK;
                                else if (i == (int)itemCode.LETTER)
                                    Debug.Log("편지먹음");
                                else
                                    manager.preTextBook = -2;
                                manager.gettingItem[i] = true;
                                Destroy(ItemManager.GetInstance().items[i].gameObject);
                            }
                        }
                    }
                }
                //거리내에 없으면 아이템 ui안보여줌
                else 
                    ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
    }
    

    void ReserchQuiz()
    {
        //Quiz
        if (lockQuizObj != null&&manager.quizKind==QuizKind.LOCK)
        {
            if (Vector3.Distance(lockQuizObj.transform.position, transform.position) < manager.Stat.ReserchDistance)
            {
                lockQuizObj.GetComponentInChildren<SpriteRenderer>().transform.rotation = camera.transform.rotation;
                lockQuizObj.GetComponentInChildren<SpriteRenderer>().transform.position = (lockQuizObj.transform.position + camera.transform.position) / 2f;
                lockQuizObj.GetComponentInChildren<SpriteRenderer>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    manager.SetState(PlayerState.QUIZ);
                }
            }
            else
                lockQuizObj.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

        if (textBookQuizObj != null&&manager.quizKind == QuizKind.TEXTBOOK)
        {
            if (Vector3.Distance(textBookQuizObj.transform.position, transform.position) < manager.Stat.ReserchDistance)
            {
                textBookQuizObj.GetComponentInChildren<SpriteRenderer>().transform.rotation = camera.transform.rotation;
                textBookQuizObj.GetComponentInChildren<SpriteRenderer>().transform.position = (textBookQuizObj.transform.position + camera.transform.position) / 2f;
                textBookQuizObj.GetComponentInChildren<SpriteRenderer>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    manager.SetState(PlayerState.QUIZ);
                }
            }
            else
                textBookQuizObj.GetComponentInChildren<SpriteRenderer>().enabled = false;
        }

    }

    void ItemGetUIDraw(int i)
    {
        int hintCount = ItemManager.GetInstance().HintSize;
        if (i < hintCount && manager.quizKind == QuizKind.LOCK)
        {
            ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
            ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().transform.position = (ItemManager.GetInstance().items[i].transform.position + camera.transform.position) / 2f;
            ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().transform.rotation = camera.transform.rotation;
        }
        else if(manager.quizKind == QuizKind.TEXTBOOK)
        {
            ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().enabled = true;
            ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().transform.position = (ItemManager.GetInstance().items[i].transform.position + camera.transform.position) / 2f;
            ItemManager.GetInstance().items[i].GetComponentInChildren<SpriteRenderer>().transform.rotation = camera.transform.rotation;
        }
    }
    

}
