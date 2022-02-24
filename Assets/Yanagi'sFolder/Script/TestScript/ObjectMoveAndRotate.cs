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
    [SerializeField] Vector3 CameraVectorRotate;
    [SerializeField] Vector3 PlayerVectorRotate;
    private string Camera;
    private GameObject Camera1;
    public static string PlayerName;
    [SerializeField] bool WaterSound=false,MakeSounds=false, InvokeDelay = true;
    [SerializeField] int a=0;
    private AudioSource RiverSound;
    [SerializeField] AudioClip audioClip1;
    //[SerializeField] AudioClip audioClip;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this.gameObject);
        RiverSound = gameObject.GetComponent<AudioSource>();
        RiverSound.clip = audioClip1;
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RoomSceneManager2.CameFind)
        {
            PlayerCamera = GameObject.FindGameObjectWithTag("Camera1");
            RoomSceneManager2.CameFind = false;
        }
        if (TimeOver.gameover==false&& CameraMove.TimeDelay)
        {


            if (photonView.IsMine)//photonView.IsMine
            {
                GetZ = Input.GetAxis("Horizontal") * addforce;
                GetX = Input.GetAxis("Vertical") * addforce;
                //CameraVector=PlayerCamera.transform;

                //�C���@�L�����N�^�[�E�J�����ړ��S�ʂ�����ň͂�������
                if (RoomSceneManager2.SceneEnter == true||TimeOver.gameover)//�Q�[���V�[���ɓ���O(�J�������擾����O����J���������邱�ƑO��ɓ����Ă���̂�if�ǉ�)
                {
                    CameraVectorRotate = PlayerCamera.transform.eulerAngles;
                    PlayerVectorRotate.y = CameraVectorRotate.y;
                }
            }
            
            this.gameObject.transform.eulerAngles = new Vector3(0, PlayerVectorRotate.y, 0);
        }else
        {
            GetX = 0;
            GetZ = 0;
        }
        if (WaterSound == true&&InvokeDelay==true&&(GetX>0||GetZ>0))
        {
            Invoke("PlaySESound", 0.50f);
            InvokeDelay = false;
            
        }
    }
    public void PlaySESound()
    {
        //RiverSound.Play();//Inspector����AudioClip1�ɓ����Ă���Ȃ��Đ����Ă���
        soundManager.PlaySeByName("hito_ge_aru_mizu02");//PlayBgmByName�Œ��ڃt�@�C�����������ĉ������E���Ă���H
        InvokeDelay = true;
        a++;
    }
    private void FixedUpdate()
    {
        
        
                rb.AddRelativeForce(Vector3.forward * GetX);
                rb.AddRelativeForce(Vector3.right * GetZ);
            
        

    }
    //[PunRPC]
    //private void RoomPlayerID(GameObject gameObject)
    //{
    //    Debug.Log("�v���C���[�l�[��:" + gameObject.name);
    //    Debug.Log("Porder:" + RoomSceneManager.Porder);
    //    gameObject.name = "Player" + RoomSceneManager.Porder;
    //}
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("River"))
        {
            WaterSound = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("River"))
        {
            WaterSound = false;
        }
    }
}
