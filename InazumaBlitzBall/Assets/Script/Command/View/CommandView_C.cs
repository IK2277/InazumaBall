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
    //private変数
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
	public void SelectedPanel(UserModel_C userModel_C, string panelName)
	{
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
					passButton.enabled = false;
					passCutButton.enabled = false;
					dribbleButton.enabled = false;
					dribbleCutButton.enabled = false;
                    userModel_C.Pass();
					//SelectedPanel(userModel_C, "OnPassPanel");
                });
                OnPassCutButton.AddListener(() => {
                    userModel_C.PassCut();
                });
                OnDribbleButton.AddListener(() => {
                    userModel_C.Dribble();
                });
                OnDribbleCutButton.AddListener(() => {
                    userModel_C.DribbleCut();
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
                    userModel_C.Pass();
                    //SelectedPanel(userModel_C, "OnPassPanel");
                });
                OnDribbleButton.AddListener(() => {
                    passButton.enabled = false;
					shootButton.enabled=false;
					SelectedPanel(userModel_C, "OnShootPanel");
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
            normalShootButton = uvg.transform.Find("NormalShootButton").gameObject.GetComponent<Button>();
            {
                OnStrongShootButton.AddListener(() => {
                    userModel_C.Shoot();
                });
                OnNormalShootButton.AddListener(() => {
                    userModel_C.Shoot();
                });
            }
        }
    }

	//Button設定の初期化
	public void ButtonReset()
	{
		passButton = null;
		dribbleButton = null;
		passCutButton = null;
		shootButton = null;
	}

	//全てのパネルを閉じる
	public void Close()
	{
		ButtonReset();
		uve.SetActive(false);
		uvg.SetActive(false);
		onPassPanel.SetActive(false);
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
