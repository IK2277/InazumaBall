using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    //public•Ï”
    [SerializeField] Transform sphereCenter; //Stage‚Ì’†SÀ•W
    public float sphereRadius = 23.0f; //Stage‚Ì”¼Œa

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Stage‚Æ‚ÌÕ“Ë”»’è
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
