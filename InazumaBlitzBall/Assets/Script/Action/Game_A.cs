using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//初期設定,戦闘システムの制御(Actition)
public class Game_A : MonoBehaviour
{
    //public変数
    [SerializeField] GameObject user; //Userオブジェクト
    [SerializeField] MainCamera mainCamera; //MainCameraスクリプト

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
        //オブジェクト生成
        {

        }

        //オブジェクトの初期配置設定
        {
            mainCamera.SetFrontObject(user);
        }
    }
}
