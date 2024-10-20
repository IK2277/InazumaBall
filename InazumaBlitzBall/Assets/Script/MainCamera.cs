using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ユーザーを映すカメラに関するスクリプト
public class MainCamera : MonoBehaviour
{
    //public変数
    [SerializeField] Game_C game_C; //Gameスクリプト
    [SerializeField] GameObject frontObject; //追従先オブジェクト
    public float sensitivity = 1.0f; //カメラ感度

    //private変数
    Vector3 pos; //Userの現在地
    Vector3 pastPos; //Userの過去位置

    void Start()
    {
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

        //アクションとコマンドでの機能切り替え
        if (!game_C.isCommand)
        {
            //カメラの位置
            {
                pos = frontObject.transform.position;
                transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
                pastPos = pos;
            }
        }
        else
        {

        }
    }

    public void SetFrontObject(GameObject setFrontObject)
    {
        frontObject = setFrontObject;
        pastPos = setFrontObject.transform.position;
        transform.position = setFrontObject.transform.position + new Vector3(0, 2, -5);
    }
}
