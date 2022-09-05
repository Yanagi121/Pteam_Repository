using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    [SerializeField] GameObject GameCharactor;
    [SerializeField] Vector3 vectorCharactor;
    [SerializeField] Vector3 rotateCharactor;

    // Start is called before the first frame update
    void Start()
    {
        GameCharactor = GameObject.Find("Player"+ DontDestroy_Porder.Porder_handover + "(Clone)");
        Debug.Log("get:"+GameCharactor.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("get:" + GameCharactor.transform.position);
        vectorCharactor = GameCharactor.transform.position;
        rotateCharactor = GameCharactor.transform.eulerAngles;
        rotateCharactor.x = 90;
        vectorCharactor.y = 134;
        this.transform.eulerAngles = rotateCharactor;
        this.transform.position = vectorCharactor;
    }
}
