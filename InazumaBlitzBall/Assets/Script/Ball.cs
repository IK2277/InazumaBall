using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{�[���Ɋւ���X�N���v�g
public class Ball : MonoBehaviour
{
    //private�ϐ�
    GameObject collisionObject; //�Փ˂����I�u�W�F�N�g
    GameObject ballCatch; //collisionObject�̎q�I�u�W�F�N�g(BallCatch)

    void Start()
    {

    }

    void Update()
    {
        //�Փ˂Ɣ�Փ˂ł̋@�\�؂�ւ�
        if(collisionObject != null)
        {
            //�Փ˂����I�u�W�F�N�g�̏Փ˔͈͂��痣�ꂽ�ꍇ
            if ((collisionObject.GetComponent<SphereCollider>().radius)* 1.5f < (gameObject.transform.position - collisionObject.transform.position).magnitude)
            {
                collisionObject = null;
                transform.parent = null;
                ColliderAvailable = true;
            }
        }
    }

    //�{�[������
    public void Throw(Vector3 vector)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(vector);
    }


    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //User��������Enemy�Ƃ̏Փ˔���
        if (collision.gameObject.name == "User" || collision.gameObject.name == "Enemy")
        {
            collisionObject = collision.gameObject;
            ballCatch = collisionObject.transform.Find("BallCatch").gameObject;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collisionObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = new Vector3(ballCatch.transform.position.x, ballCatch.transform.position.y, ballCatch.transform.position.z);
            ColliderAvailable = false;
            transform.SetParent(ballCatch.transform);
        }
    }

    //Collider�̃I���I�t�؂�ւ�
    bool ColliderAvailable
    {
        set
        {
            gameObject.GetComponent<SphereCollider>().enabled = value;
        }
    }
}
