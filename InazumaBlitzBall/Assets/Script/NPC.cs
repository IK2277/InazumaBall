using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Game game; //���C���X�N���v�g
    [SerializeField] Stage stage; //�X�e�[�W�X�N���v�g

    void Start()
    {
        
    }

    void Update()
    {
        //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
        if (!game.isCommand)
        {

        }
    }
}
