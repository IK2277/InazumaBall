using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] Game game; //メインスクリプト
    [SerializeField] Stage stage; //ステージ
    [SerializeField] MainCamera camera; //追従するカメラ
    public float moveSpeed = 5.0f; //移動速度
    public float turnSpeed = 0.2f; //振り向き速度
    Vector3 vector; //移動方向

    void Start()
    {
        
    }

    void Update()
    {
        if (!game.isCommand)
        {
            Vector3 forward = Vector3.Scale(camera.transform.forward, new Vector3(1, 1, 1)).normalized;
            Vector3 right = Vector3.Scale(camera.transform.right, new Vector3(1, 1, 1)).normalized;

            vector = Vector3.zero;

            //移動入力
            if (Input.GetKey(KeyCode.W))
            {
                vector = forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                vector = -1 * right;
            }
            if (Input.GetKey(KeyCode.S))
            {
                vector = -1 * forward;
            }
            if (Input.GetKey(KeyCode.D))
            {
                vector = right;
            }

            //移動方向ベクトルの単位ベクトル
            vector = vector.normalized * moveSpeed * Time.deltaTime;

            //移動する場合
            if (vector.magnitude > 0)
            {
                //回転角の決定 //Quaternion.Slerp(前のQuaternion値,後のQuaternion値,変化割合)
               
                //位置の決定
                if (!stage.Collision(transform.position + vector))
                {
                    transform.position += vector;
                }
            }
        }
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "NPC")
        {
            game.Command();
        }
    }
}
