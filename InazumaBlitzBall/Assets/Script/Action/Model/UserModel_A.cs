using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//���[�U�[�̐���(Action)
public class UserModel_A : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] MainCamera mainCamera; //MainCamera�X�N���v�g
    [SerializeField] Stage stage; //Stage�X�N���v�g
    [SerializeField] Game_C game_C; //Game�X�N���v�g]
    public bool isUser = true; //���쒆����
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
        
    }

    void Update()
    {
        //User��NPC�ł̋@�\�؂�ւ�
        if (isUser)
        {
            //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
            if (!game_C.isCommand)
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
                    }

                    //�ړ������x�N�g���̐ݒ�
                    userVec = userVec.normalized * moveSpeed * Time.deltaTime;
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
        else
        {

        }
    }
}