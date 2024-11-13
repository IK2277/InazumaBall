using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ユーザーを映すカメラに関するスクリプト
public class MainCamera : MonoBehaviour
{
    //public変数
    [SerializeField] Game_C game_C; //Gameスクリプト
    [SerializeField] GameObject frontObject; //追従先オブジェクト
    public float sensitivity; //カメラ感度

    //private変数
    Vector3 pos; //Userの現在地
    Vector3 pastPos; //Userの過去位置

    void Start()
    {
        sensitivity = 5.0f;
        pastPos = frontObject.transform.position;
    }

    void Update()
    {
        //カメラの回転
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            if (Mathf.Abs(mx) > 0.01f)
            {
                transform.RotateAround(frontObject.transform.position, Vector3.up, mx * sensitivity);
            }
            if (Mathf.Abs(my) > 0.01f)
            {
                transform.RotateAround(frontObject.transform.position, transform.right, -my * sensitivity);
            }
        }

        //カメラの位置
        {
            pos = frontObject.transform.position;
            transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
            pastPos = pos;
        }
    }

    void Reset()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
    public void SetFrontObject(GameObject setFrontObject)
    {
        Reset();
        frontObject = setFrontObject;
        pastPos = setFrontObject.transform.position;
        transform.position = setFrontObject.transform.position;
        transform.position += new Vector3(0.0f, 2.0f, -5.0f);
    }
}
