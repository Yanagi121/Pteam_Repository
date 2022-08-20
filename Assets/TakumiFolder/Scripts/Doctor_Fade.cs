using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor_Fade : MonoBehaviour
{
    MeshRenderer mesh;
    [SerializeField] GameObject Doctor;
    int i = 0;
    bool Fade_judge;
    void Start()
    {
        mesh = Doctor.GetComponent<MeshRenderer>();
        mesh.material.color = new Color32(255,0,0,0);
        //StartCoroutine("Fade");
        Fade_judge = false;
    }


    void Update()
    {
        if (Fade_judge==true)
        {
            if (i < 255)
            {
                mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);
                i++;
            }
            else if(255<=i&&i<510)
            {
                mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
                i++;
            }
            else
            {
                Fade_judge = false;
                i = 0;
            }
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Doctor_Judge")
        {
            Fade_judge = true;
            Debug.Log("範囲に入った:"+Fade_judge+":iの値は"+i);
            //StartCoroutine("Fade");
        }
    }

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.gameObject.tag == "Doctor_Judge")
        //    {
        //        Debug.Log("範囲に入った");
        //        StartCoroutine("Fade");
        //    }
        //}
        IEnumerator Fade()
    {
        //yield return null;
        int i = 0;
        while (i<255)//徐々に見えて
        {
            mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);
            i++;
            yield return new WaitForSeconds(0.001f);
            
        }
        i = 0;
        while (i < 255)//徐々に消える
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            i--;
            yield return new WaitForSeconds(0.001f);
            
        }
        Debug.Log("コルーチンを終了しました");
        yield break;
        
        //yield break;
    }
}
