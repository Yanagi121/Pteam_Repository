using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_eachColor : MonoBehaviour
{
    private bool onetime;
    //[SerializeField]GameObject[] Players_Surface;
    [SerializeField] Transform[] ParentPlayer = new Transform[4];
    MaterialColor materialColor;
    int i, j;
    void Start()
    {
        i = 0;
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "TestPlayScene")
        {
            switch (DontDestroy_Porder.Porder_handover)
            {
                case 1: j = 1; break;
                case 2: j = 2; break;
                case 3: j = 3; break;
                case 4: j = 4; break;
            }
            while (i < j)
            {
                ParentPlayer[i] = GameObject.Find("Player" + (i + 1) + "(Clone)").transform;
                i++;
            }


            switch (DontDestroy_Porder.Porder_handover)
            {
                case 1:
                    Debug.Log("PorderÇÕ:" + DontDestroy_Porder.Porder_handover);
                    var childtrans1 = ParentPlayer[0].GetComponentsInChildren<Transform>();
                    foreach (var item in childtrans1)
                    {
                        if (item.tag == "PlayerSurface")
                        {
                            materialColor = item.GetComponent<MaterialColor>();
                            materialColor.enabled = true;
                        }
                    }
                    break;
                case 2:
                    Debug.Log("PorderÇÕ:" + DontDestroy_Porder.Porder_handover);
                    var childtrans2 = ParentPlayer[1].GetComponentsInChildren<Transform>();
                    foreach (var item in childtrans2)
                    {
                        if (item.tag == "PlayerSurface")
                        {
                            materialColor = item.GetComponent<MaterialColor>();
                            materialColor.enabled = true;
                        }
                    }
                    break;
                case 3:
                    Debug.Log("PorderÇÕ:" + DontDestroy_Porder.Porder_handover);
                    var childtrans3 = ParentPlayer[2].GetComponentsInChildren<Transform>();
                    foreach (var item in childtrans3)
                    {
                        if (item.tag == "PlayerSurface")
                        {
                            materialColor = item.GetComponent<MaterialColor>();
                            materialColor.enabled = true;
                        }
                    }
                    break;
                case 4:
                    Debug.Log("PorderÇÕ:" + DontDestroy_Porder.Porder_handover);
                    var childtrans4 = ParentPlayer[3].GetComponentsInChildren<Transform>();
                    foreach (var item in childtrans4)
                    {
                        if (item.tag == "PlayerSurface")
                        {
                            materialColor = item.GetComponent<MaterialColor>();
                            materialColor.enabled = true;
                        }
                    }
                    break;
                default: Debug.Log("Porderà¯Ç´ìnÇµÉGÉâÅ[:" + DontDestroy_Porder.Porder_handover); break;
            }
            //mesh.enabled = false;

            onetime = false;
        }

    }
}
