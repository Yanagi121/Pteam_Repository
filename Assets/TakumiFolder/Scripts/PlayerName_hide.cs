using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerName_hide : MonoBehaviour
{
    private bool onetime;
    void Start()
    {
        onetime = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TestPlayScene")
        {
            if (gameObject.name == "Player" + RoomSceneManager.Porder + "(Clone)")
            {
                GameObject canvas = transform.Find("Canvas").gameObject;
                canvas.SetActive(false);
                onetime = false;
            }
        }
    }
}
