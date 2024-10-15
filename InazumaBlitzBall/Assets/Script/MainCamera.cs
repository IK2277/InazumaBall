using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ユーザーを映すカメラに関するスクリプト
public class MainCamera : MonoBehaviour
{
    //public変数
    [SerializeField] Game game; //Gameスクリプト
    [SerializeField] GameObject user; //Userオブジェクト
    public float sensitivity = 1.0f; //カメラ感度

    //private変数
    Vector3 pos; //Userの現在地
    Vector3 pastPos; //Userの過去位置

    void Start()
    {
        pastPos = user.transform.position;
    }

    void Update()
    {
        //カメラの回転
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            if (Mathf.Abs(mx) > 0.01f)
            {
                transform.RotateAround(user.transform.position, Vector3.up, mx * sensitivity);
            }
            if (Mathf.Abs(my) > 0.01f)
            {
                transform.RotateAround(user.transform.position, transform.right, -my * sensitivity);
            }
        }

        //アクションとコマンドでの機能切り替え
        if (!game.isCommand)
        {
            //カメラの位置
            {
                pos = user.transform.position;
                transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
                pastPos = pos;
            }
        }
        else
        {

        }
    }
}
