using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperModel_C : MonoBehaviour
{
    [SerializeField] GameObject userTeam;
    [SerializeField] GameObject enemyTeam;
    [SerializeField] Game_C game_C;
    [SerializeField] Ball ball; //Ball�X�N���v�g
    public bool userKeeper = false;

    GameObject[] players;
    Vector3 passVec;
    Vector3 goalVec;
    // �L�����N�^�[�f�[�^(�����X�e�[�^�X)
    [Header("�ő�HP(����HP)")]
    public int maxHP; // �ő�HP���{�[�������Ă�ƌ����A�A�r���e�B�g�p�Ō����A�Ȃ��Ȃ�ƃR�}���h�o�g���͊�{�s�k.
    public int hp;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 50;
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //Ball�Ƃ̏Փ˔���
        if (collision.gameObject.name == "Ball")
        {
            game_C.IsCommand = true;
            if( hp >= 25)
            {
                collision.gameObject.GetComponent<Ball>().Catch(this.gameObject);
                hp -= 25;
                game_C.IsCommand = true;
                Invoke("Pass", 1.5f);
            }
            else
            {
                if(ball.power > 0)
                {
                    ball.ColliderAvailable = false;
                    if (userKeeper)
                    {
                        goalVec = new Vector3(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y, transform.position.z - collision.transform.position.z);
                        goalVec = goalVec.normalized;
                        ball.Throw(goalVec);
                        game_C.Goal(userKeeper);
                    }
                    else
                    {
                        goalVec = new Vector3(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y, transform.position.z - collision.transform.position.z);
                        goalVec = goalVec.normalized;
                        ball.Throw(goalVec);
                        game_C.Goal(userKeeper);
                    }
                }
                else
                {
                    int rnd = Random.Range(0, 2);
                    switch (rnd)
                    {
                        case 0:
                            ball.ColliderAvailable = false;
                            if (userKeeper)
                            {
                                goalVec = new Vector3(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y, transform.position.z - collision.transform.position.z);
                                goalVec = goalVec.normalized;
                                ball.Throw(goalVec);
                                game_C.Goal(userKeeper);
                            }
                            else
                            {
                                goalVec = new Vector3(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y, transform.position.z - collision.transform.position.z);
                                goalVec = goalVec.normalized;
                                ball.Throw(goalVec);
                                game_C.Goal(userKeeper);
                            }
                            break;
                        case 1:
                            collision.gameObject.GetComponent<Ball>().Catch(this.gameObject);
                            game_C.IsCommand = true;
                            Invoke("Pass", 1.5f);
                            break;
                    }
                }
            }
        }
    }

    void Pass()
    {
        if (players == null)
        {
            if (userKeeper)
            {
                players = new GameObject[userTeam.transform.childCount];
                for (int i = 0; i < userTeam.transform.childCount; i++)
                {
                    players[i] = userTeam.transform.GetChild(i).gameObject;
                }
            }
            else
            {
                players = new GameObject[enemyTeam.transform.childCount];
                for (int i = 0; i < enemyTeam.transform.childCount; i++)
                {
                    players[i] = enemyTeam.transform.GetChild(i).gameObject;
                }
            }
            
        }

        int rnd = Random.Range(0, players.Length);
        passVec = new Vector3(players[rnd].transform.position.x - transform.position.x, players[rnd].transform.position.y - transform.position.y, players[rnd].transform.position.z - transform.position.z);
        passVec = passVec.normalized;
        ball.Throw(passVec);
    }
}
