using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//�G�l�~�[�̐���(Command)
public class EnemyModel_C : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject enemyTeam;
    [SerializeField] GameObject userGoal; //Goal�I�u�W�F�N�g
    [SerializeField] EnemyModel_A enemyModel_A;
    [SerializeField] Ball ball; //Ball�X�N���v�g
    [SerializeField] Game_C game_C; //Game�X�N���v�g

    GameObject[] enemys;
    GameObject[] passEnemys;
    Vector3 passVec;
    Vector3 goalVec; //�S�[�������x�N�g��
    Vector3 blowVec;
    // �L�����N�^�[�f�[�^(�����X�e�[�^�X)
    [Header("�L�����N�^�[��")]
    public string charaName; // �L�����N�^�[��
    [Header("�ő�HP(����HP)")]
    public int maxHP; // �ő�HP���{�[�������Ă�ƌ����A�A�r���e�B�g�p�Ō����A�Ȃ��Ȃ�ƃR�}���h�o�g���͊�{�s�k.
    public int hp;
    /*
    [Header("�X�s�[�h")]
    public int spd; // �X�s�[�h���ړ��̑���.
    [Header("�p�X")]
    public int pas; // �p�X���\�͂������قǃJ�b�g����ɂ����Ȃ�.
    [Header("�V���[�g")]
    public int sht; // �V���[�g �� �\�͂������قǃV���[�g�̈З͂��オ��.
    [Header("�ϋv��")]
    public int phy; // �ϋv�� �� �h���u���̍ہA����̃A�^�b�N�ɑς����邩.
    [Header("�p�X�E�V���[�g�J�b�g")]
    public int cut; // �J�b�g���p�Xor�V���[�g��r���ŃJ�b�g�����.
    [Header("�A�^�b�N")]
    public int atk; // �A�^�b�N���h���u�����~�߂��.
    [Header("�L���b�`")]
    public int cat; // �L���b�`���V���[�g���~�߂��.�����_����70%-150%�ŕϓ�.
    [Header("����")]
    public Attribute attribute; // ����
    [HideInInspector]
    public int nowHP; // ����HP

    public enum Attribute
    {
        Water, // ������
        Fire,  // �Α���
        Wind,  // ������
        Soil,  // �y����
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

    //�V���[�g�s��
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

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //Ball�Ƃ̏Փ˔���
        if (collision.gameObject.name == "Ball")
        {
            collision.gameObject.GetComponent<Ball>().Catch(this.gameObject);
            /*
            //�����{�[���ƓG�{�[���ŋ@�\�؂�ւ�
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
            //�S�[���Ƃ̏Փ˔���
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
