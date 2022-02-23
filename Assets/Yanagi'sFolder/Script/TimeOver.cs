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

    private void Start()
    {
       countdown = 300.0f;
       TimeText.text = "0";
        gameover = false;
        GameOverText.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(countdown);
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
                //photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
            }
            if (Catch_Doctor.BoolCatch_Doctor) photonView.RPC(nameof(ChangeGameOver), RpcTarget.All);
        }
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
    }
}
