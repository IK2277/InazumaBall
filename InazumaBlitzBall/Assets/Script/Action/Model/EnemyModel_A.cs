using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//�G�l�~�[�̐���(Action)
public class EnemyModel_A : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject userGoal;
    [SerializeField] Stage stage; //Stage�X�N���v�g
    [SerializeField] EnemyModel_C enemyModel_C;
    [SerializeField] Ball ball;
    [SerializeField] Game_C game_C; //Game�X�N���v�g
    public bool isEnemy = false;
    public float moveSpeed; //�ړ����x
    //private�ϐ�
    GameObject lastUser;
    Vector3 enemyVec; //�ړ������x�N�g��
    Vector3 nextPos; //���[�U�[�̎����W
    Vector3 pos; //���[�U�[�̌��ݍ��W
    float turnSpeed = 0.2f; //�U��������x
    float smoothTime = 0.1f; //�i�s�����ɂ����邨���悻�̎���
    float maxAngularVelocity = Mathf.Infinity; //�ő�̉�]�p���x
    float angle; //��]�p�x

    void Start()
    {
        moveSpeed = 5.0f;
    }

    void Update()
    {
        //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
        if (!game_C.isCommand)
        {
            if (ball.userBall)
            {
                //�ړ������x�N�g���̐ݒ�
                {
                    ballObject = GameObject.Find("Ball");
                    //�ړ������x�N�g���̏�����
                    enemyVec = Vector3.zero;

                    //�ړ������x�N�g���̐ݒ�
                    enemyVec = new Vector3(ballObject.transform.position.x - transform.position.x, ballObject.transform.position.y - transform.position.y, ballObject.transform.position.z - transform.position.z);
                    enemyVec = enemyVec.normalized * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                //�ړ������x�N�g���̐ݒ�
                {
                    //�ړ������x�N�g���̏�����
                    enemyVec = Vector3.zero;

                    //�ړ������x�N�g���̐ݒ�
                    enemyVec = new Vector3(userGoal.transform.position.x - transform.position.x, userGoal.transform.position.y - transform.position.y, userGoal.transform.position.z - transform.position.z);
                    enemyVec = enemyVec.normalized * moveSpeed * Time.deltaTime;
                }
            }
            //�ړ���
            if (enemyVec.magnitude > 0)
            {
                //���[�U�[�̉�]
                {
                    nextPos = transform.position + enemyVec;
                    pos = transform.position;

                    //Vector3.SmoothDamp��Vector3�^�̒l�����X�ɕω������� //Vector3.SmoothDamp (���ݒn, �ړI�n, ref ���݂̑��x, �J�ڎ���, �ō����x)
                    angle = Mathf.SmoothDampAngle(0, Vector3.Angle(transform.forward, nextPos - pos), ref turnSpeed, smoothTime, maxAngularVelocity);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextPos - pos, Vector3.up), angle);
                }

                //Stage�Ƃ̏Փ˔���
                if (!stage.Collision(transform.position + enemyVec))
                {
                    //���[�U�[�̈ړ�
                    transform.position += enemyVec;
                }
            }
        }
        else
        {

        }
    }

    public void SetUp(GameObject userGoal, Stage stage, Ball ball, Game_C game_C)
    {
        this.ballObject = ball.gameObject;
        this.userGoal = userGoal;
        this.stage = stage;
        this.enemyModel_C = this.gameObject.GetComponent<EnemyModel_C>();
        this.ball = ball;
        this.game_C = game_C;
    }

    void MoveSpeedUp()
    {
        enemyModel_C.hp -= 10;
        moveSpeed = 20.0f;
        Invoke("ResetMoveSpeed", 0.5f);
    }

    void ResetMoveSpeed()
    {
        moveSpeed = 10.0f;
    }

    public bool IsEnemy
    {
        set
        {
            isEnemy = value;
        }
    }
}
