using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MaterialColor : MonoBehaviour
{

    SkinnedMeshRenderer mesh;
    void Start()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
        mesh.enabled = false;
    }
}
