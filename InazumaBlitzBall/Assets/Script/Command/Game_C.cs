using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//�����ݒ�,�퓬�V�X�e���̐���(Command)
public class Game_C : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject goal;
    [SerializeField] GameObject commandView; //CommandView�I�u�W�F�N�g
    [SerializeField] Ball ball;
    [SerializeField] Game_A game_A; //Game�X�N���v�g
    public bool isCommand = false; //�R�}���h��ʔ���
    //private�ϐ�
    UserModel_C userModel_C;
    EnemyModel_C enemyModel_C;
    CommandView_C commandView_C; //CommandView�X�N���v�g
    int rnd;

    void Start()
    {
        //�ϐ��̑��
        {
            commandView_C = commandView.GetComponent<CommandView_C>();
        }
    }

    void Update()
    {
        
    }

    //�����̏����ݒ�
    public void SetupGame()
    {
        //���f���ݒ�
        {

        }
    }
  
    //�R�}���h�J�n
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
