using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TimeOver : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    //カウントダウン
    public static float countdown;
    int IntNum;
    [SerializeField] bool setactiveUI;
    public static bool gameover;
    public TextMeshProUGUI TimeText;
    public GameObject GameOverText;
    [SerializeField] GameObject TimeTextGameObject;

    [SerializeField] GameObject Score_gameobject;//オブジェクトの位置でスコアを計算
    [SerializeField] Vector3 ScoreObj_trans;
    

    private void Start()
    {
       countdown = 180f; 
       ScoreObj_trans = new Vector3(countdown, 0,0);
       Score_gameobject.transform.position = ScoreObj_trans;
       TimeText.text = "0";
       gameover = false;
       GameOverText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        ScoreObj_trans = new Vector3(countdown, 0, 0);
        Score_gameobject.transform.position = ScoreObj_trans;
        //Debug.Log(countdown);
        if (CameraMove.TimeDelay)
            setactiveUI = true;

        if (setactiveUI == false)
            TimeTextGameObject.SetActive(false);
        else
            TimeTextGameObject.SetActive(true);


        if (CameraMove.TimeDelay)
        {
            
            if (countdown > 0)
                countdown -= Time.deltaTime;
            else
            {
                countdown = 0;
                gameover = true;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                //photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
            }
            if (Catch_Doctor.BoolCatch_Doctor)
            {
                photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
                GameObject.Find("Camera1").transform.LookAt(Vector3.Lerp(GameObject.Find("Camera1").transform.position, GameObject.Find("Dr_Invisible ").transform.position+new Vector3(0,2,0), 0.01f));
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
            }
        }
        //else GameObject.Find("Camera1").transform.LookAt(Vector3.Lerp(GameObject.Find("Camera1").transform.position, GameObject.Find("Dr_Invisible ").transform.position, 0.05f));

        IntNum = (int)countdown;
        TimeText.text = (IntNum / 60).ToString("0") + " : " + (IntNum % 60).ToString("00");
        if (TimeOver.gameover == true)
            GameOverText.SetActive(true);
    }
        [PunRPC]
    void ChangeGameOver()
    {
        CameraMove.TimeDelay = false;
        TimeOver.gameover = true;
        Catch_Doctor.BoolCatch_Doctor = true;
        GameObject.Find("Camera1").transform.LookAt(Vector3.Lerp(GameObject.Find("Camera1").transform.position, GameObject.Find("Dr_Invisible ").transform.position + new Vector3(0, 2, 0), 0.01f));
        //GameObject.Find("Camera1").transform.rotation= Quaternion.Slerp(GameObject.Find("Camera1").transform.rotation,GameObject.Find("Dr_Invisible ").transform.rotation,20f);

        Debug.Log("捕まえました1");

    }
}
