
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Catch_Doctor : MonoBehaviourPunCallbacks
{
    public float SlowTime=1;
    public static bool CatchDr;
    public List<float> GetTime;
    public static bool BoolCatch_Doctor;
    [SerializeField] bool OnClickButton=false;
        // Start is called before the first frame update
    void Start()
    {
        BoolCatch_Doctor = false;

        //this.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -360);
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClickButton = true;
        }
        if (OnClickButton == true)
            Invoke("boolClickButton", 0.5f);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Dr") && OnClickButton ==true /* && Input.GetMouseButtonDown(0) */ )
        {
            //photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
            /*CameraMove.TimeDelay=false;
            TimeOver.gameover = true;*/
            //photonView.RPC(nameof(CameraLook), RpcTarget.All);
            BoolCatch_Doctor = true;
            GetTime.Add(TimeOver.countdown);
            Invoke("SceneEnterBool", 2f);
           // PhotonNetwork.Disconnect();
        }
    }

    private void boolClickButton()
    {
        OnClickButton = false;
    }

    void SceneEnterBool()
    {
        RoomSceneManager2.SceneEnter = false;
       // PhotonNetwork.LoadLevel("Sato_GameClear");
       // SceneManager.LoadScene("GameCrear");
    }
    // [PunRPC]
    /*void ChangeGameOver()
    {
        CameraMove.TimeDelay = false;
        TimeOver.gameover = true;
    }*/
    [PunRPC]
    void CameraLook()
    {
        GameObject.Find("Camera1").transform.LookAt(GameObject.FindWithTag("Dr").transform.position);
    }
}
