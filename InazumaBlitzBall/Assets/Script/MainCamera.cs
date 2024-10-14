using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Game game; //���C���X�N���v�g
    [SerializeField] GameObject user; //���[�U�[�I�u�W�F�N�g

    //private�ϐ�
    Vector3 pos; //�v���C���[�̌��ݒn
    Vector3 pastPos; //�v���C���[�̉ߋ��ʒu

    void Start()
    {
        pastPos = user.transform.position;
    }

    void Update()
    {
        //�J�����̉�]
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            if (Mathf.Abs(mx) > 0.01f)
            {
                transform.RotateAround(user.transform.position, Vector3.up, mx);
            }
            if (Mathf.Abs(my) > 0.01f)
            {
                transform.RotateAround(user.transform.position, transform.right, -my);
            }
        }

        //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
        if (!game.isCommand)
        {
            //�J�����̈ʒu
            {
                pos = user.transform.position;
                transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
                pastPos = pos;
            }
        }
        else
        {

        }
    }
}
