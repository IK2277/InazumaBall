using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//エネミーの制御(Action)
public class EnemyModel_A : MonoBehaviour
{
    //public変数
    [SerializeField] Stage stage; //Stageスクリプト
    [SerializeField] Game_C game_C; //Gameスクリプト
    void Start()
    {
        
    }

    void Update()
    {
        //アクションとコマンドでの機能切り替え
        if (!game_C.isCommand)
        {

        }
        else
        {

        }
    }
}
