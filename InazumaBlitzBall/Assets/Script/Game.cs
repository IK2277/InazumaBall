using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject mainCamera; //メインカメラオブジェクト
    [SerializeField] GameObject commandView; //コマンドUIオブジェクト
    [SerializeField] GameObject user; //ユーザーオブジェクト
    public bool isCommand = false; //コマンド画面判定

    void Start()
    {
        SetupGame();
    }

    void Update()
    {
        
    }

    //試合の初期設定
    void SetupGame()
    {
        //オブジェクトの初期配置
        {
            mainCamera.transform.position = user.transform.position + new Vector3(0, 2, -5);
        }
    }

    //コマンド画面
    public void Command()
    {
        isCommand = true;
        commandView.SetActive(true);
    }
}
