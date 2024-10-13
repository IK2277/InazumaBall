using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] Transform sphereCenter;
    public float sphereRadius = 23.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

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
