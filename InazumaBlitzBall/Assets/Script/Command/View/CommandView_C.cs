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
    [SerializeField] Game_C game_C;
    //private�ϐ�
    UserModel_C userModel_C;
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
	public void SelectedPanel(GameObject user, GameObject collision, string panelName)
	{
        userModel_C = user.GetComponent<UserModel_C>();
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

	//Button�ݒ�̏�����
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

	//�S�Ẵp�l�������
	public void Close()
	{
		ButtonReset();
		uve.SetActive(false);
		uvg.SetActive(false);
		onPassPanel.SetActive(false);
        onShootPanel.SetActive(false);
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
