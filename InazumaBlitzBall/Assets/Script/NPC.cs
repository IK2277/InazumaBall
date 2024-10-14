using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //public変数
    [SerializeField] Game game; //メインスクリプト
    [SerializeField] Stage stage; //ステージスクリプト

    void Start()
    {
        
    }

    void Update()
    {
        //アクションとコマンドでの機能切り替え
        if (!game.isCommand)
        {

        }
    }
}
