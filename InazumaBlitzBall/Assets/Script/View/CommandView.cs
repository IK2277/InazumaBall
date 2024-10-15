using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//�R�}���h��ʂɊւ���X�N���v�g
public class CommandView : MonoBehaviour
{
	//public�ϐ�
	[SerializeField] Button shootButton; //ShootButton��Button
	[SerializeField] Button passButton; //PassButton��Button

	void Start()
	{

	}

	void Update()
	{

	}

	//ShootButton�̃N���b�N����
	public Button.ButtonClickedEvent OnShootButton
	{
		get
		{
			return shootButton.onClick;
		}
	}

	//PassButton�̃N���b�N����
	public Button.ButtonClickedEvent OnPassButton
	{
		get
		{
			return passButton.onClick;
		}
	}
}
