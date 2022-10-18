using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCon : MonoBehaviour
{
    private int wind = 0;//�[���}�C�̊������
    private int windMax = 50;//�[���}�C�̍ő�T�C�Y
    private int windLevel = 10;//���̊����̗�
    private int decreaseLevel = 1;//�[���}�C�̌�����
    [SerializeField] private int ActionMode = 1;//�t�H�����[�̃A�N�V�������[�h


    private float actionTimer;//�t�H�����[�A�N�V�������̃^�C�}�[
    private float decreaseTimer;//���X�Ɍ������Ă����Ƃ��̃^�C�}�[

    // Start is called before the first frame update
    public void Awake()
    {
    }

    public int GetActionMode()
    {
        return ActionMode;
    }
    public int GetWindLevel()
    {
        return windLevel;
    }
    public int GetWind()
    {
        return wind;
    }


    public void WindingDecrease() //���X�Ɍ����Ă���
    {
        decreaseTimer += Time.deltaTime;
        if (1.0 < decreaseTimer)
        {
            if (0 <= wind - decreaseLevel)
            {
                wind -= decreaseLevel;
            }
            else
            {
                wind = 0;
            }
            decreaseTimer= 0;
        }
    }

    public void WindingPlus(int windVolume)//��������
    {
        if (windMax < wind + windVolume) {
            wind = windMax;
        }
        else
        {
            wind += windVolume;
        }
    }
    public bool WindingUseCheck(int windVolume)//�����g�p
    {
        if(0 <= wind - windVolume)//�K�v�ʂ��c���Ă���Ƃ�����
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void FollowerController() {
        if (ActionMode == 3)
        {
            if (Input.GetKeyDown("j"))
            {
                FollowerAction(ActionMode);
            }
        }
        else
        {
            if (Input.GetKey("j"))
            {
                FollowerAction(ActionMode);
            }
        }
        if (Input.GetKeyDown("p") && !Input.GetKey("j"))
        {
            WindingPlus(windLevel);
            
        }
        else
        {
            WindingDecrease();
        }
    }

    public void FollowerAction(int Mode)
    {
        switch (Mode)
        {
            case 1:
                Flying();
                break;
            case 2:
                PowerFan();
                break;
            case 3:
                GearPower();
                break;
        }
    }


    //��������\�͂̂��
    public void Flying()//��s�\��
    {
        if (WindingUseCheck(2))
        {
            actionTimer += Time.deltaTime;
            if (0.5 < actionTimer) {
                wind -= 2;
                actionTimer = 0;
            }
        }
        else
        {
            Debug.Log("You try doing Flying, but wind is Empty");
        }
    }
    public void PowerFan()//����O���ɑ���
    {
        if (WindingUseCheck(1))
        {
            Debug.Log("UsingFan");
            actionTimer += Time.deltaTime;
            if (0.5 < actionTimer)
            {
                wind -= 1;
                actionTimer = 0;
            }
        }
        else
        {
            Debug.Log("You try doing Fan, but wind is Empty");
        }
    }
    public void GearPower()
    {
        if (WindingUseCheck(5))
        {
            Debug.Log("UseGear");
            wind -= 5;
        }
        else
        {
            Debug.Log("You try doing Gear, but wind is Empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
