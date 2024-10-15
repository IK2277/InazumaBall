using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//試合会場に関するスクリプト
public class Stage : MonoBehaviour
{
    //public変数
    [SerializeField] Transform sphereCenter; //Stageの中心座標
    public float sphereRadius = 23.0f; //Stageの半径

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Stage範囲内判定
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
