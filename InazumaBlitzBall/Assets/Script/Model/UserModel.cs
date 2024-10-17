using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//ユーザーに関するスクリプト
public class UserModel : MonoBehaviour
{
    //public変数
    [SerializeField] MainCamera camera; //MainCameraスクリプト
    [SerializeField] Stage stage; //Stageスクリプト
    [SerializeField] Ball ball; //Ballスクリプト
    [SerializeField] Game game; //Gameスクリプト]
    public bool isKeeper = false; //キーパー判定
    public bool isUser = true; //操作中判定
    public bool isBallCatch = false;//ボール所持判定.
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

    // キャラクターデータ(初期ステータス)
    [Header("キャラクター名")]
    public string charaName; // キャラクター名
    [Header("最大HP(初期HP)")]
    public int maxHP; // 最大HP→ボール持ってると減少、アビリティ使用で減少、なくなるとコマンドバトルは基本敗北.
    [Header("スピード")]
    public int spd; // スピード→移動の速さ.
    [Header("パス")]
    public int pas; // パス→能力が高いほどカットされにくくなる.
    [Header("シュート")]
    public int sht; // シュート → 能力が高いほどシュートの威力が上がる.
    [Header("耐久力")]
    public int phy; // 耐久力 → ドリブルの際、相手のアタックに耐えられるか.
    [Header("パス・シュートカット")]
    public int cut; // カット→パスorシュートを途中でカットする力.
    [Header("アタック")]
    public int atk; // アタック→ドリブルを止める力.
    [Header("キャッチ")]
    public int cat; // キャッチ→シュートを止める力.ランダムで70%-150%で変動.
    [Header("属性")]
    public Attribute attribute; // 属性
    [HideInInspector]
	public int nowHP; // 現在HP
    public enum Attribute
    {
        Water, // 水属性
        Fire,  // 火属性
        Wind,  // 風属性
        Soil,  // 土属性
    }

    void Start()
    {
        
    }

    void Update()
    {
        //役職での機能切り替え
        if (!isKeeper)
        {
            //UserとNPCでの機能切り替え
            if (isUser)
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
                        if (Input.GetKey(KeyCode.Space))
                        {
                            userVec += new Vector3(0, 1, 0);
                        }
                        if (Input.GetKey(KeyCode.LeftShift))
                        {
                            userVec += new Vector3(0, -1, 0);
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
            else
            {

            }
        }
        else
        {

        }
    }

    //シュート選択時
    public void Shoot()
    {
        ball.Throw(forward * 200.0f);
    }

    //パス選択時
    public void Pass()
    {
        Debug.Log("チームメイトがいません。");
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        //Enemyとの衝突判定
        if (collision.gameObject.name == "Enemy")
        {
            game.Command();
        }
    }
}
