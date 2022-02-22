using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン切り替えのスクリプト
/// </summary>

//TODO:汎用性がない
public class SceneManager2 : MonoBehaviour
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
    //"GameOver",
    //"GameCrear"
    };

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName[number]);
    }

}