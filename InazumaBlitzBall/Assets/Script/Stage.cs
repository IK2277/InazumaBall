using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������Ɋւ���X�N���v�g
public class Stage : MonoBehaviour
{
    //public�ϐ�

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Stage�͈͓�����
    public bool Collision(Vector3 position)
    {
        if(Vector3.Distance(position, this.transform.position) > (this.transform.localScale.z/2) || Vector3.Distance(position, this.transform.position) < (-this.transform.localScale.z / 2))
        {            
            return true;
        }
        else
        {
            return false;
        }
    }
}
