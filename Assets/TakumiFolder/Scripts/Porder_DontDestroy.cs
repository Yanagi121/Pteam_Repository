using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Porder_DontDestroy : MonoBehaviour
{
    public static int DontDestroy_Porder;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroy_Porder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroy_Porder = RoomSceneManager.Porder;
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name != "TestPlayScene"&& SceneManager.GetActiveScene().name != "LobbyScene")
        {
            Destroy(gameObject);
        }
    }
}
