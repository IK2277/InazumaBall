using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//初期設定,戦闘システムの制御(Command)
public class Game_C : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject commandView; //CommandViewオブジェクト
    public bool isCommand = false; //コマンド画面判定
    //private変数
    CommandView_C commandView_C; //CommandViewスクリプト

    void Start()
    {
        //変数の代入
        {
            commandView_C = commandView.GetComponent<CommandView_C>();
        }

        SetupGame();
    }

    void Update()
    {
        
    }

    //試合の初期設定
    void SetupGame()
    {
        //モデル設定
        {

        }
    }

    //コマンド開始
    public void Command(UserModel_C userModel_C,string panelName)
    {
        isCommand = true;
        commandView.SetActive(true);
        commandView_C.SelectedPanel(userModel_C, panelName);
    }
}
