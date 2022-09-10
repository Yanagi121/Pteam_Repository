using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Result_PlayerName : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] playername;
    [SerializeField] TextMeshProUGUI[] result_players;
    
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (GameObject.FindWithTag("Player" + (i+1) + "Name"))
            {
                playername[i] = GameObject.FindWithTag("Player" +( i+1) + "Name").GetComponent<TextMeshProUGUI>();
            }
            
        }


        for (int i = 0; i < 4; i++)
        {
            if (GameObject.FindWithTag("Player" + (i + 1) + "Name"))
            {
                result_players[i].text = playername[i].text;
            }
            Debug.Log(result_players[i].text.ToString());
        }
        

    }

}
