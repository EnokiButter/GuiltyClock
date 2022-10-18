using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTalk : MonoBehaviour
{
    private bool isTalk = false;//�g�[�N���
    public TextAsset[] TalkDeck;    //�@���񂷂�ʒu
    public bool GetSetisTalk//�̃p�u���b�N�v���p�e�B
    {
        get { return isTalk; }
        set { isTalk = value; }
    }

    GameObject Player;
    PlayerStatus pStatus;

    // Start is called before the first frame update
    void OnEnable()
    {
        isTalk = false;
        Player = GameObject.Find("Actor1");
        pStatus = Player.GetComponent<PlayerStatus>();
    }

    public void TalkStart()
    {
        GetSetisTalk = true;
    }
    public void TalkEnd()
    {
        pStatus.GetSetPlayerMode = "normal";
    }
    public void TalkSend()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
