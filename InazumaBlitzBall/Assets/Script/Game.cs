using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject mainCamera; //���C���J�����I�u�W�F�N�g
    [SerializeField] GameObject commandView; //�R�}���hUI�I�u�W�F�N�g
    [SerializeField] GameObject user; //���[�U�[�I�u�W�F�N�g
    public bool isCommand = false; //�R�}���h��ʔ���

    void Start()
    {
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
            mainCamera.transform.position = user.transform.position + new Vector3(0, 2, -5);
        }
    }

    //�R�}���h���
    public void Command()
    {
        isCommand = true;
        commandView.SetActive(true);
    }
}
