using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    [SerializeField] Game game; //���C���X�N���v�g
    [SerializeField] Stage stage; //�X�e�[�W
    [SerializeField] MainCamera camera; //�Ǐ]����J����
    public float moveSpeed = 5.0f; //�ړ����x
    public float turnSpeed = 0.2f; //�U��������x
    Vector3 vector; //�ړ�����

    void Start()
    {
        
    }

    void Update()
    {
        if (!game.isCommand)
        {
            Vector3 forward = Vector3.Scale(camera.transform.forward, new Vector3(1, 1, 1)).normalized;
            Vector3 right = Vector3.Scale(camera.transform.right, new Vector3(1, 1, 1)).normalized;

            vector = Vector3.zero;

            //�ړ�����
            if (Input.GetKey(KeyCode.W))
            {
                vector = forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                vector = -1 * right;
            }
            if (Input.GetKey(KeyCode.S))
            {
                vector = -1 * forward;
            }
            if (Input.GetKey(KeyCode.D))
            {
                vector = right;
            }

            //�ړ������x�N�g���̒P�ʃx�N�g��
            vector = vector.normalized * moveSpeed * Time.deltaTime;

            //�ړ�����ꍇ
            if (vector.magnitude > 0)
            {
                //��]�p�̌��� //Quaternion.Slerp(�O��Quaternion�l,���Quaternion�l,�ω�����)
               
                //�ʒu�̌���
                if (!stage.Collision(transform.position + vector))
                {
                    transform.position += vector;
                }
            }
        }
    }

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "NPC")
        {
            game.Command();
        }
    }
}
