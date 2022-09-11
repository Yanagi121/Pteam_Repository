using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

/// <summary>
/// シーン切り替えのスクリプト
/// </summary>

//TODO:汎用性がない
public class SceneManager2 : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int number = 0;
    [SerializeField]
    List<string> sceneName = new List<string>
    {
    "Movie",
    "Title",
    "Tutorial",
    "SettingOption",
    "LanguageSetting",
    "Credit",
    "ModeSelect",
    "LobbyScene",
    "ResolutionSetting",
    //"MemberWaitScreen",
    "SoundSetting",
    "NewRoom",
    "LoadScene"
    //"GameOver",
    //"GameCrear"
    };

    public void LoadScene()
    {
        PhotonNetwork.IsMessageQueueRunning = false;
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(sceneName[number]);

    }
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName[number]);
    }

}