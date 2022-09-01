using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameClear_SetActiveCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameClearCanvasObject;
    public GameObject GameOverCanvasOvject;
    [SerializeField] bool DelayGameBool,booltmp;
    [SerializeField] float DelayGameFloat;

    SoundManager soundManager;
    void Start()
    {
        GameOverCanvasOvject.SetActive(false);
        GameClearCanvasObject.SetActive(false);
        soundManager = GameObject.Find("GameControl").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (TimeOver.gameover == true &&booltmp==false)
         {
             Invoke("DelayGame", DelayGameFloat);
             booltmp = true;
         }
         /*if (TimeOver.gameover == true && Catch_Doctor.BoolCatch_Doctor && DelayGameBool)
         {
             GameClearCanvasObject.SetActive(true);
             LockCursor.OnClickEscape = true;
         }
         else if (TimeOver.gameover == true && Catch_Doctor.BoolCatch_Doctor == false && DelayGameBool)
         {
             GameOverCanvasOvject.SetActive(true);
             LockCursor.OnClickEscape = true;
         }*/
        if (TimeOver.gameover == true)
        {
            if(booltmp == false)
            {
                Invoke("DelayGame", DelayGameFloat);
                booltmp = true;
            }
            if ( DelayGameBool)
            {
                if (Catch_Doctor.BoolCatch_Doctor)
                {
                    soundManager.StopSe();//SE‚ðŽ~‚ß‚é
                    GameClearCanvasObject.SetActive(true);
                    if (PhotonNetwork.IsMasterClient)
                    {
                        PhotonNetwork.LeaveRoom();
                    }
                }
                else
                {
                    soundManager.StopSe();//SE‚ðŽ~‚ß‚é
                    GameOverCanvasOvject.SetActive(true);
                    LockCursor.OnClickEscape = true;
                    PhotonNetwork.LeaveRoom();
                }
            }
        }
    }
    void DelayGame()
    {
        DelayGameBool = true;
        //PhotonNetwork.LoadLevel("Sato_GameClear");//ƒNƒŠƒAŽž‚Ì‚Ý
    }
}
