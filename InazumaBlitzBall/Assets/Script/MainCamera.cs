using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //public変数
    [SerializeField] Game game; //メインスクリプト
    [SerializeField] GameObject user; //ユーザーオブジェクト

    //private変数
    Vector3 pos; //プレイヤーの現在地
    Vector3 pastPos; //プレイヤーの過去位置

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
                transform.RotateAround(user.transform.position, Vector3.up, mx);
            }
            if (Mathf.Abs(my) > 0.01f)
            {
                transform.RotateAround(user.transform.position, transform.right, -my);
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
