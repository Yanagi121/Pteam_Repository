using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class DrAnimationControl : MonoBehaviour
{
    Animator animator;
    NavMeshAgent m_navMeshAgent; // NavMeshAgent

    [SerializeField]
    public bool runControl;//走るかどうかを決める変数


    void Start()
    {
        // NavMeshAgentコンポーネントを取得
        m_navMeshAgent = GetComponent<NavMeshAgent>();

        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //runControlの初期化
        runControl = false;
    }

    void Update()
    {
        //DrAnimationControlないのrunControlがtrueかfalseかの判定
        MoveJudgment();

        //AnimatorないのrunControlのtrue/falseの判定
        animator.SetBool("runControl", runControl);
    }

    //DrAnimationControlないのrunControlがtrueかfalseかの判定するメソッド
    public void MoveJudgment()
    {
        // NavMeshが準備できているなら
        if (m_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) { runControl = true; }
        else { runControl = false; }
    }
}
