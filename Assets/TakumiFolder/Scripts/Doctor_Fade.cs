using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor_Fade : MonoBehaviour
{
    MeshRenderer mesh;
    [SerializeField] SkinnedMeshRenderer[] mesh1;
    [SerializeField] GameObject Doctor;
    [SerializeField] GameObject[] Doctor_Surdace;
    int i ;//色の値
    int j ;//ドクターオブジェクトの色を変える部分の数
    bool Fade_judge;
    void Start()
    {
        i = 0;
        j = 0;
        mesh = Doctor.GetComponent<MeshRenderer>();
        while (j < 7)
        {
            mesh1[j] = Doctor_Surdace[j].GetComponent<SkinnedMeshRenderer>();
            j++;
        }
        
        mesh.material.color = new Color32(255,0,0,0);
        j = 0;
        while (j < 7)
        {
            switch (j)
            {
                case 0: mesh1[j].material.color = new Color32(192, 0, 0, 0);break;
                case 1: mesh1[j].material.color = new Color32(255, 255, 255, 0); break;
                case 2: mesh1[j].material.color = new Color32(60, 60, 60, 0); break;
                case 3: mesh1[j].material.color = new Color32(60, 60, 60, 0); break;
                case 4: mesh1[j].material.color = new Color32(89, 84, 84, 0); break;
                case 5: mesh1[j].material.color = new Color32(255, 255, 255, 0); break;
                case 6: mesh1[j].material.color = new Color32(255, 255, 255, 0); break;
            }
            
            j++;
        }
        //StartCoroutine("Fade");
        Fade_judge = false;
    }


    void Update()
    {
        if (Fade_judge==true)
        {
            if (i < 125)
            {
                mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);
                j = 0;
                while (j < 7)
                {
                    switch (j)
                    {
                        case 0: mesh1[j].material.color += new Color32(192, 0, 0, 1); break;
                        case 1: mesh1[j].material.color += new Color32(255, 255, 255, 1); break;
                        case 2: mesh1[j].material.color += new Color32(60, 60, 60, 1); break;
                        case 3: mesh1[j].material.color += new Color32(60, 60, 60, 1); break;
                        case 4: mesh1[j].material.color += new Color32(89, 84, 84, 1); break;
                        case 5: mesh1[j].material.color += new Color32(255, 255, 255, 1); break;
                        case 6: mesh1[j].material.color += new Color32(255, 255, 255, 1); break;
                    }
                    j++;
                }
                i++;
            }
            else if(125<=i&&i<255)
            {
                mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
                j = 0;
                while (j < 7)
                {
                    switch (j)
                    {
                        case 0: mesh1[j].material.color -= new Color32(192, 0, 0, 1); break;
                        case 1: mesh1[j].material.color -= new Color32(255, 255, 255, 1); break;
                        case 2: mesh1[j].material.color -= new Color32(60, 60, 60, 1); break;
                        case 3: mesh1[j].material.color -= new Color32(60, 60, 60, 1); break;
                        case 4: mesh1[j].material.color -= new Color32(89, 84, 84, 1); break;
                        case 5: mesh1[j].material.color -= new Color32(255, 255, 255, 1); break;
                        case 6: mesh1[j].material.color -= new Color32(255, 255, 255, 1); break;
                    }
                    j++;
                }
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
