using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//�����ݒ�,�퓬�V�X�e���̐���(Actition)
public class Game_A : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject user; //User�I�u�W�F�N�g
    [SerializeField] MainCamera mainCamera; //MainCamera�X�N���v�g

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
        //�I�u�W�F�N�g����
        {

        }

        //�I�u�W�F�N�g�̏����z�u�ݒ�
        {
            mainCamera.SetFrontObject(user);
        }
    }
}
