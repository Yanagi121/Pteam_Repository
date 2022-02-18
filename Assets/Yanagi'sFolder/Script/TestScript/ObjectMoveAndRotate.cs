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
        Camera = "Camera"+photonView.OwnerActorNr;
        PlayerCamera = GameObject.Find(Camera);
        //Debug.Log("‚ðŽæ“¾‚µ‚Ü‚µ‚½");
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
