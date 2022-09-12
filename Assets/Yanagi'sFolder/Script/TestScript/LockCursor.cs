using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour
{
    public GameObject SoundSettingsUIObject;
    
    public static bool OnClickEscape;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SoundSettingsUIObject.SetActive(false);
        OnClickEscape = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& Pre_StartCountdown.lockedEscKey)
        {
            /*  Cursor.visible = true;
              Cursor.lockState = CursorLockMode.None;*/
            if (OnClickEscape)
                OnClickEscape = false;
            else
                OnClickEscape = true;
        }
        if(OnClickEscape)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SoundSettingsUIObject.SetActive(true);
        }
        else if(OnClickEscape==false&& Catch_Doctor.BoolCatch_Doctor==false&&TimeOver.gameover==false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            SoundSettingsUIObject.SetActive(false);
        }
        if (Catch_Doctor.BoolCatch_Doctor == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
      
    }
}
