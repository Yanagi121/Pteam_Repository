using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_satotaku : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;//–îˆó‚ÌF‚ğ•Ï‚¦‚é‚½‚ß
    [SerializeField] float count;//“_–Å‚ÌŠÔŒv‘ª
    [SerializeField] int i;
    [SerializeField] GameObject Arrow;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        i = 0;
        mesh = Arrow.GetComponent<MeshRenderer>();
        mesh.material.color = new Color32(231, 231, 231, 125);
        Arrow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (i < 125)
        {
            mesh.material.color += new Color32(0, 0, 0, 1);
            i++;
        }
        if (255 > i && i >= 125)
        {
            mesh.material.color -= new Color32(0, 0, 0, 1);
            i++;

        }
        if (i >= 255)
        {
            mesh.enabled = false;
        }
        if (count > 5f)
        {
            i = 0;
            count = 0;
            mesh.enabled = true;
        }
    }

}

