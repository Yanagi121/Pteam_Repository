using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetection : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("FallDetection"))
        {

            player.transform.position=new Vector3(150, 100, 200);
            Debug.Log("get:" + player.transform.position);
        }

    }
}
