using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    //�G�l�~�[�̏�Ԃ�t���O���Ǘ��B�S�������ɓ����B
    //����ɑ��̃X�N���v�g���m�Ńt���O�̂���������ȁB����������B
    [SerializeField] private int HitPoint = 5;//HP
    [SerializeField] private int atk = 3;//�U����
    [SerializeField] private bool isDiscoverV;//���o�n�b�P���t���O
    [SerializeField] private bool isAttentionV;//���o�x���t���O
    [SerializeField] private bool isDiscoverH;//�������t���O
    [SerializeField] private bool isAttentionH;//���x���t���O
    [SerializeField] private bool isHostile;//�G�΃t���O

    public bool GetSetisHostile{//�G�΃t���O��GetSet�B����͊ȒP�ɕύX�ł��Ă����̂�GetSet�ŏ�����
        get { return isHostile; }
        set { isHostile = value; }
    }

    public void SetisDiscoverV(bool onoff)//���o�����t���O��Set�B�C�y�ɕύX����Ă�����̂�GetSet�͕���
    {
        isDiscoverV = onoff;
    }
    public bool GetisDiscoverV()//���o�����t���O��Get�B
    {
        return isDiscoverV;
    }

    public void SetisAttentionV(bool onoff)
    {
        isAttentionV = onoff;
    }
    public bool GetisAttentionV()//���o�x���t���O��Get�B
    {
        return isAttentionV;
    }

    public void SetisDiscoverH(bool onoff)
    {
        isDiscoverH = onoff;
    }
    public bool GetisDiscoverH()//���o�����t���O��Get�B
    {
        return isDiscoverH;
    }

    public void SetisAttentionH(bool onoff)
    {
        isAttentionH = onoff;
    }
    public bool GetisAttentionH()//���o�x���t���O��Get�B
    {
        return isAttentionH;
    }

    public int GetAtk(){
        return atk;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        
    }
}
