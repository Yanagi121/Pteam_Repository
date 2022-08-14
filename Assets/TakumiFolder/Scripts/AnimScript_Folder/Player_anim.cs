using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Player_anim : MonoBehaviourPunCallbacks
{
    Animator animator;

    [SerializeField]
    public bool runControl;//走るかどうかを決める変数

    [SerializeField] GameObject Player;
    private Rigidbody rb;

    float speed;
    Vector3 prepos;
    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //runControlの初期化
        runControl = false;
    }

    void Update()
    {
        speed = ((Player.transform.position - prepos) / Time.deltaTime).magnitude;
        Invoke(nameof(PrePos_call), 0.1f);
        if(speed>1) runControl = true;
        else runControl = false;
        Debug.Log(speed);
        //ParipiAnimationControlないのrunControlがtrueかfalseかの判定
        //MoveJudgment();

        //AnimatorないのrunControlのtrue/falseの判定
        animator.SetBool("runControl", runControl);
    }


    public void PrePos_call()
    {
        prepos = Player.transform.position;
    }

    //ParipiAnimationControlないのrunControlがtrueかfalseかの判定するメソッド
    public void MoveJudgment()
    {
        
        
        //if (Input.GetAxis("Horizontal") != 0) { runControl = true; }
        //else { runControl = false; };
        //if (Input.GetAxis("Vertical") != 0) { runControl = true; }
        //else { runControl = false; };

        /*
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){ runControl = true;}
        else{runControl = false; }
        if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")) { runControl = true; }
        else { runControl = false; }
        */
    }
}
