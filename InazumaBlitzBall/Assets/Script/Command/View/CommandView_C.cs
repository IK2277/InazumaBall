using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static UnityEditor.ShaderData;

//�R�}���hUI�̐���(Command)
public class CommandView_C : MonoBehaviour
{
	//public�ϐ�
	[SerializeField] GameObject uve; //UvE�I�u�W�F�N�g
	[SerializeField] GameObject uvg; //UvG�I�u�W�F�N�g
	[SerializeField] GameObject onPassPanel; //OnPassPanel�I�u�W�F�N�g
    [SerializeField] GameObject onShootPanel; //OnPassPanel�I�u�W�F�N�g
    [SerializeField] Ball ball;
    //private�ϐ�
    Button passButton; //����p�l����PassButton
    Button passCutButton; //����p�l����PassCutButton
    Button dribbleButton; //����p�l����DribbleButton
    Button dribbleCutButton; //����p�l����DribbleCutButton
    Button shootButton; //����p�l����ShootButton
    Button strongShootButton;
    Button normalShootButton;

    void Start()
	{

	}

	void Update()
	{

	}

	//���쒆�̃p�l���ݒ�
	public void SelectedPanel(UserModel_C userModel_C, string panelName)
	{
        //UvE�p�l������
        if (panelName == "UvE")
		{
			//�p�l���\��
			uve.SetActive(true);
			//Button�ݒ�
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

		//UvG�p�l������
		if (panelName == "UvG")
		{
			//�p�l���\��
			uvg.SetActive(true);
            //Button�ݒ�
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
		//OnPassPanel�p�l������
		if (panelName == "OnPassPanel")
		{
			//�p�l���\��
			onPassPanel.SetActive(true);
		}
        */

        //OnPassPanel�p�l������
        if (panelName == "OnShootPanel")
        {
            //�p�l���\��
            onShootPanel.SetActive(true);
            //Button�ݒ�
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
