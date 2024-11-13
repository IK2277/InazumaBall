using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static UnityEditor.ShaderData;

//コマンドUIの制御(Command)
public class CommandView_C : MonoBehaviour
{
	//public変数
	[SerializeField] GameObject uve; //UvEオブジェクト
	[SerializeField] GameObject uvg; //UvGオブジェクト
	[SerializeField] GameObject onPassPanel; //OnPassPanelオブジェクト
    [SerializeField] GameObject onShootPanel; //OnPassPanelオブジェクト
    [SerializeField] Ball ball;
    [SerializeField] Game_C game_C;
    //private変数
    UserModel_C userModel_C;
    Button passButton; //操作パネルのPassButton
    Button passCutButton; //操作パネルのPassCutButton
    Button dribbleButton; //操作パネルのDribbleButton
    Button dribbleCutButton; //操作パネルのDribbleCutButton
    Button shootButton; //操作パネルのShootButton
    Button strongShootButton;
    Button normalShootButton;

    void Start()
	{

	}

	void Update()
	{

	}

	//操作中のパネル設定
	public void SelectedPanel(GameObject user, GameObject collision, string panelName)
	{
        userModel_C = user.GetComponent<UserModel_C>();
        //UvEパネル操作
        if (panelName == "UvE")
		{
            //パネル表示
            uve.SetActive(true);
			//Button設定
			passButton = uve.transform.Find("PassButton").gameObject.GetComponent<Button>();
            passCutButton = uve.transform.Find("PassCutButton").gameObject.GetComponent<Button>();
            dribbleButton = uve.transform.Find("DribbleButton").gameObject.GetComponent<Button>();
            dribbleCutButton = uve.transform.Find("DribbleCutButton").gameObject.GetComponent<Button>();
            passButton.enabled = true;
            passCutButton.enabled = true;
            dribbleButton.enabled = true;
            dribbleCutButton.enabled = true;
            if (userModel_C.hp < 20) { dribbleButton.enabled = false; }
            if (userModel_C.hp < 10) { dribbleCutButton.enabled = false; }

            if (ball.userBall)
			{
                uve.transform.Find("PassButton").gameObject.SetActive(true);
                uve.transform.Find("PassCutButton").gameObject.SetActive(false);
                uve.transform.Find("DribbleButton").gameObject.SetActive(true);
                uve.transform.Find("DribbleCutButton").gameObject.SetActive(false);
			}
			else
			{
                uve.transform.Find("PassButton").gameObject.SetActive(false);
                uve.transform.Find("PassCutButton").gameObject.SetActive(true);
                uve.transform.Find("DribbleButton").gameObject.SetActive(false);
                uve.transform.Find("DribbleCutButton").gameObject.SetActive(true);
            }
            {
                OnPassButton.AddListener(() => {
                    game_C.Battle(user, collision, "Pass");
                    //SelectedPanel(userModel_C, "OnPassPanel");
                    Close();
                });
                OnPassCutButton.AddListener(() => {
                    game_C.Battle(user, collision, "PassCut");
                    Close();
                });
                OnDribbleButton.AddListener(() => {
                    game_C.Battle(user, collision, "Dribble");
                    Close();
                });
                OnDribbleCutButton.AddListener(() => {
                    game_C.Battle(user, collision, "DribbleCut");
                    Close();
                });
            }
        }

		//UvGパネル操作
		if (panelName == "UvG")
		{
			//パネル表示
			uvg.SetActive(true);
            //Button設定
            passButton = uvg.transform.Find("PassButton").gameObject.GetComponent<Button>();
            shootButton = uvg.transform.Find("ShootButton").gameObject.GetComponent<Button>();
            passButton.enabled = true;
            shootButton.enabled = true;
            {
                OnPassButton.AddListener(() => {
					passButton.enabled=false;
                    shootButton.enabled = false;
                    game_C.Battle(user, collision, "Pass");
                    Close();
                });
                OnShootButton.AddListener(() => {
                    passButton.enabled = false;
					shootButton.enabled=false;
					SelectedPanel(user, collision, "OnShootPanel");
                });
            }
        }

        /*
		//OnPassPanelパネル操作
		if (panelName == "OnPassPanel")
		{
			//パネル表示
			onPassPanel.SetActive(true);
		}
        */

        //OnPassPanelパネル操作
        if (panelName == "OnShootPanel")
        {
            //パネル表示
            onShootPanel.SetActive(true);
            //Button設定
            strongShootButton = onShootPanel.transform.Find("StrongShootButton").gameObject.GetComponent<Button>();
            normalShootButton = onShootPanel.transform.Find("NormalShootButton").gameObject.GetComponent<Button>();
            strongShootButton.enabled = true;
            normalShootButton.enabled = true;
            if (userModel_C.hp < 20) { strongShootButton.enabled = false; }

            {
                OnStrongShootButton.AddListener(() => {
                    game_C.Battle(user, collision, "StrongShoot");
                    Close();
                });
                OnNormalShootButton.AddListener(() => {
                    game_C.Battle(user, collision, "NormalShoot");
                    Close();
                });
            }
        }
    }

	//Button設定の初期化
	public void ButtonReset()
	{
		passButton = null;
        passCutButton = null;
        dribbleButton = null;
        dribbleCutButton = null;
        shootButton = null;
        strongShootButton = null;
        normalShootButton = null;
    }

	//全てのパネルを閉じる
	public void Close()
	{
		ButtonReset();
		uve.SetActive(false);
		uvg.SetActive(false);
		onPassPanel.SetActive(false);
        onShootPanel.SetActive(false);
    }

	//Buttonのクリック判定
	public Button.ButtonClickedEvent OnPassButton
	{
		get
		{
			return passButton.onClick;
		}
	}
    public Button.ButtonClickedEvent OnPassCutButton
    {
        get
        {
            return passCutButton.onClick;
        }
    }
    public Button.ButtonClickedEvent OnDribbleButton
	{
		get
		{
			return dribbleButton.onClick;
		}
	}
    public Button.ButtonClickedEvent OnDribbleCutButton
    {
        get
        {
            return dribbleCutButton.onClick;
        }
    }
    public Button.ButtonClickedEvent OnShootButton
	{
		get
		{
			return shootButton.onClick;
		}
	}
    public Button.ButtonClickedEvent OnStrongShootButton
    {
        get
        {
            return strongShootButton.onClick;
        }
    }
    public Button.ButtonClickedEvent OnNormalShootButton
    {
        get
        {
            return normalShootButton.onClick;
        }
    }
}
