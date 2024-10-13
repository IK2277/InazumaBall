using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Game game; //メインスクリプト
    [SerializeField] GameObject user; //ユーザー
    Vector3 distance; //ユーザーからの距離
    Vector3 pos; //プレイヤーの現在地
    Vector3 pastPos; //プレイヤーの過去位置

    void Start()
    {
        distance = new Vector3(0, 2, -5);
        transform.position = user.transform.position + distance;
        pastPos = user.transform.position;
    }

    void Update()
    {
        //回転の設定
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


        if (!game.isCommand)
        {
            //位置の設定
            pos = user.transform.position;
            transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
            pastPos = pos;
        }
    }
}
