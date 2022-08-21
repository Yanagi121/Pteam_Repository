using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Update : MonoBehaviour
{
    public void OnClicked()
    {
        SceneManager.LoadScene("LobbyScene");
    } 
}
