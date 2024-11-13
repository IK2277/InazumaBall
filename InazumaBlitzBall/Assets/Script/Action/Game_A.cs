using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//�����ݒ�,�퓬�V�X�e���̐���(Actition)
public class Game_A : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject userTeam;
    [SerializeField] GameObject enemyTeam;
    [SerializeField] GameObject userGoal;
    [SerializeField] GameObject enemyGoal;
    [SerializeField] GameObject prefUser;
    [SerializeField] GameObject prefEnemy;
    [SerializeField] MainCamera mainCamera; //MainCamera�X�N���v�g
    [SerializeField] Stage stage; //Stage�X�N���v�g
    [SerializeField] Ball ball;
    [SerializeField] Game_C game_C; //Game�X�N���v�g
    //private�ϐ�
    GameObject insObject;

    void Start()
    {
        SetupGame();
    }

    void Update()
    {
        
    }

    //�����̏����ݒ�
    public void SetupGame()
    {
        //�I�u�W�F�N�g�����z�u
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
