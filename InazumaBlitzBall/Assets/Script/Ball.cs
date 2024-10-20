using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボールに関するスクリプト
public class Ball : MonoBehaviour
{
    //public変数
    public bool teamBall = true;
    //private変数
    GameObject collisionObject; //衝突したオブジェクト
    GameObject ballCatch; //collisionObjectの子オブジェクト(BallCatch)

    void Start()
    {

    }

    void Update()
    {
        //衝突と非衝突での機能切り替え
        if(collisionObject != null)
        {
            //衝突したオブジェクトの衝突範囲から離れた場合
            if ((collisionObject.GetComponent<SphereCollider>().radius)* 1.3f < (gameObject.transform.position - collisionObject.transform.position).magnitude)
            {
                collisionObject = null;
                transform.parent = null;
                ColliderAvailable = true;
            }
        }
    }

    //ボール発射
    public void Throw(Vector3 vector)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(vector);
    }

    public void Catch(GameObject catchObject)
    {
        collisionObject = catchObject;
        ballCatch = collisionObject.transform.Find("BallCatch").gameObject;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        collisionObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = new Vector3(ballCatch.transform.position.x, ballCatch.transform.position.y, ballCatch.transform.position.z);
        ColliderAvailable = false;
        transform.SetParent(ballCatch.transform);
    }

    //Colliderのオンオフ切り替え
    bool ColliderAvailable
    {
        set
        {
            gameObject.GetComponent<SphereCollider>().enabled = value;
        }
    }
}
