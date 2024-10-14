using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class User : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Game game; //���C���X�N���v�g
    [SerializeField] Stage stage; //�X�e�[�W�X�N���v�g
    [SerializeField] MainCamera camera; //�Ǐ]����J�����X�N���v�g
    float moveSpeed = 5.0f; //�ړ����x

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
        //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
        if (!game.isCommand)
        {
            //�ړ������x�N�g���̐ݒ�
            {
                forward = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;
                right = Vector3.Scale(camera.transform.right, new Vector3(1, 0, 1)).normalized;

                userVec = Vector3.zero;

                //�ړ�����
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

                //�ړ������x�N�g���̒P�ʃx�N�g��
                userVec = userVec.normalized * moveSpeed * Time.deltaTime;
            }
            
            //�ړ�����ꍇ
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

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //NPC�Ƃ̏Փ�
        if(collision.gameObject.name == "NPC")
        {
            game.Command();
        }
    }
}
