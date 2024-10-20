using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//�R�}���hUI�̐���(Command)
public class CommandView_C : MonoBehaviour
{
	//public�ϐ�
	[SerializeField] GameObject uve; //UvE�I�u�W�F�N�g
	[SerializeField] GameObject uvb; //UvB�I�u�W�F�N�g
	[SerializeField] GameObject uvg; //UvG�I�u�W�F�N�g
	[SerializeField] GameObject onPassPanel; //OnPassPanel�I�u�W�F�N�g
											 //private�ϐ�
	GameObject selectedPanel; //���쒆�̃p�l��
	Button passButton; //����p�l����PassButton
	Button dribbleButton; //����p�l����DribbleButton
	Button passCutButton; //����p�l����PassCutButton
	Button shootButton; //����p�l����ShootButton

	void Start()
	{

	}

	void Update()
	{

	}

	//���쒆�̃p�l���ݒ�
	public void SelectedPanel(string panelName)
	{
		//UvE�p�l������
		if (panelName == "UvE")
		{
			//�p�l���\��
			uve.SetActive(true);
			//Button�ݒ�
			passButton = uve.transform.Find("PassButton").gameObject.GetComponent<Button>();
			dribbleButton = uve.transform.Find("DribbleButton").gameObject.GetComponent<Button>();
		}

		//UvB�p�l������
		if (panelName == "UvB")
		{
			//�p�l���\��
			uvb.SetActive(true);
			//Button�ݒ�
			passCutButton = uvb.transform.Find("PassCutButton").gameObject.GetComponent<Button>();
		}

		//UvG�p�l������
		if (panelName == "UvG")
		{
			//�p�l���\��
			uvg.SetActive(true);
			//Button�ݒ�
			shootButton = uvg.transform.Find("ShootButton").gameObject.GetComponent<Button>();
		}

		//OnPassPanel�p�l������
		if (panelName == "OnPassPanel")
		{
			//�p�l���\��
			onPassPanel.SetActive(true);
		}
	}

	//Button�ݒ�̏�����
	public void ButtonReset()
	{
		passButton = null;
		dribbleButton = null;
		passCutButton = null;
		shootButton = null;
	}

	//�S�Ẵp�l�������
	public void Close()
	{
		ButtonReset();
		uve.SetActive(false);
		uvb.SetActive(false);
		uvg.SetActive(false);
		onPassPanel.SetActive(false);
	}

	//Button�̃N���b�N����
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
