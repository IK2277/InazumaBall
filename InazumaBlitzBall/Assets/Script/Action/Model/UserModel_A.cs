using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//���[�U�[�̐���(Action)
public class UserModel_A : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject enemyGoal;
    [SerializeField] MainCamera mainCamera; //MainCamera�X�N���v�g
    [SerializeField] Stage stage; //Stage�X�N���v�g
    [SerializeField] UserModel_C userModel_C;
    [SerializeField] Ball ball;
    [SerializeField] Game_C game_C; //Game�X�N���v�g
    public bool isUser = false; //���쒆����
    public float moveSpeed = 5.0f; //�ړ����x
    //private�ϐ�
    Vector3 userVec; //�ړ������x�N�g��
    Vector3 forward; //�J�����̑O����
    Vector3 right; //�J�����̉E����
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
            //User��NPC�ł̋@�\�؂�ւ�
            if (isUser)
            {
                //�ړ������x�N�g���̐ݒ�
                {
                    //�O�����ƉE�����̐ݒ�
                    forward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
                    right = Vector3.Scale(mainCamera.transform.right, new Vector3(1, 0, 1)).normalized;

                    //�ړ������x�N�g���̏�����
                    userVec = Vector3.zero;

                    //�ړ��L�[���͐ݒ�
                    {
                        if (Input.GetKey(KeyCode.W))
                        {
                            userVec = forward;
                        }
                        if (Input.GetKey(KeyCode.A))
                        {
                            userVec = -1 * right;
                        }
                        if (Input.GetKey(KeyCode.S))
                        {
                            userVec = -1 * forward;
                        }
                        if (Input.GetKey(KeyCode.D))
                        {
                            userVec = right;
                        }
                        if (Input.GetKey(KeyCode.Space))
                        {
                            userVec += new Vector3(0, 1, 0);
                        }
                        if (Input.GetKey(KeyCode.LeftShift))
                        {
                            userVec += new Vector3(0, -1, 0);
                        }

                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            userModel_C.hp -= 10;
                            moveSpeed = 20.0f;
                            Invoke("ResetMoveSpeed", 0.5f);
                        }
                    }
                    //�ړ������x�N�g���̐ݒ�
                    userVec = userVec.normalized * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (ball.userBall)
                {
                    //�ړ������x�N�g���̐ݒ�
                    {
                        //�ړ������x�N�g���̏�����
                        userVec = Vector3.zero;

                        //�ړ������x�N�g���̐ݒ�
                        userVec = new Vector3(enemyGoal.transform.position.x - transform.position.x, enemyGoal.transform.position.y - transform.position.y, enemyGoal.transform.position.z - transform.position.z);
                        userVec = userVec.normalized * moveSpeed * Time.deltaTime;
                    }
                }
                else
                {
                    //�ړ������x�N�g���̐ݒ�
                    {
                        ballObject = GameObject.Find("Ball");
                        //�ړ������x�N�g���̏�����
                        userVec = Vector3.zero;

                        //�ړ������x�N�g���̐ݒ�
                        userVec = new Vector3(ballObject.transform.position.x - transform.position.x, ballObject.transform.position.y - transform.position.y, ballObject.transform.position.z - transform.position.z);
                        userVec = userVec.normalized * moveSpeed * Time.deltaTime;
                    }
                }
            }
            //�ړ���
            if (userVec.magnitude > 0)
            {
                //���[�U�[�̉�]
                {
                    nextPos = transform.position + userVec;
                    pos = transform.position;

                    //Vector3.SmoothDamp��Vector3�^�̒l�����X�ɕω������� //Vector3.SmoothDamp (���ݒn, �ړI�n, ref ���݂̑��x, �J�ڎ���, �ō����x)
                    angle = Mathf.SmoothDampAngle(0, Vector3.Angle(transform.forward, nextPos - pos), ref turnSpeed, smoothTime, maxAngularVelocity);

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextPos - pos, Vector3.up), angle);
                }

                //Stage�Ƃ̏Փ˔���
                if (!stage.Collision(transform.position + userVec))
                {
                    //���[�U�[�̈ړ�
                    transform.position += userVec;
                }
            }

        }
        else
        {

        }
        
    }

    public void SetUp(GameObject enemyGoal, MainCamera mainCamera,Stage stage, Ball ball, Game_C game_C)
    {
        this.ballObject = ball.gameObject;
        this.enemyGoal = enemyGoal;
        this.mainCamera = mainCamera;
        this.stage = stage;
        this.ball = ball;
        this.userModel_C = this.gameObject.GetComponent<UserModel_C>();
        this.game_C = game_C;
    }

    void ResetMoveSpeed()
    {
        moveSpeed = 10.0f;
    }

    public bool IsUser
    {
        set
        {
            isUser = value;
        }
    }
}
