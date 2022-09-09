using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionDetection : MonoBehaviour { 
    GameObject wall;
    GameObject StageObject;
    public int ColDirectionNum;
    public bool ObjectCol=false;
    public enum ColDirection
    {
        NONE=0, //0
        FLONT=1,//1
        RIGHT=2,//2
        BACK=3, //3
        LEFT=4, //4
    }
    public static ColDirection col=(ColDirection)0;
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("StageObject"))
        {
            ObjectCol = true;
            col = (ColDirection)ColDirectionNum;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wall")||other.gameObject.CompareTag("StageObject"))
        {
            ObjectCol = false;
            col = (ColDirection)0;
        }
    }
}
