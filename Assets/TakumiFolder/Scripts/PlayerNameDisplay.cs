using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNameDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]GameObject Text_oppose;
    private TextMeshProUGUI playername;
    // Start is called before the first frame update
    void Start()
    {
        playername =GetComponent<TextMeshProUGUI>();
        //playername.text = $"{photonView.Owner.NickName}({photonView.OwnerActorNr})";
        playername.text = $"{photonView.OwnerActorNr}";
    }

    // Update is called once per frame
    void Update()
    {
        playername.text = $"{photonView.Owner.NickName}";
        Text_oppose.transform.LookAt(GameObject.Find("Camera1").transform.position);
        //transform.rotation = Quaternion.Euler(0,180,0);
    }
}
   
