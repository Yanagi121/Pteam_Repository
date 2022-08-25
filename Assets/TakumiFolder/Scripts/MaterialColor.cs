using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MaterialColor : MonoBehaviour
{
    private bool onetime;
    SkinnedMeshRenderer mesh;
    void Start()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TestPlayScene")
        {
            mesh.enabled = false;
            onetime = false;

        }
    }
}
