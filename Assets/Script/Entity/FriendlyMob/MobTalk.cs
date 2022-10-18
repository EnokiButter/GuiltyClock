using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobTalk : MonoBehaviour
{
    private bool isTalk = false;//トーク状態
    public TextAsset[] TalkDeck;    //　巡回する位置
    public bool GetSetisTalk//のパブリックプロパティ
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
