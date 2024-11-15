using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//エネミーの制御(Action)
public class EnemyModel_A : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject userGoal;
    [SerializeField] Stage stage; //Stageスクリプト
    [SerializeField] EnemyModel_C enemyModel_C;
    [SerializeField] Ball ball;
    [SerializeField] Game_C game_C; //Gameスクリプト
    public bool isEnemy = false;
    public float moveSpeed; //移動速度
    //private変数
    GameObject lastUser;
    Vector3 enemyVec; //移動方向ベクトル
    Vector3 nextPos; //ユーザーの次座標
    Vector3 pos; //ユーザーの現在座標
    float turnSpeed = 0.2f; //振り向き速度
    float smoothTime = 0.1f; //進行方向にかかるおおよその時間
    float maxAngularVelocity = Mathf.Infinity; //最大の回転角速度
    float angle; //回転角度

    void Start()
    {
        moveSpeed = 5.0f;
    }

    void Update()
    {
        //アクションとコマンドでの機能切り替え
        if (!game_C.isCommand)
        {
            if (ball.userBall)
            {
                //移動方向ベクトルの設定
                {
                    ballObject = GameObject.Find("Ball");
                    //移動方向ベクトルの初期化
                    enemyVec = Vector3.zero;

                    //移動方向ベクトルの設定
                    enemyVec = new Vector3(ballObject.transform.position.x - transform.position.x, ballObject.transform.position.y - transform.position.y, ballObject.transform.position.z - transform.position.z);
                    enemyVec = enemyVec.normalized * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                //移動方向ベクトルの設定
                {
                    //移動方向ベクトルの初期化
                    enemyVec = Vector3.zero;

                    //移動方向ベクトルの設定
                    enemyVec = new Vector3(userGoal.transform.position.x - transform.position.x, userGoal.transform.position.y - transform.position.y, userGoal.transform.position.z - transform.position.z);
                    enemyVec = enemyVec.normalized * moveSpeed * Time.deltaTime;
                }
            }
            //移動時
            if (enemyVec.magnitude > 0)
            {
                //ユーザーの回転
                {
                    nextPos = transform.position + enemyVec;
                    pos = transform.position;

                    //Vector3.SmoothDampはVector3型の値を徐々に変化させる //Vector3.SmoothDamp (現在地, 目的地, ref 現在の速度, 遷移時間, 最高速度)
                    angle = Mathf.SmoothDampAngle(0, Vector3.Angle(transform.forward, nextPos - pos), ref turnSpeed, smoothTime, maxAngularVelocity);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextPos - pos, Vector3.up), angle);
                }

                //Stageとの衝突判定
                if (!stage.Collision(transform.position + enemyVec))
                {
                    //ユーザーの移動
                    transform.position += enemyVec;
                }
            }
        }
        else
        {

        }
    }

    public void SetUp(GameObject userGoal, Stage stage, Ball ball, Game_C game_C)
    {
        this.ballObject = ball.gameObject;
        this.userGoal = userGoal;
        this.stage = stage;
        this.enemyModel_C = this.gameObject.GetComponent<EnemyModel_C>();
        this.ball = ball;
        this.game_C = game_C;
    }

    void MoveSpeedUp()
    {
        enemyModel_C.hp -= 10;
        moveSpeed = 20.0f;
        Invoke("ResetMoveSpeed", 0.5f);
    }

    void ResetMoveSpeed()
    {
        moveSpeed = 10.0f;
    }

    public bool IsEnemy
    {
        set
        {
            isEnemy = value;
        }
    }
}
