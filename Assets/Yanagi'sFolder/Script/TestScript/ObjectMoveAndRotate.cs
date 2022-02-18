using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveAndRotate : MonoBehaviourPunCallbacks
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float thrust=0,addforce,GetX,GetZ;
    [SerializeField] bool Moveforward, MoveBack, MoveLeft, MoveRight;
    [SerializeField] GameObject PlayerCamera;
    //[SerializeField] Transform CameraVector;
    [SerializeField] Vector3 CameraVectorRotate;
    [SerializeField] Vector3 PlayerVectorRotate;
    private string Camera;
    private GameObject Camera1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this.gameObject);
        if (this.gameObject.name == "Player1") PlayerCamera = GameObject.Find("Camera1");
        else if (this.gameObject.name == "Player2") PlayerCamera = GameObject.Find("Camera2");
        else if (this.gameObject.name == "Player3") PlayerCamera = GameObject.Find("Camera3");
        else if (this.gameObject.name == "Player4") PlayerCamera = GameObject.Find("Camera4");
        else { Debug.Log("ÉGÉâÅ["); }
        //Debug.Log("ÇéÊìæÇµÇ‹ÇµÇΩ");
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)//photonView.IsMine
        {
            GetZ = Input.GetAxis("Horizontal") * addforce;
            GetX = Input.GetAxis("Vertical") * addforce;
            //CameraVector=PlayerCamera.transform;
            CameraVectorRotate = PlayerCamera.transform.eulerAngles;
            PlayerVectorRotate.y = CameraVectorRotate.y;
            this.gameObject.transform.eulerAngles = new Vector3(0, PlayerVectorRotate.y, 0);
        }
    }
    private void FixedUpdate()
    {
        if (photonView.IsMine)//photonView.IsMine
        {
            rb.AddRelativeForce(Vector3.forward * GetX);
            rb.AddRelativeForce(Vector3.right * GetZ);
        }
    }
}
