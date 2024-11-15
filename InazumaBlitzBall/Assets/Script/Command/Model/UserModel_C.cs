using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//ユーザーの制御(Command)
public class UserModel_C : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject userTeam;
    [SerializeField] GameObject enemyGoal; //Goalオブジェクト
    [SerializeField] MainCamera mainCamera;
    [SerializeField] UserModel_A userModel_A;
    [SerializeField] Ball ball; //Ballスクリプト
    [SerializeField] Game_C game_C; //Gameスクリプト
    //private変数
    GameObject[] users;
    GameObject[] passUsers;
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

    public void SetUp(GameObject userTeam, GameObject enemyGoal, MainCamera mainCamera, Ball ball, Game_C game_C, string charaName, int maxHP)
    {
        this.userTeam = userTeam;
        this.enemyGoal = enemyGoal;
        this.mainCamera = mainCamera;
        this.userModel_A = this.gameObject.GetComponent<UserModel_A>();
        this.ball = ball;
        this.game_C = game_C;
        this.charaName = charaName;
        this.maxHP = maxHP;
        hp = maxHP;
    }

    public void Pass()
    {
        if (users == null) {
            users = new GameObject[userTeam.transform.childCount];
            for(int i = 0; i < userTeam.transform.childCount; i++)
            {
                users[i] = userTeam.transform.GetChild(i).gameObject;
            }
        }

        if (userModel_A.isUser)
        {
            passUsers = new GameObject[users.Length - 1];
            for (int i = 0; i < users.Length; i++)
            {
                int j = 0;
                if (users[i].GetComponent<UserModel_C>().charaName != this.charaName)
                {
                    passUsers[j] = users[i];
                    j++;
                }
            }
            passVec = new Vector3(passUsers[0].transform.position.x - transform.position.x, passUsers[0].transform.position.y - transform.position.y, passUsers[0].transform.position.z - transform.position.z);
            passVec = passVec.normalized;
            ball.Throw(passVec);
            userModel_A.IsUser = false;
            //delete[] passUsers;
        }
    }

    public void PassCut(GameObject collision)
    {
        blowVec = new Vector3(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y, collision.transform.position.z - transform.position.z);
        blowVec = blowVec.normalized;
        collision.GetComponent<Rigidbody>().velocity = blowVec * 10.0f;
        ball.Catch(this.gameObject);
        collision.GetComponent<EnemyModel_A>().IsEnemy = false;
    }

    public void Dribble()
    {
        if (userModel_A.isUser)
        {
            ColliderAvailable = false;
            goalVec = new Vector3(enemyGoal.transform.position.x - transform.position.x, enemyGoal.transform.position.y - transform.position.y, enemyGoal.transform.position.z - transform.position.z);
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
        blowVec = new Vector3(collision.transform.position.x - transform.position.x, collision.transform.position.y - transform.position.y, collision.transform.position.z - transform.position.z);
        blowVec = blowVec.normalized;
        collision.GetComponent<Rigidbody>().velocity = blowVec * 10.0f;
        ball.Catch(this.gameObject);
        collision.GetComponent<EnemyModel_A>().IsEnemy = false;
    }

    //シュート行動
    public void Shoot()
    {
        if (userModel_A.isUser)
        {
            goalVec = new Vector3(enemyGoal.transform.position.x - transform.position.x, enemyGoal.transform.position.y - transform.position.y, enemyGoal.transform.position.z - transform.position.z);
            goalVec = goalVec.normalized;
            ball.Throw(goalVec);
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
        if (ball.userBall)
        {
            if (userModel_A.isUser)
            {
                //Enemyとの衝突判定
                if (collision.gameObject.name == "Enemy(Clone)")
                {
                    game_C.Command(this.gameObject, collision.gameObject, "UvE");
                }

                //ゴールとの衝突判定
                if (collision.gameObject.name == "EnemyGoal")
                {
                    if (ball.userBall)
                    {
                        game_C.Command(this.gameObject, collision.gameObject, "UvG");
                    }
                }
            }  
        }
        else
        {
            //Enemyとの衝突判定
            if (collision.gameObject.name == "Enemy(Clone)")
            {
                if (collision.gameObject.GetComponent<EnemyModel_A>().isEnemy)
                {
                    mainCamera.SetFrontObject(this.gameObject);
                    game_C.Command(this.gameObject, collision.gameObject, "UvE");
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
