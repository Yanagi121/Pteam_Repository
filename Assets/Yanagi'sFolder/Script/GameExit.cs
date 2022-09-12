using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        ExitGameShortcutKey();
    }

    void ExitGameShortcutKey()
    {
        if (Input.GetKey(KeyCode.K)&&Input.GetKey(KeyCode.I))
        {
            Application.Quit();
        }
    }

    void ExitGameButton()
    {
        Application.Quit();
    }
}
