using UnityEngine;
using System.Collections;


public class ParipiAnimationControl : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool runControl;//走るかどうかを決める変数


    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //runControlの初期化
        runControl = false;
    }

    void Update()
    {
        //ParipiAnimationControlないのrunControlがtrueかfalseかの判定
        MoveJudgment();

        //AnimatorないのrunControlのtrue/falseの判定
        animator.SetBool("runControl", runControl);
    }

    //ParipiAnimationControlないのrunControlがtrueかfalseかの判定するメソッド
    public void MoveJudgment()
    {
        if(Input.GetAxis("Horizontal")!=0) { runControl = true; }
        else { runControl = false; };
        if (Input.GetAxis("Vertical") != 0) { runControl = true; }
        else { runControl = false; };
        /*
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")){ runControl = true;}
        else{runControl = false; }
        if (Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("right")) { runControl = true; }
        else { runControl = false; }
        */
    }
}
