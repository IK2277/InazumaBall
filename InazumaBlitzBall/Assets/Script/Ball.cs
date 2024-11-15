using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{�[���Ɋւ���X�N���v�g
public class Ball : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject lastUser;
    [SerializeField] MainCamera mainCamera;
    [SerializeField] Stage stage;
    [SerializeField] Game_C game_C;
    public int power = 0;
    public bool userBall = true;
    //private�ϐ�
    GameObject collisionObject; //�Փ˂����I�u�W�F�N�g
    GameObject ballCatch; //collisionObject�̎q�I�u�W�F�N�g(BallCatch)
    float ballSpeed = 10.0f;
    Vector3 vec;


    void Start()
    {

    }

    void Update()
    {
        //�Փ˂Ɣ�Փ˂ł̋@�\�؂�ւ�
        if(collisionObject != null)
        {
            transform.position = transform.parent.transform.position;
        }
        if (stage.Collision(transform.position))
        {
            vec = this.transform.GetComponent<Rigidbody>().velocity;
            this.transform.GetComponent<Rigidbody>().velocity = new Vector3(-0.1f * vec.x, -0.1f * vec.y, -0.1f * vec.z);
        }
    }

    //�{�[������
    public void Throw(Vector3 vector)
    {
        collisionObject = null;
        transform.parent = null;
        gameObject.GetComponent<Rigidbody>().velocity = vector * ballSpeed;
        mainCamera.SetFrontObject(this.gameObject);
        Invoke("ThrowDelay", 0.5f);
    }

    void ThrowDelay()
    {
        ColliderAvailable = true;
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

        power = 0;

        if (catchObject.gameObject.name == "User(Clone)")
        {
            userBall = true;
            lastUser = catchObject;
            mainCamera.SetFrontObject(catchObject);
            catchObject.gameObject.GetComponent<UserModel_A>().IsUser = true;
        }
        if (catchObject.gameObject.name == "Enemy(Clone)")
        {
            userBall = false;
            mainCamera.SetFrontObject(lastUser);
            lastUser.gameObject.GetComponent<UserModel_A>().IsUser = true;
            catchObject.GetComponent<EnemyModel_A>().IsEnemy = true;
        }
        if (catchObject.gameObject.name == "Keeper")
        {
            if (userBall) { userBall = false; } else { userBall = true; }
            mainCamera.SetFrontObject(catchObject);
        }

        game_C.IsCommand = false;
    }

    //Collider�̃I���I�t�؂�ւ�
    public bool ColliderAvailable
    {
        set
        {
            gameObject.GetComponent<SphereCollider>().enabled = value;
        }
    }

    public bool UserBall
    {
        set
        {
            userBall = value;
        }
    }
}
