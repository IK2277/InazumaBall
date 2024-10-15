using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Q�[���V�X�e���Ɋւ���X�N���v�g
public class Game : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject mainCamera; //MainCamera�I�u�W�F�N�g
    [SerializeField] GameObject commandView; //CommandView�I�u�W�F�N�g
    [SerializeField] GameObject user; //User�I�u�W�F�N�g
    [SerializeField] CommandView commandview; //CommandView�X�N���v�g
    public bool isCommand = false; //�R�}���h��ʔ���
    //private�ϐ�
    UserModel userModel; //UserModel�X�N���v�g

    void Start()
    {
        commandview.OnShootButton.AddListener(Shoot);
        commandview.OnPassButton.AddListener(Pass);
        SetupGame();
    }

    void Update()
    {
        
    }

    //�����̏����ݒ�
    void SetupGame()
    {
        //�I�u�W�F�N�g�̏����z�u
        {
            userModel = user.GetComponent<UserModel>();
            mainCamera.transform.position = user.transform.position + new Vector3(0, 2, -5);
        }
    }

    //�R�}���h��ʂ̕\��
    public void Command()
    {
        isCommand = true;
        commandView.SetActive(true);
    }

    //�V���[�g�I����
    public void Shoot()
    {
        userModel.Shoot();
    }

    //�p�X�I����
    public void Pass()
    {
        userModel.Pass();
    }
}
