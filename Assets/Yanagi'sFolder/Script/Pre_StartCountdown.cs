using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pre_StartCountdown : MonoBehaviour
{
    public TextMeshProUGUI PreStartCountdownText;
    public GameObject PreStartTwxtGameObject;
    [SerializeField] GameObject SearchDoctor_Obj,Timer_Background_obj, NumericKeypad_obj;
    [SerializeField] Image SearchDoctor_img;
    float a = 0, toumei = 1, timerUIhidden = 5f;
    int CountDownInt = 5;//RoomSceneManager2.delayMove‚Ì’l‚ðŽQÆ‚·‚é
    int fontsize=350;
    bool alpha=false;
    public static bool lockedEscKey=false;
    Color Alpha;
    // Start is called before the first frame update
    void Start()
    {
        //PreStartCountdownText.color = new Color(1, 1, 1, 1);
        SearchDoctor_Obj.SetActive(false);
        Timer_Background_obj.SetActive(false);
        NumericKeypad_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        PreStartCountdownText.text= CountDownInt.ToString("0");
        if (a >= 1&&alpha==false)
        {
            a = 0;
           
            CountDownInt--;
        }
       else if (CountDownInt == 0)
        {

            PreStartCountdownText.text = " ";
            fontsize = 300;
            CountDownInt = 0;
            SearchDoctor_Obj.SetActive(true);
            Timer_Background_obj.SetActive(true);
            NumericKeypad_obj.SetActive(true);
            fadeInFunc();

            alpha = true;
            lockedEscKey = true;
            a += Time.deltaTime;
        }
        else
        {
            a += Time.deltaTime;
        }
        if (a >= 1 && alpha)
        {
            a = 1;
            toumei -= 0.005f;
        }
        PreStartCountdownText.fontSize = easeOutQuart(a)* fontsize;
        Alpha = new Color(1, 1, 1, toumei);
        PreStartCountdownText.color = Alpha;
        if (toumei <= 0)
            PreStartTwxtGameObject.SetActive(false);
    }
    float easeOutQuart(float x)
    {
        return 1-Mathf.Pow(1-x,4);
    }

    void fadeInFunc()
    {
        timerUIhidden -= Time.deltaTime;
        SearchDoctor_img.color -= new Color(0, 0, 0, 0.0025f);
        if (timerUIhidden <= 0)
            SearchDoctor_Obj.SetActive(false);

    }
}
