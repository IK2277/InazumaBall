using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

//�G�l�~�[�̐���(Command)
public class EnemyModel_C : MonoBehaviour
{
    // �L�����N�^�[�f�[�^(�����X�e�[�^�X)
    [Header("�L�����N�^�[��")]
    public string charaName; // �L�����N�^�[��
    [Header("�ő�HP(����HP)")]
    public int maxHP; // �ő�HP���{�[�������Ă�ƌ����A�A�r���e�B�g�p�Ō����A�Ȃ��Ȃ�ƃR�}���h�o�g���͊�{�s�k.
    [Header("�X�s�[�h")]
    public int spd; // �X�s�[�h���ړ��̑���.
    [Header("�p�X")]
    public int pas; // �p�X���\�͂������قǃJ�b�g����ɂ����Ȃ�.
    [Header("�V���[�g")]
    public int sht; // �V���[�g �� �\�͂������قǃV���[�g�̈З͂��オ��.
    [Header("�ϋv��")]
    public int phy; // �ϋv�� �� �h���u���̍ہA����̃A�^�b�N�ɑς����邩.
    [Header("�p�X�E�V���[�g�J�b�g")]
    public int cut; // �J�b�g���p�Xor�V���[�g��r���ŃJ�b�g�����.
    [Header("�A�^�b�N")]
    public int atk; // �A�^�b�N���h���u�����~�߂��.
    [Header("�L���b�`")]
    public int cat; // �L���b�`���V���[�g���~�߂��.�����_����70%-150%�ŕϓ�.
    [Header("����")]
    public Attribute attribute; // ����
    [HideInInspector]
    public int nowHP; // ����HP

    public enum Attribute
    {
        Water, // ������
        Fire,  // �Α���
        Wind,  // ������
        Soil,  // �y����
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}
