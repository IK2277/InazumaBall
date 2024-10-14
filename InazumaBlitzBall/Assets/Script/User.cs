using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class User : MonoBehaviour
{
    //public変数
    [SerializeField] Game game; //メインスクリプト
    [SerializeField] Stage stage; //ステージスクリプト
    [SerializeField] MainCamera camera; //追従するカメラスクリプト
    float moveSpeed = 5.0f; //移動速度

    //private変数
    Vector3 userVec; //移動方向ベクトル
    Vector3 forward; //カメラの前方向
    Vector3 right; //カメラの右方向
    Vector3 nextPos; //ユーザーの次座標
    Vector3 pos; //ユーザーの現在座標
    float turnSpeed = 0.2f; //振り向き速度
    float smoothTime = 0.1f; //進行方向にかかるおおよその時間
    float maxAngularVelocity = Mathf.Infinity; //最大の回転角速度
    float angle; //回転角度

    void Start()
    {
        
    }

    void Update()
    {
        //アクションとコマンドでの機能切り替え
        if (!game.isCommand)
        {
            //移動方向ベクトルの設定
            {
                forward = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;
                right = Vector3.Scale(camera.transform.right, new Vector3(1, 0, 1)).normalized;

                userVec = Vector3.zero;

                //移動入力
                if (Input.GetKey(KeyCode.W))
                {
                    userVec = forward;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    userVec = -1 * right;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    userVec = -1 * forward;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    userVec = right;
                }

                //移動方向ベクトルの単位ベクトル
                userVec = userVec.normalized * moveSpeed * Time.deltaTime;
            }
            
            //移動する場合
            if (userVec.magnitude > 0)
            {
                //ユーザーの回転
                {
                    nextPos = transform.position + userVec;
                    pos = transform.position;

                    //Vector3.SmoothDampはVector3型の値を徐々に変化させる //Vector3.SmoothDamp (現在地, 目的地, ref 現在の速度, 遷移時間, 最高速度)
                    angle = Mathf.SmoothDampAngle(0, Vector3.Angle(transform.forward, nextPos - pos), ref turnSpeed, smoothTime, maxAngularVelocity);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextPos - pos, Vector3.up), angle);
                }
                
                //Stageとの衝突判定
                if (!stage.Collision(transform.position + userVec))
                {
                    //ユーザーの移動
                    transform.position += userVec;
                }
            }
        }
        else
        {

        }
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        //NPCとの衝突
        if(collision.gameObject.name == "NPC")
        {
            game.Command();
        }
    }
}
