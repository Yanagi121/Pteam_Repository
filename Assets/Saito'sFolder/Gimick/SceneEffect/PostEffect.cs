using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
    public Material wipeCircle;
    
    	void OnRenderImage(RenderTexture src, RenderTexture dest)
    	{
    		Graphics.Blit (src, dest, wipeCircle);
    	}
}
