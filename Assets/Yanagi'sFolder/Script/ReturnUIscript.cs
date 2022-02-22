using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnUIscript : MonoBehaviour
{
    public GameObject ReturnUIObject;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickReturnUIObject()
    {        
        ReturnUIObject.SetActive(false);
        LockCursor.OnClickEscape = true;


    }
}
