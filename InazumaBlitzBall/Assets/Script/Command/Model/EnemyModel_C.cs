using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//エネミーの制御(Command)
public class EnemyModel_C : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject enemyTeam;
    [SerializeField] GameObject userGoal; //Goalオブジェクト
    [SerializeField] EnemyModel_A enemyModel_A;
    [SerializeField] Ball ball; //Ballスクリプト
    [SerializeField] Game_C game_C; //Gameスクリプト

    GameObject[] enemys;
    GameObject[] passEnemys;
    Vector3 passVec;
    Vector3 goalVec; //ゴール方向ベクトル
    Vector3 blowVec;
    // キャラクターデータ(初期ステータス)
    [Header("キャラクター名")]
    public string charaName; // キャラクター名
    [Header("最大HP(初期HP)")]
    public int maxHP; // 最大HP→ボール持ってると減少、アビリティ使用で減少、なくなるとコマンドバトルは基本敗北.
    public int hp;
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

    public void SetUp(GameObject enemyTeam, GameObject userGoal, Ball ball, Game_C game_C, string charaName, int maxHP)
    {
        this.enemyTeam = enemyTeam;
        this.userGoal = userGoal;
        this.enemyModel_A = this.gameObject.GetComponent<EnemyModel_A>();
        this.ball = ball;
        this.game_C = game_C;
        this.charaName = charaName;
        this.maxHP = maxHP;
        hp = maxHP;
    }

    public void Pass()
    {
        if (enemys == null)
        {
            enemys = new GameObject[enemyTeam.transform.childCount];
            for (int i = 0; i < enemyTeam.transform.childCount; i++)
            {
                enemys[i] = enemyTeam.transform.GetChild(i).gameObject;
            }
        }

        if (enemyModel_A.isEnemy)
        {
            passEnemys = new GameObject[enemys.Length - 1];
            for (int i = 0; i < enemys.Length; i++)
            {
                int j = 0;
                if (enemys[i].GetComponent<EnemyModel_C>().charaName != this.charaName)
                {
                    passEnemys[j] = enemys[i];
                    j++;
                }
            }
            passVec = new Vector3(passEnemys[0].transform.position.x - transform.position.x, passEnemys[0].transform.position.y - transform.position.y, passEnemys[0].transform.position.z - transform.position.z);
            passVec = passVec.normalized;
            ball.Throw(passVec);
            enemyModel_A.IsEnemy = false;
            //delete[] passUsers;
        }
    }

    public void PassCut(GameObject collision)
    {
        blowVec = new Vector3(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y, collision.transform.position.z - transform.position.z);
        blowVec = blowVec.normalized;
        collision.GetComponent<Rigidbody>().velocity = blowVec * 10.0f;
        ball.Catch(this.gameObject);
    }

    public void Dribble()
    {
        if (enemyModel_A.isEnemy)
        {
            ColliderAvailable = false;
            goalVec = new Vector3(userGoal.transform.position.x - transform.position.x, userGoal.transform.position.y - transform.position.y, userGoal.transform.position.z - transform.position.z);
            goalVec = goalVec.normalized;
            this.gameObject.GetComponent<Rigidbody>().velocity = goalVec * 10.0f;
            game_C.IsCommand = false;
            Invoke("DribbleDelay", 2.0f);
        }
    }

    void DribbleDelay()
    {
        ColliderAvailable = true;
    }

    public void DribbleCut(GameObject collision)
    {
        hp -= 10;
        blowVec = new Vector3(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y, collision.transform.position.z - transform.position.z);
        blowVec = blowVec.normalized;
        collision.GetComponent<Rigidbody>().velocity = blowVec * 10.0f;
        ball.Catch(this.gameObject);
    }

    //シュート行動
    public void Shoot()
    {
        if (enemyModel_A.isEnemy)
        {
            goalVec = new Vector3(userGoal.transform.position.x - transform.position.x, userGoal.transform.position.y - transform.position.y, userGoal.transform.position.z - transform.position.z);
            goalVec = goalVec.normalized;
            ball.Throw(goalVec);
            enemyModel_A.isEnemy = false;
        }
    }

    //衝突判定
    void OnCollisionEnter(Collision collision)
    {
        //Ballとの衝突判定
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.GetComponent<Ball>().Catch(this.gameObject);
            /*
            //味方ボールと敵ボールで機能切り替え
            if (collision.gameObject.GetComponent<Ball>().userBall)
            {
                
            }
            else
            {
                game_C.Command(this.gameObject, collision.gameObject, "UvB");
            }
            */
        }

        if (enemyModel_A.isEnemy)
        {
            //ゴールとの衝突判定
            if (collision.gameObject.name == "UserGoal")
            {
                if (hp >= 20)
                {
                    hp -= 20;
                    ball.power = 20;
                    game_C.IsCommand = true;
                    Shoot();
                }
                else
                {
                    game_C.IsCommand = true;
                    Shoot();
                }
            }
        }
    }

    bool ColliderAvailable
    {
        set
        {
            gameObject.GetComponent<SphereCollider>().enabled = value;
        }
    }
}
