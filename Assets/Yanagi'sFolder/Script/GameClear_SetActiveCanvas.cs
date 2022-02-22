using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear_SetActiveCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameClearCanvasObject;
    public GameObject GameOverCanvasOvject;
    [SerializeField] bool DelayGameBool,booltmp;
    [SerializeField] float DelayGameFloat;
    void Start()
    {
        
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
                    GameClearCanvasObject.SetActive(true);
                else
                    GameOverCanvasOvject.SetActive(true);
                LockCursor.OnClickEscape = true;
            }
        }
    }
    void DelayGame()
    {
        DelayGameBool = true;
    }
}
