using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//初期設定,戦闘システムの制御(Command)
public class Game_C : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject ui; //UIオブジェクト
    [SerializeField] GameObject commandView; //CommandViewオブジェクト
    [SerializeField] GameObject user; //Userオブジェクト
    public bool isCommand = false; //コマンド画面判定
    //private変数
    CommandView_C commandView_C; //CommandViewスクリプト
    UserModel_C userModel_C; //UserModelスクリプト

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
        if (isCommand)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                commandView_C.selectCommand--;
                if (commandView_C.selectCommand < 0)
                {
                    commandView_C.selectCommand = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                commandView_C.selectCommand++;
                if (commandView_C.selectCommand > 1)
                {
                    commandView_C.selectCommand = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (commandView_C.selectCommand == 0)
                {
                    Debug.Log("パス");
                }
                if (commandView_C.selectCommand == 1)
                {
                    Debug.Log("ドリブル");
                }
            }
        }
        if (commandView_C.selectCommand == 1)
        {
            commandView_C.PassImage.enabled = false;
            commandView_C.DribbleImage.enabled = true;
        }
        if (commandView_C.selectCommand == 0)
        {
            commandView_C.PassImage.enabled = true;
            commandView_C.DribbleImage.enabled = false;
        }
        
    }

    //試合の初期設定
    void SetupGame()
    {
        //モデル設定
        {
            userModel_C = user.GetComponent<UserModel_C>();
        }
    }

    //コマンド開始
    public void Command(string panelName)
    {
        isCommand = true;
        ui.SetActive(false);
        commandView.SetActive(true);
        if (panelName == "UvE")
        {
            commandView_C.SelectedPanel(panelName);
            //関数の呼び出し設定
            {
                commandView_C.OnPassButton.AddListener(Pass);
                commandView_C.OnDribbleButton.AddListener(Dribble);
                
            }
        }
        if (panelName == "UvB")
        {
            commandView_C.SelectedPanel(panelName);
            //関数の呼び出し設定
            {
                commandView_C.OnPassCutButton.AddListener(PassCut);
            }
        }
        if (panelName == "UvG")
        {
            commandView_C.SelectedPanel(panelName);
            //関数の呼び出し設定
            {
                commandView_C.OnShootButton.AddListener(Shoot);
            }
        }
    }

    //パス選択時
    public void Pass()
    {
        commandView_C.ButtonReset();
        commandView_C.SelectedPanel("OnPassPanel");
        //関数の呼び出し設定
        {

        }
    }

    //ドリブル選択時
    public void Dribble()
    {

    }

    //パスカット選択時
    public void PassCut()
    {

    }

    //シュート選択時
    public void Shoot()
    {
        userModel_C.Shoot();
        Debug.Log("Shoot()");
    }
}
