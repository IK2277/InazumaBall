using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//コマンドUIの制御(Command)
public class CommandView_C : MonoBehaviour
{
	//public変数
	[SerializeField] GameObject uve; //UvEオブジェクト
	[SerializeField] GameObject uvb; //UvBオブジェクト
	[SerializeField] GameObject uvg; //UvGオブジェクト
	[SerializeField] GameObject onPassPanel; //OnPassPanelオブジェクト
											 //private変数
	GameObject selectedPanel; //操作中のパネル
	Button passButton; //操作パネルのPassButton
	Button dribbleButton; //操作パネルのDribbleButton
	Button passCutButton; //操作パネルのPassCutButton
	Button shootButton; //操作パネルのShootButton

	void Start()
	{

	}

	void Update()
	{

	}

	//操作中のパネル設定
	public void SelectedPanel(string panelName)
	{
		//UvEパネル操作
		if (panelName == "UvE")
		{
			//パネル表示
			uve.SetActive(true);
			//Button設定
			passButton = uve.transform.Find("PassButton").gameObject.GetComponent<Button>();
			dribbleButton = uve.transform.Find("DribbleButton").gameObject.GetComponent<Button>();
		}

		//UvBパネル操作
		if (panelName == "UvB")
		{
			//パネル表示
			uvb.SetActive(true);
			//Button設定
			passCutButton = uvb.transform.Find("PassCutButton").gameObject.GetComponent<Button>();
		}

		//UvGパネル操作
		if (panelName == "UvG")
		{
			//パネル表示
			uvg.SetActive(true);
			//Button設定
			shootButton = uvg.transform.Find("ShootButton").gameObject.GetComponent<Button>();
		}

		//OnPassPanelパネル操作
		if (panelName == "OnPassPanel")
		{
			//パネル表示
			onPassPanel.SetActive(true);
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
		uvb.SetActive(false);
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
	public Button.ButtonClickedEvent OnDribbleButton
	{
		get
		{
			return dribbleButton.onClick;
		}
	}
	public Button.ButtonClickedEvent OnPassCutButton
	{
		get
		{
			return passCutButton.onClick;
		}
	}
	public Button.ButtonClickedEvent OnShootButton
	{
		get
		{
			return shootButton.onClick;
		}
	}
}
