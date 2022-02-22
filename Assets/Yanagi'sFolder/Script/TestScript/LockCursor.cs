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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        }else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            SoundSettingsUIObject.SetActive(false);
        }
      
    }
}
