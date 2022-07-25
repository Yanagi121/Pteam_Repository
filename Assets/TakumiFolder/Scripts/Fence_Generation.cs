using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence_Generation : MonoBehaviour
{
    [SerializeField] GameObject fence;
    private int fence_num1 = 0;//ŠÔ‚ª–³‚©‚Á‚½‚Ì‚ÅG@Œã‚Å”z—ñ‚É‚µ‚Ä‚¨‚«‚Ü‚·
    private int fence_num2 = 0;
    private int fence_num3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        while (fence_num1 < 31)
        {
            Instantiate(fence, new Vector3(86.23f + fence_num1 * 6.45f, 11.67f, 108.9f), Quaternion.identity);
            fence_num1++;
        }
        while (fence_num2 < 60)
        {
            Instantiate(fence, new Vector3(86.23f + fence_num2 * 6.45f, 11.67f, 424.8f), Quaternion.identity);
            fence_num2++;
        }
        while (fence_num3 < 48)
        {
            Instantiate(fence, new Vector3(84.1f , 11.67f, 118.7f + fence_num3* 6.45f), Quaternion.Euler(0,90,0));
            fence_num3++;
        }
        Debug.Log("ò‚ªì‚ç‚ê‚é");
       
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
