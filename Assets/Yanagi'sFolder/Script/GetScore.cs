using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetScore : MonoBehaviour
{
    public Text GameClearScoreText;
    public Text GameOverScoreText;
    int Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Score = (int)TimeOver.countdown;
        GameClearScoreText.text = (15* TimeOver.countdown).ToString("N0") +"  point";
        GameOverScoreText.text = "0  point";
    }
}
