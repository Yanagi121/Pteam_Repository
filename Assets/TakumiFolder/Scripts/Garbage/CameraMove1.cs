
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraMove : MonoBehaviour
//{
//    // Start is called before the first frame update
//    [SerializeField] Vector3 lastMousePosition;
//    [SerializeField] Vector3 newAngle = new Vector3(0, 0, 0);
//    [SerializeField]
//    float y_rotate, x_rotate, x_reverce, y_reverce,
//        cameraX, mouseX1, mouseY, tmpX = 0, tmpY = 0, boolX, boolY;
//    public float CameraSensitivityX = 5, CameraSensitivityY = 5, GetEscKey = 0;
//    public static Transform transCamera1;
//    public static bool TimeDelay1 = false;//false‚Ådelay
//    [SerializeField] GameObject GamePlayer1;
//    [SerializeField] Vector3 GamePlayerTransform1;
//    private string Player1;


//    void Start()
//    {
//        //newAngle = this.transform.localEulerAngles;
//        // lastMousePosition = Input.mousePosition;

//        //  Camera1.name = photonView.Owner.NickName+"Camera";
//        // Player1 = ""+ photonView.OwnerActorNr;

//    }

//    private void OnEnable()//SetActive‚ªtrue‚©‚çfalse‚É‚È‚Á‚½‚Æ‚«‚É‹N“®
//    {
//        transCamera1 = this.gameObject.transform;
//        DontDestroyOnLoad(this.gameObject);
//        GamePlayer = GameObject.Find("Player1");
//    }

//    void FixedUpdate()
//    {

//        if (TimeDelay1)
//        {
//            /*newAngle.y += (Input.mousePosition.x - lastMousePosition.x) * y_rotate * x_reverce;
//            newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * x_rotate * y_reverce;
//            this.gameObject.transform.localEulerAngles = newAngle;
//            lastMousePosition = Input.mousePosition;*/
//            //mouseX = Input.mousePosition.x* CameraSensitivityX/100;

//            // mouseY = Input.mousePosition.y;
//            mouseY = Input.GetAxis("Mouse Y") * CameraSensitivityY;
//            mouseX = Input.GetAxis("Mouse X") * CameraSensitivityX;
//            x_rotate += mouseX * Time.deltaTime * 100.0f;
//            /* if (mouseX - tmpX > 0)
//             {
//                 boolX = 1;
//                 tmpX = mouseX;
//             }
//             else if (mouseX - tmpX < 0)
//             {
//                 boolX = -1;
//                 tmpX = mouseX;
//             }
//             else
//                 boolX = 0;*/

//            cameraX = Mathf.Clamp(cameraX - mouseY * Time.deltaTime * 100.0f, -40, 40);
//            transCamera.localEulerAngles = new Vector3(cameraX, x_rotate, 0);

//        }
//        GamePlayerTransform1 = GamePlayer.transform.position;
//        transCamera.position = GamePlayerTransform1 + new Vector3(0, 1.5f, 0);

//    }

//}
