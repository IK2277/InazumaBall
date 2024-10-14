using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Transform sphereCenter; //Stage�̒��S���W
    public float sphereRadius = 23.0f; //Stage�̔��a

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Stage�Ƃ̏Փ˔���
    public bool Collision(Vector3 position)
    {
        if(Vector3.Distance(position, sphereCenter.position) > sphereRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
