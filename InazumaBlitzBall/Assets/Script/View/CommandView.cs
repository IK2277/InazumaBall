using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//コマンド画面に関するスクリプト
public class CommandView : MonoBehaviour
{
	//public変数
	[SerializeField] Button shootButton; //ShootButtonのButton
	[SerializeField] Button passButton; //PassButtonのButton

	void Start()
	{

	}

	void Update()
	{

	}

	//ShootButtonのクリック判定
	public Button.ButtonClickedEvent OnShootButton
	{
		get
		{
			return shootButton.onClick;
		}
	}

	//PassButtonのクリック判定
	public Button.ButtonClickedEvent OnPassButton
	{
		get
		{
			return passButton.onClick;
		}
	}
}
