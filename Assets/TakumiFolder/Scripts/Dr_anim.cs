using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dr_anim : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    public bool Dr_runControl;//走るかどうかを決める変数

    [SerializeField]
    public bool Dr_catchControl;//捕まえるかどうかを決める変数

    [SerializeField]
    GameObject Dr;

    float speed;
    Vector3 prepos;
    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //runControlの初期化
        Dr_runControl = false;
        //catchControlの初期化
        Dr_catchControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        speed = ((Dr.transform.position - prepos) / Time.deltaTime).magnitude;
        Invoke(nameof(PrePos_call), 0.1f);
        if (speed > 1) Dr_runControl = true;
        else Dr_runControl = false;
        Debug.Log(speed);
        //ParipiAnimationControlないのrunControlがtrueかfalseかの判定
        //AnimatorないのrunControlのtrue/falseの判定
        animator.SetBool("runControl", Dr_runControl);
    }
    public void PrePos_call()
    {
        prepos = Dr.transform.position;
    }
}
