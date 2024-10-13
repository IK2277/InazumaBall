using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject commandView;
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
        
    }

    //コマンド画面
    public void Command()
    {
        isCommand = true;
        commandView.SetActive(true);
    }
}
