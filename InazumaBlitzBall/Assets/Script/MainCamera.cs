using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���[�U�[���f���J�����Ɋւ���X�N���v�g
public class MainCamera : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Game game; //Game�X�N���v�g
    [SerializeField] GameObject user; //User�I�u�W�F�N�g
    public float sensitivity = 1.0f; //�J�������x

    //private�ϐ�
    Vector3 pos; //User�̌��ݒn
    Vector3 pastPos; //User�̉ߋ��ʒu

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
                transform.RotateAround(user.transform.position, Vector3.up, mx * sensitivity);
            }
            if (Mathf.Abs(my) > 0.01f)
            {
                transform.RotateAround(user.transform.position, transform.right, -my * sensitivity);
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
