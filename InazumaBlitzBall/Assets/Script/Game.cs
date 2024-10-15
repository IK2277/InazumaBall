using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲームシステムに関するスクリプト
public class Game : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject mainCamera; //MainCameraオブジェクト
    [SerializeField] GameObject commandView; //CommandViewオブジェクト
    [SerializeField] GameObject user; //Userオブジェクト
    [SerializeField] CommandView commandview; //CommandViewスクリプト
    public bool isCommand = false; //コマンド画面判定
    //private変数
    UserModel userModel; //UserModelスクリプト

    void Start()
    {
        commandview.OnShootButton.AddListener(Shoot);
        commandview.OnPassButton.AddListener(Pass);
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
            userModel = user.GetComponent<UserModel>();
            mainCamera.transform.position = user.transform.position + new Vector3(0, 2, -5);
        }
    }

    //コマンド画面の表示
    public void Command()
    {
        isCommand = true;
        commandView.SetActive(true);
    }

    //シュート選択時
    public void Shoot()
    {
        userModel.Shoot();
    }

    //パス選択時
    public void Pass()
    {
        userModel.Pass();
    }
}
