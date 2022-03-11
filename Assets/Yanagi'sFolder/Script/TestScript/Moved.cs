using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moved : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public float acceleration, MaxSpeed,FlontSpeed,BackSpeed,LeftSpeed,RightSpeed,speed,Angle_X=1,Angle_Y=1;
    private Transform PlayerTransform;
    private Transform CameraTransform;
    public float ii;
    public float X_Rotation, Y_Rotation;
    public bool FlontMove, BackMove,LeftMove,RightMove;
    // Use this for initialization
    void Start()
    {

        PlayerTransform = transform.parent;
        CameraTransform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
         X_Rotation = Input.GetAxis("Mouse X")* Angle_X;
         Y_Rotation = Input.GetAxis("Mouse Y")* Angle_Y;
        PlayerTransform.transform.Rotate(0, X_Rotation, 0);
        //CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
        ii = Camera.transform.localEulerAngles.x;
        if (ii > 320 && ii < 360 || ii > -1 && ii < 60 )//カメラアングル関係
        {
            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
            //float kk = Y_Rotation;
        }
        else
        {
            if (ii > 300)
            {
           
                if (Input.GetAxis("Mouse Y") < 0)
                {
                    CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
            else
            {
                if (Input.GetAxis("Mouse Y") > 0)
                {
                    CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
        }
        if (ii < 319 && ii > 270)//カメラ上向き固定バグを直す
        {
            Y_Rotation = -0.5f;
            CameraTransform.transform.Rotate(-Y_Rotation, 0, 0);
        }

        float angleDir = PlayerTransform.transform.eulerAngles.y * (Mathf.PI / 180.0f);
        Vector3 dir1 = new Vector3(Mathf.Sin(angleDir), 0, Mathf.Cos(angleDir));
        Vector3 dir2 = new Vector3(-Mathf.Cos(angleDir), 0, Mathf.Sin(angleDir));

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W))
        {
            speed += acceleration;
            if (MaxSpeed < speed)
                speed = MaxSpeed;
        }
        else
        {
            speed -= acceleration;
            if (speed < 0)
            {
                speed = 0;
              /*  FlontMove = false;
                BackMove = false;
                RightMove = false;
                LeftMove = false;*/
            }
        }

        if (Input.GetKey(KeyCode.W)|| FlontMove)
        {
            PlayerTransform.transform.position += dir1 * speed * Time.deltaTime;
          /*  FlontMove = true;
            BackMove = false;
            LeftMove = false;
            RightMove = false;*/
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerTransform.transform.position += dir2 * speed * Time.deltaTime;
          /*  LeftMove = true;
            RightMove = false;
            FlontMove = false;
            BackMove = false;*/
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerTransform.transform.position += -dir2 * speed * Time.deltaTime;
           /* LeftMove = false;
            RightMove = true;
            FlontMove = false;
            BackMove = false;*/
        }
        if (Input.GetKey(KeyCode.S)||BackMove)
        {
            PlayerTransform.transform.position += -dir1 * speed * Time.deltaTime;
           /* FlontMove = false;
            BackMove = true;
            LeftMove = false;
            RightMove = false;*/
        }
        
    }

}
