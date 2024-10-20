using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//ユーザーの制御(Action)
public class UserModel_A : MonoBehaviour
{
    //public変数
    [SerializeField] MainCamera mainCamera; //MainCameraスクリプト
    [SerializeField] Stage stage; //Stageスクリプト
    [SerializeField] Game_C game_C; //Gameスクリプト]
    public bool isUser = true; //操作中判定
    public float moveSpeed = 5.0f; //移動速度
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
        //UserとNPCでの機能切り替え
        if (isUser)
        {
            //アクションとコマンドでの機能切り替え
            if (!game_C.isCommand)
            {
                //移動方向ベクトルの設定
                {
                    //前方向と右方向の設定
                    forward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
                    right = Vector3.Scale(mainCamera.transform.right, new Vector3(1, 0, 1)).normalized;

                    //移動方向ベクトルの初期化
                    userVec = Vector3.zero;

                    //移動キー入力設定
                    {
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
                        if (Input.GetKey(KeyCode.Space))
                        {
                            userVec += new Vector3(0, 1, 0);
                        }
                        if (Input.GetKey(KeyCode.LeftShift))
                        {
                            userVec += new Vector3(0, -1, 0);
                        }
                    }

                    //移動方向ベクトルの設定
                    userVec = userVec.normalized * moveSpeed * Time.deltaTime;
                }

                //移動時
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
        else
        {

        }
    }
}
