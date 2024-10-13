using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Game game; //メインスクリプト
    [SerializeField] Stage stage; //ステージ

    void Start()
    {
        
    }

    void Update()
    {
        if (!game.isCommand)
        {

        }
    }
}
