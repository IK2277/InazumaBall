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
    void SetupGame()
    {
        //�I�u�W�F�N�g�����z�u
        {
            for (int u = 0; u < 2; u++)
            {
                insObject = Instantiate(prefUser, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                insObject.transform.parent = userTeam.transform;
                insObject.GetComponent<UserModel_A>().SetUp(mainCamera, stage, game_C);
                insObject.GetComponent<UserModel_C>().SetUp(enemyGoal, ball, game_C);
                switch (u)
                {
                    case 0:
                        insObject.transform.position = userTeam.transform.position;
                        insObject.GetComponent<UserModel_A>().IsUser = true;
                        mainCamera.SetFrontObject(insObject);
                        break;
                    case 1:
                        insObject.transform.position = userTeam.transform.position;
                        insObject.transform.position += new Vector3(-2.0f, 0.0f, -2.0f);
                        break;
                }
            }
            for (int e = 0; e < 2; e++)
            {
                insObject = Instantiate(prefEnemy, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                insObject.transform.parent = enemyTeam.transform;
                insObject.GetComponent<EnemyModel_A>().SetUp(mainCamera, stage, game_C);
                insObject.GetComponent<EnemyModel_C>().SetUp(userGoal, ball, game_C);
                switch (e)
                {
                    case 0:
                        insObject.transform.position = enemyTeam.transform.position;
                        break;
                    case 1:
                        insObject.transform.position = enemyTeam.transform.position;
                        insObject.transform.position += new Vector3(2.0f, 0.0f, -2.0f);
                        break;
                }
            }
        }
    }
}
