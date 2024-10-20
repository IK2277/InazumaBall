using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//���[�U�[�̐���(Command)
public class UserModel_C : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] GameObject goal; //Goal�I�u�W�F�N�g
    [SerializeField] Ball ball; //Ball�X�N���v�g
    [SerializeField] Game_C game_C; //Game�X�N���v�g
    //private�ϐ�
    Vector3 goalVec; //�S�[�������x�N�g��
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

    //�V���[�g�s��
    public void Shoot()
    {
        goalVec = new Vector3(goal.transform.position.x - transform.position.x, goal.transform.position.y - transform.position.y, goal.transform.position.z - transform.position.z);
        goalVec = goalVec.normalized * 200.0f;
        ball.Throw(goalVec);
    }

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //Enemy�Ƃ̏Փ˔���
        if (collision.gameObject.name == "Enemy")
        {
            game_C.Command("UvE");
        }

        //Ball�Ƃ̏Փ˔���
        if (collision.gameObject.name == "Ball")
        {
            //�����{�[���ƓG�{�[���ŋ@�\�؂�ւ�
            if (collision.gameObject.GetComponent<Ball>().teamBall)
            {
                collision.gameObject.GetComponent<Ball>().Catch(this.gameObject);
            }
            else
            {
                game_C.Command("UvB");
            }
        }

        //�S�[���Ƃ̏Փ˔���
        if (collision.gameObject.name == "Goal")
        {
            game_C.Command("UvG");
        }
    }
}