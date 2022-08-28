using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy_Porder : MonoBehaviour
{
    public static int Porder_handover;
    void Start()
    {
        Porder_handover = 0;
    }

    
    void Update()
    {
        Porder_handover = RoomSceneManager.Porder;
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name != "TestPlayerScene" && SceneManager.GetActiveScene().name != "LobbyScene")
        {
            Destroy(gameObject);
        }
    }
}
