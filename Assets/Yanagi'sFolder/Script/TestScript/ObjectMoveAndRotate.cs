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
    public static string PlayerName;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this.gameObject);
        // PlayerName = this.gameObject.name;
        // photonView.RPC(nameof(RoomID), RpcTarget.AllBuffered,this.gameObject.name);
        //if (this.gameObject.name == "Player1") PlayerCamera = GameObject.Find("Camera1");
        //else if (this.gameObject.name == "Player2") PlayerCamera = GameObject.Find("Camera2");
        //else if (this.gameObject.name == "Player3") PlayerCamera = GameObject.Find("Camera3");
        //else if (this.gameObject.name == "Player4") PlayerCamera = GameObject.Find("Camera4");
        //else { Debug.Log("�G���["); }
        //Debug.Log("���擾���܂���");
        //photonView.RPC(nameof(RoomPlayerID), RpcTarget.AllBuffered, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (RoomSceneManager2.CameFind)
        {
            PlayerCamera = GameObject.FindGameObjectWithTag("Camera1");
            RoomSceneManager2.CameFind = false;
        }
        if (Catch_Doctor.SetTime==false)
        {


            if (photonView.IsMine)//photonView.IsMine
            {
                GetZ = Input.GetAxis("Horizontal") * addforce;
                GetX = Input.GetAxis("Vertical") * addforce;
                //CameraVector=PlayerCamera.transform;

                //�C���@�L�����N�^�[�E�J�����ړ��S�ʂ�����ň͂�������
                if (RoomSceneManager2.SceneEnter == true)//�Q�[���V�[���ɓ���O(�J�������擾����O����J���������邱�ƑO��ɓ����Ă���̂�if�ǉ�)
                {
                    CameraVectorRotate = PlayerCamera.transform.eulerAngles;
                    PlayerVectorRotate.y = CameraVectorRotate.y;
                }
            }
            
            this.gameObject.transform.eulerAngles = new Vector3(0, PlayerVectorRotate.y, 0);
        }
    }
    private void FixedUpdate()
    {
        if (Catch_Doctor.SetTime == false)
        {
                rb.AddRelativeForce(Vector3.forward * GetX);
                rb.AddRelativeForce(Vector3.right * GetZ);
            }
        

    }
    //[PunRPC]
    //private void RoomPlayerID(GameObject gameObject)
    //{
    //    Debug.Log("�v���C���[�l�[��:" + gameObject.name);
    //    Debug.Log("Porder:" + RoomSceneManager.Porder);
    //    gameObject.name = "Player" + RoomSceneManager.Porder;
    //}
}
