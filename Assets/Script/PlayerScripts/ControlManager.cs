using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    //�v���C���[�Ŏ��R�ɓ���������̂̊Ǘ�������
    GameObject PauseMenu;
    PauseMenuMovingScript pauseMovingScript;

    GameObject Actor;
    PlayerCon playerConScript;

    GameObject ActorCore;
    CoreMove coremoveScript;

    PlayerStatus pStatus;

    private bool talkActionOnce = false;
    private bool talkActionHold = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu = GameObject.Find("UI/Pause");
        pauseMovingScript = PauseMenu.GetComponent<PauseMenuMovingScript>();

        //pause���j���[���̑���Ɋւ���擾�͂�����ւ�ɏ���

        Actor = GameObject.Find("Actor1");
        playerConScript = Actor.GetComponent<PlayerCon>();
        pStatus = Actor.GetComponent<PlayerStatus>();

        ActorCore = GameObject.Find("Actor1/ActorCore");
        coremoveScript = ActorCore.GetComponent<CoreMove>();
    }

    public void NomalMove()
    {
        if (Time.timeScale != 0)
        {
            playerConScript.ActorCon();         //�ړ�
            coremoveScript.SetRotate();
        }
        //modeGearScript.RevolverMove();      //�t�H�����[���[�h�ύX
        pauseMovingScript.PauseMenuInOut(); //�|�[�Y���j���[�J������
    }

    public void Talk()
    {
        if (0.01f <= playerConScript.Action() && playerConScript.Action() < 0.6f && !talkActionOnce)
        {//�A�N�V�����{�^���������ꂽ�Ƃ�
            talkActionOnce = true;
        }
        if (2f <= playerConScript.Action() && !talkActionHold)
        {
            talkActionHold = true;
        }if (playerConScript.Action() == 0 && (talkActionOnce || talkActionHold)){
            talkActionOnce = false;
            talkActionHold = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pStatus.GetSetPlayerMode == "normal")
        {
            NomalMove();
            if (pStatus.GetSetActionAble)//�A�N�V���i�u���ȃI�u�W�F�N�g��⑫
            {
                if (0.01f < playerConScript.Action() && playerConScript.Action() < 0.6f) {//�A�N�V�����{�^���������ꂽ�Ƃ�
                    playerConScript.StartTalk();
                }
            }
        }
        else if (pStatus.GetSetPlayerMode == "talk")
        {
            Talk();
        }



    }
}
