using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//���[�U�[�Ɋւ���X�N���v�g
public class UserModel : MonoBehaviour
{
    //public�ϐ�
    [SerializeField] MainCamera camera; //MainCamera�X�N���v�g
    [SerializeField] Stage stage; //Stage�X�N���v�g
    [SerializeField] Ball ball; //Ball�X�N���v�g
    [SerializeField] Game game; //Game�X�N���v�g]
    public bool isKeeper = false; //�L�[�p�[����
    public bool isUser = true; //���쒆����
    public bool isBallCatch = false;//�{�[����������.
    public float moveSpeed = 5.0f; //�ړ����x

    //private�ϐ�
    Vector3 userVec; //�ړ������x�N�g��
    Vector3 forward; //�J�����̑O����
    Vector3 right; //�J�����̉E����
    Vector3 nextPos; //���[�U�[�̎����W
    Vector3 pos; //���[�U�[�̌��ݍ��W
    float turnSpeed = 0.2f; //�U��������x
    float smoothTime = 0.1f; //�i�s�����ɂ����邨���悻�̎���
    float maxAngularVelocity = Mathf.Infinity; //�ő�̉�]�p���x
    float angle; //��]�p�x

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
        //��E�ł̋@�\�؂�ւ�
        if (!isKeeper)
        {
            //User��NPC�ł̋@�\�؂�ւ�
            if (isUser)
            {
                //�A�N�V�����ƃR�}���h�ł̋@�\�؂�ւ�
                if (!game.isCommand)
                {
                    //�ړ������x�N�g���̐ݒ�
                    {
                        forward = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;
                        right = Vector3.Scale(camera.transform.right, new Vector3(1, 0, 1)).normalized;

                        userVec = Vector3.zero;

                        //�ړ�����
                        if (Input.GetKey(KeyCode.W))
                        {
                            userVec = forward;
                        }
                        if (Input.GetKey(KeyCode.A))
                        {
                            userVec = -1 * right;
                        }
                        if (Input.GetKey(KeyCode.S))
                        {
                            userVec = -1 * forward;
                        }
                        if (Input.GetKey(KeyCode.D))
                        {
                            userVec = right;
                        }
                        if (Input.GetKey(KeyCode.Space))
                        {
                            userVec += new Vector3(0, 1, 0);
                        }
                        if (Input.GetKey(KeyCode.LeftShift))
                        {
                            userVec += new Vector3(0, -1, 0);
                        }

                        //�ړ������x�N�g���̒P�ʃx�N�g��
                        userVec = userVec.normalized * moveSpeed * Time.deltaTime;
                    }

                    //�ړ�����ꍇ
                    if (userVec.magnitude > 0)
                    {
                        //���[�U�[�̉�]
                        {
                            nextPos = transform.position + userVec;
                            pos = transform.position;

                            //Vector3.SmoothDamp��Vector3�^�̒l�����X�ɕω������� //Vector3.SmoothDamp (���ݒn, �ړI�n, ref ���݂̑��x, �J�ڎ���, �ō����x)
                            angle = Mathf.SmoothDampAngle(0, Vector3.Angle(transform.forward, nextPos - pos), ref turnSpeed, smoothTime, maxAngularVelocity);

                            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(nextPos - pos, Vector3.up), angle);
                        }

                        //Stage�Ƃ̏Փ˔���
                        if (!stage.Collision(transform.position + userVec))
                        {
                            //���[�U�[�̈ړ�
                            transform.position += userVec;
                        }
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }
        else
        {

        }
    }

    //�V���[�g�I����
    public void Shoot()
    {
        ball.Throw(forward * 200.0f);
    }

    //�p�X�I����
    public void Pass()
    {
        Debug.Log("�`�[�����C�g�����܂���B");
    }

    //�Փ˔���
    void OnCollisionEnter(Collision collision)
    {
        //Enemy�Ƃ̏Փ˔���
        if (collision.gameObject.name == "Enemy")
        {
            game.Command();
        }
    }
}
