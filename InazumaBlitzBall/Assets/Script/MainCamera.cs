using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���[�U�[���f���J�����Ɋւ���X�N���v�g
public class MainCamera : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Game_C game_C; //Game�X�N���v�g
    [SerializeField] GameObject frontObject; //�Ǐ]��I�u�W�F�N�g
    public float sensitivity; //�J�������x

    //private�ϐ�
    Vector3 pos; //User�̌��ݒn
    Vector3 pastPos; //User�̉ߋ��ʒu

    void Start()
    {
        sensitivity = 5.0f;
        pastPos = frontObject.transform.position;
    }

    void Update()
    {
        //�J�����̉�]
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            if (Mathf.Abs(mx) > 0.01f)
            {
                transform.RotateAround(frontObject.transform.position, Vector3.up, mx * sensitivity);
            }
            if (Mathf.Abs(my) > 0.01f)
            {
                transform.RotateAround(frontObject.transform.position, transform.right, -my * sensitivity);
            }
        }

        //�J�����̈ʒu
        {
            pos = frontObject.transform.position;
            transform.position = Vector3.Lerp(transform.position, transform.position + pos - pastPos, 1.0f);
            pastPos = pos;
        }
    }

    void Reset()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }
    public void SetFrontObject(GameObject setFrontObject)
    {
        Reset();
        frontObject = setFrontObject;
        pastPos = setFrontObject.transform.position;
        transform.position = setFrontObject.transform.position;
        transform.position += new Vector3(0.0f, 2.0f, -5.0f);
    }
}
