using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//エネミーに関するスクリプト
public class EnemyModel : MonoBehaviour
{
    //public変数
    [SerializeField] Stage stage; //Stageスクリプト
    [SerializeField] Game game; //Gameスクリプト
    public bool isKeeper = false; //キーパー判定

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //役職での機能切り替え
        if (!isKeeper)
        {
            //アクションとコマンドでの機能切り替え
            if (!game.isCommand)
            {

            }
            else
            {

            }
        }
        else
        {

        }
    }
}
