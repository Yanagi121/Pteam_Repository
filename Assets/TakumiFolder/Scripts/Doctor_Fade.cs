using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor_Fade : MonoBehaviour
{
    MeshRenderer mesh;
    [SerializeField] GameObject Doctor;
    void Start()
    {
        mesh = Doctor.GetComponent<MeshRenderer>();
        mesh.material.color = new Color32(255,0,0,0);
        //StartCoroutine("Fade");
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Doctor_Judge")
        {
            Debug.Log("�͈͂ɓ�����");
            StartCoroutine("Fade");
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Doctor_Judge")
    //    {
    //        Debug.Log("�͈͂ɓ�����");
    //        StartCoroutine("Fade");
    //    }
    //}
    IEnumerator Fade()
    {
        //yield return null;
        int i = 0;
        while (i<255)//���X�Ɍ�����
        {
            mesh.material.color = mesh.material.color + new Color32(0, 0, 0, 1);
            i++;
            yield return new WaitForSeconds(0.001f);
            
        }
        i = 0;
        while (i < 255)//���X�ɏ�����
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            i--;
            yield return new WaitForSeconds(0.001f);
            
        }
        Debug.Log("�R���[�`�����I�����܂���");
        yield break;
        
        //yield break;
    }
}
