using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//�G�l�~�[�Ɋւ���X�N���v�g
public class EnemyModel : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] Stage stage; //Stage�X�N���v�g
    [SerializeField] Game game; //Game�X�N���v�g
    public bool isKeeper = false; //�L�[�p�[����

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��E�ł̋@�\�؂�ւ�
        if (!isKeeper)
        {
            //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
            if (!game.isCommand)
            {

            }
            else
            {

            }
        }
        else
        {

        }
    }
}
