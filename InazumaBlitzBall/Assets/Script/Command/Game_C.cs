using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//�����ݒ�,�퓬�V�X�e���̐���(Command)
public class Game_C : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject commandView; //CommandView�I�u�W�F�N�g
    public bool isCommand = false; //�R�}���h��ʔ���
    //private�ϐ�
    CommandView_C commandView_C; //CommandView�X�N���v�g

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
        
    }

    //�����̏����ݒ�
    void SetupGame()
    {
        //���f���ݒ�
        {

        }
    }

    //�R�}���h�J�n
    public void Command(UserModel_C userModel_C,string panelName)
    {
        isCommand = true;
        commandView.SetActive(true);
        commandView_C.SelectedPanel(userModel_C, panelName);
    }
}
