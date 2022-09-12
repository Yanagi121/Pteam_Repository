using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallCollisionDetection : MonoBehaviour { 
    GameObject wall;
    GameObject StageObject;
    public int ColDirectionNum;
    public bool ObjectCol=false;
    [SerializeField] GameObject Arrow;
    bool onetime;
    public enum ColDirection
    {
        NONE=0, //0
        FLONT=1,//1
        RIGHT=2,//2
        BACK=3, //3
        LEFT=4, //4
    }
    public static ColDirection col=(ColDirection)0;

    private void Start()
    {
        onetime = true;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "TestPlayScene"&&onetime==true)
        {
            Arrow = GameObject.FindGameObjectWithTag("Arrow");
            onetime = false;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("StageObject"))
        {
            ObjectCol = true;
            col = (ColDirection)ColDirectionNum;
        }
      if (other.gameObject.tag == "Arrow_col") Arrow.SetActive(false);
    
}
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wall")||other.gameObject.CompareTag("StageObject"))
        {
            ObjectCol = false;
            col = (ColDirection)0;
        }
       if (other.gameObject.tag == "Arrow_col") Arrow.SetActive(true);
    }
}
