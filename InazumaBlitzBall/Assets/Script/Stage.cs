using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//試合会場に関するスクリプト
public class Stage : MonoBehaviour
{
    //public変数

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Stage範囲内判定
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
