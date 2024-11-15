using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//初期設定,戦闘システムの制御(Actition)
public class Game_A : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject userTeam;
    [SerializeField] GameObject enemyTeam;
    [SerializeField] GameObject userGoal;
    [SerializeField] GameObject enemyGoal;
    [SerializeField] GameObject prefUser;
    [SerializeField] GameObject prefEnemy;
    [SerializeField] MainCamera mainCamera; //MainCameraスクリプト
    [SerializeField] Stage stage; //Stageスクリプト
    [SerializeField] Ball ball;
    [SerializeField] Game_C game_C; //Gameスクリプト
    //private変数
    GameObject insObject;

    void Start()
    {
        SetupGame();
    }

    void Update()
    {
        
    }

    //試合の初期設定
    public void SetupGame()
    {
        //オブジェクト初期配置
        {
            for (int u = 0; u < 2; u++)
            {
                insObject = Instantiate(prefUser, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                insObject.transform.parent = userTeam.transform;
                switch (u)
                {
                    case 0:
                        insObject.GetComponent<UserModel_A>().SetUp(enemyGoal, mainCamera, stage, ball, game_C);
                        insObject.GetComponent<UserModel_C>().SetUp(userTeam, enemyGoal, mainCamera, ball, game_C, "User1", 100);
                        insObject.transform.position = userTeam.transform.position;
                        insObject.GetComponent<UserModel_A>().IsUser = true;
                        ball.Catch(insObject);
                        mainCamera.SetFrontObject(insObject);
                        break;
                    case 1:
                        insObject.GetComponent<UserModel_A>().SetUp(enemyGoal, mainCamera, stage, ball, game_C);
                        insObject.GetComponent<UserModel_C>().SetUp(userTeam, enemyGoal, mainCamera, ball, game_C, "User2", 100);
                        insObject.transform.position = userTeam.transform.position;
                        insObject.transform.position += new Vector3(-10.0f, 0.0f, -10.0f);
                        break;
                }
            }
            for (int e = 0; e < 2; e++)
            {
                insObject = Instantiate(prefEnemy, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                insObject.transform.parent = enemyTeam.transform;
                switch (e)
                {
                    case 0:
                        insObject.GetComponent<EnemyModel_A>().SetUp(userGoal, stage, ball, game_C);
                        insObject.GetComponent<EnemyModel_C>().SetUp(enemyTeam, userGoal, ball, game_C, "Enemy1", 100);
                        insObject.transform.position = enemyTeam.transform.position;
                        //ball.Catch(insObject);
                        break;
                    case 1:
                        insObject.GetComponent<EnemyModel_A>().SetUp(userGoal, stage, ball, game_C);
                        insObject.GetComponent<EnemyModel_C>().SetUp(enemyTeam, userGoal, ball, game_C, "Enemy2", 100);
                        insObject.transform.position = enemyTeam.transform.position;
                        insObject.transform.position += new Vector3(10.0f, 0.0f, 10.0f);
                        break;
                }
            }
        }
    }
}
