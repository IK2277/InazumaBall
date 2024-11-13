using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//初期設定,戦闘システムの制御(Command)
public class Game_C : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject goal;
    [SerializeField] GameObject commandView; //CommandViewオブジェクト
    [SerializeField] Ball ball;
    [SerializeField] Game_A game_A; //Gameスクリプト
    public bool isCommand = false; //コマンド画面判定
    //private変数
    UserModel_C userModel_C;
    EnemyModel_C enemyModel_C;
    CommandView_C commandView_C; //CommandViewスクリプト
    int rnd;

    void Start()
    {
        //変数の代入
        {
            commandView_C = commandView.GetComponent<CommandView_C>();
        }
    }

    void Update()
    {
        
    }

    //試合の初期設定
    public void SetupGame()
    {
        //モデル設定
        {

        }
    }
  
    //コマンド開始
    public void Command(GameObject user, GameObject collision, string panelName)
    {
        isCommand = true;
        commandView.SetActive(true);
        commandView_C.SelectedPanel(user, collision, panelName);
    }

    public void Battle(GameObject user, GameObject collision, string selectedCommand)
    {
        userModel_C = user.GetComponent<UserModel_C>();
        switch (selectedCommand)
        {
            case "Pass":
                if(collision.gameObject.name == "Enemy(Clone)")
                {
                    enemyModel_C = collision.GetComponent<EnemyModel_C>();
                    rnd = Random.Range(0, 3);
                    switch (rnd)
                    {
                        case 0: 
                        case 1:
                            enemyModel_C.PassCut(user);
                            break;
                        case 2:
                            userModel_C.Pass();
                            break;
                    }
                    
                }else if(collision.gameObject.name == "EnemyGoal")
                {
                    userModel_C.Pass();
                }
                break;

            case "PassCut":
                enemyModel_C = collision.GetComponent<EnemyModel_C>();
                rnd = Random.Range(0, 3);
                switch (rnd)
                {
                    case 0:
                    case 1:
                        enemyModel_C.hp -= 20;
                        enemyModel_C.Dribble();
                        break;
                    case 2:
                        userModel_C.PassCut(collision);
                        break;
                }
                break;

            case "Dribble":
                enemyModel_C = collision.GetComponent<EnemyModel_C>();
                rnd = Random.Range(0, 3);
                switch (rnd)
                {
                    case 0:
                    case 1:
                        userModel_C.hp -= 20;
                        userModel_C.Dribble();
                        break;
                    case 2:
                        userModel_C.hp -= 20;
                        enemyModel_C.hp -= 10;
                        enemyModel_C.DribbleCut(user);
                        break;
                }
                break;

            case "DribbleCut":
                enemyModel_C = collision.GetComponent<EnemyModel_C>();
                rnd = Random.Range(0, 3);
                switch (rnd)
                {
                    case 0:
                    case 1:
                        userModel_C.hp -= 10;
                        enemyModel_C.hp -= 20;
                        userModel_C.DribbleCut(collision);
                        break;
                    case 2:
                        userModel_C.hp -= 10;
                        enemyModel_C.Pass();
                        break;
                }
                break;

            case "StrongShoot":
                userModel_C.hp -= 20;
                ball.power = 20;
                userModel_C.Shoot();
                break;

            case "NormalShoot":
                userModel_C.Shoot();
                break;
        }
    }

    public void Goal(bool userKeeper)
    {
        goal.SetActive(true);
    }

    public bool IsCommand
    {
        set
        {
            isCommand = value;
        }
    }
}
