using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Game game; //���C���X�N���v�g
    [SerializeField] GameObject user; //���[�U�[
    Vector3 distance; //���[�U�[����̋���
    Vector3 pos; //�v���C���[�̌��ݒn
    Vector3 pastPos; //�v���C���[�̉ߋ��ʒu

    void Start()
    {
        distance = new Vector3(0, 2, -5);
        transform.position = user.transform.position + distance;
        pastPos = user.transform.position;
    }

    void Update()
    {
        //��]�̐ݒ�
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


        if (!game.isCommand)
        {
            //�ʒu�̐ݒ�
            pos = user.transform.position;
            transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
            pastPos = pos;
        }
    }
}
