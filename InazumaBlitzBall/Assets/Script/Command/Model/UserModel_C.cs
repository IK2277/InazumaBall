using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//ユーザーの制御(Command)
public class UserModel_C : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject enemyGoal; //Goalオブジェクト
    [SerializeField] Ball ball; //Ballスクリプト
    [SerializeField] Game_C game_C; //Gameスクリプト
    //private変数
    Vector3 goalVec; //ゴール方向ベクトル
    // キャラクターデータ(初期ステータス)
    [Header("キャラクター名")]
    public string charaName; // キャラクター名
    [Header("最大HP(初期HP)")]
    public int maxHP; // 最大HP→ボール持ってると減少、アビリティ使用で減少、なくなるとコマンドバトルは基本敗北.
    /*
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
    */

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetUp(GameObject enemyGoal, Ball ball, Game_C game_C)
    {
        this.enemyGoal = enemyGoal;
        this.ball = ball;
        this.game_C = game_C;
    }
    public void Pass()
    {

    }

    public void PassCut()
    {

    }

    public void Dribble()
    {

    }

    public void DribbleCut()
    {

    }

    //シュート行動
    public void Shoot()
    {
        goalVec = new Vector3(enemyGoal.transform.position.x - transform.position.x, enemyGoal.transform.position.y - transform.position.y, enemyGoal.transform.position.z - transform.position.z);
        goalVec = goalVec.normalized;
        ball.Throw(goalVec);
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        //Enemyとの衝突判定
        if (collision.gameObject.name == "Enemy(Clone)")
        {
            game_C.Command(this.GetComponent<UserModel_C>(),"UvE");
        }

        //Ballとの衝突判定
        if (collision.gameObject.name == "Ball")
        {
            //味方ボールと敵ボールで機能切り替え
            if (collision.gameObject.GetComponent<Ball>().userBall)
            {
                collision.gameObject.GetComponent<Ball>().Catch(this.gameObject);
            }
            else
            {
                game_C.Command(this.GetComponent<UserModel_C>(), "UvB");
            }
        }

        //ゴールとの衝突判定
        if (collision.gameObject.name == "Goal")
        {
            game_C.Command(this.GetComponent<UserModel_C>(), "UvG");
        }
    }
}
