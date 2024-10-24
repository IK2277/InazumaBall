using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//�����ݒ�,�퓬�V�X�e���̐���(Command)
public class Game_C : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject ui; //UI�I�u�W�F�N�g
    [SerializeField] GameObject commandView; //CommandView�I�u�W�F�N�g
    [SerializeField] GameObject user; //User�I�u�W�F�N�g
    public bool isCommand = false; //�R�}���h��ʔ���
    //private�ϐ�
    CommandView_C commandView_C; //CommandView�X�N���v�g
    UserModel_C userModel_C; //UserModel�X�N���v�g

    void Start()
    {
        //�ϐ��̑��
        {
            commandView_C = commandView.GetComponent<CommandView_C>();
        }

        SetupGame();
    }

    void Update()
    {
        if (isCommand)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                commandView_C.selectCommand--;
                if (commandView_C.selectCommand < 0)
                {
                    commandView_C.selectCommand = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                commandView_C.selectCommand++;
                if (commandView_C.selectCommand > 1)
                {
                    commandView_C.selectCommand = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (commandView_C.selectCommand == 0)
                {
                    Debug.Log("�p�X");
                }
                if (commandView_C.selectCommand == 1)
                {
                    Debug.Log("�h���u��");
                }
            }
        }
        if (commandView_C.selectCommand == 1)
        {
            commandView_C.PassImage.enabled = false;
            commandView_C.DribbleImage.enabled = true;
        }
        if (commandView_C.selectCommand == 0)
        {
            commandView_C.PassImage.enabled = true;
            commandView_C.DribbleImage.enabled = false;
        }
        
    }

    //�����̏����ݒ�
    void SetupGame()
    {
        //���f���ݒ�
        {
            userModel_C = user.GetComponent<UserModel_C>();
        }
    }

    //�R�}���h�J�n
    public void Command(string panelName)
    {
        isCommand = true;
        ui.SetActive(false);
        commandView.SetActive(true);
        if (panelName == "UvE")
        {
            commandView_C.SelectedPanel(panelName);
            //�֐��̌Ăяo���ݒ�
            {
                commandView_C.OnPassButton.AddListener(Pass);
                commandView_C.OnDribbleButton.AddListener(Dribble);
                
            }
        }
        if (panelName == "UvB")
        {
            commandView_C.SelectedPanel(panelName);
            //�֐��̌Ăяo���ݒ�
            {
                commandView_C.OnPassCutButton.AddListener(PassCut);
            }
        }
        if (panelName == "UvG")
        {
            commandView_C.SelectedPanel(panelName);
            //�֐��̌Ăяo���ݒ�
            {
                commandView_C.OnShootButton.AddListener(Shoot);
            }
        }
    }

    //�p�X�I����
    public void Pass()
    {
        commandView_C.ButtonReset();
        commandView_C.SelectedPanel("OnPassPanel");
        //�֐��̌Ăяo���ݒ�
        {

        }
    }

    //�h���u���I����
    public void Dribble()
    {

    }

    //�p�X�J�b�g�I����
    public void PassCut()
    {

    }

    //�V���[�g�I����
    public void Shoot()
    {
        userModel_C.Shoot();
        Debug.Log("Shoot()");
    }
}
