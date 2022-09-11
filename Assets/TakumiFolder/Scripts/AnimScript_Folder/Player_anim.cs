using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player_anim : MonoBehaviourPunCallbacks
{
    Animator animator;

    [SerializeField]
    public bool runControl;//走るかどうかを決める変数

    [SerializeField]
    public bool catchControl;//捕まえるかどうかを決める変数

    [SerializeField]
    public bool helpControl;//エモート1を決める変数
    [SerializeField]
    int emote_num;

    [SerializeField] 
    GameObject Player;

    private Rigidbody rb;

    float speed;
    Vector3 prepos;

    public enum State
    {
        Idle=0,
        Help=1,
        Thanks=2,
        Laugh = 3,
        Hoooo = 4
    }
    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //runControlの初期化
        runControl = false;
        //catchControlの初期化
        catchControl = false;
        helpControl = false;
        emote_num = 0;
    }

    void Update()
    {
        
         //speed = ((Player.transform.position - prepos) / Time.deltaTime).magnitude;
         //Invoke(nameof(PrePos_call), 0.1f);
         //if (speed > 1) runControl = true;
         //else runControl = false;
         //Debug.Log(speed);
         //   //ParipiAnimationControlないのrunControlがtrueかfalseかの判定
         MoveJudgment();
        
        
        if (photonView.IsMine)//photonView.IsMine
        {
            if (Input.GetKeyDown(KeyCode.Z)) animator.SetInteger("e_1", (int)State.Help);
            if (Input.GetKeyDown(KeyCode.X)) animator.SetInteger("e_1", (int)State.Thanks);
            if (Input.GetKeyDown(KeyCode.C)) animator.SetInteger("e_1", (int)State.Laugh);
            if (Input.GetKeyDown(KeyCode.V)) animator.SetInteger("e_1", (int)State.Hoooo);
            if (Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.X) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.V))
            {
                animator.SetInteger("e_1", (int)State.Idle);
                this.transform.position = Player.transform.position;
            }
            if (gameObject.tag != "Dr")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    catchControl = true;
                   
                }
                if (Input.GetMouseButtonUp(0))
                {
                    Invoke(nameof(catchControlTOFalse), 0.1f);
                    this.transform.position = Player.transform.position;
                }

                
                
            }
            
        }

        //AnimatorないのrunControlのtrue/falseの判定
        animator.SetBool("runControl", runControl);
        //AnimatorないのcatchControlのtrue/falseの判定
        animator.SetBool("catchControl", catchControl);

        animator.SetBool("HelpCotrol", helpControl);
        

    }

    public void catchControlTOFalse()
    {
        catchControl = false;
    }


    public void PrePos_call()
    {
        prepos = Player.transform.position;
    }

    //ParipiAnimationControlないのrunControlがtrueかfalseかの判定するメソッド
    public void MoveJudgment()
    {

        if (photonView.IsMine)//photonView.IsMine
        {
            if (Input.GetAxis("Horizontal") != 0) { runControl = true; }
            else { runControl = false; };
            if (Input.GetAxis("Vertical") != 0) { runControl = true; }
            else { runControl = false; };
            
            //if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){ runControl = true;}
            //else{runControl = false; }
            //if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")) { runControl = true; }
            //else { runControl = false; }
            
        }
    }
}
