using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject commandView;
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
        
    }

    //�R�}���h���
    public void Command()
    {
        isCommand = true;
        commandView.SetActive(true);
    }
}
