using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    private MobMove mobMove;
    private MobTalk mobTalk;
    private GameObject Player;
    private PlayerStatus pStatus;

    private bool talkSendOnce;

    private GameObject TextWindow;
    private TextWindowScript textWindowScript;

    private GameObject GameCon;
    private GameConScript gameConScript;

    // Start is called before the first frame update
    void Start()
    {
        talkSendOnce = false;
        Player = GameObject.Find("Actor1");
        pStatus = Player.GetComponent<PlayerStatus>();
        
        TextWindow = GameObject.Find("UI/TextWindow");
        textWindowScript = TextWindow.GetComponent<TextWindowScript>();

        GameCon = GameObject.Find("GameCon");
        gameConScript = GameCon.GetComponent<GameConScript>();

        mobMove = GetComponent<MobMove>();
        mobTalk = GetComponent<MobTalk>();
    }
    public void NomalMove()
    {
        mobMove.EntityMove();
    }
    public void TalkAction()
    {
        if (!talkSendOnce && (pStatus.GetSetActionAble))
        {
            mobTalk.TalkSend();
            talkSendOnce = true;
            textWindowScript.ActivateTalkWindow(true);
            gameConScript.GetSetIsTalking = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!mobTalk.GetSetisTalk)
        {
            NomalMove();
            if(pStatus.GetSetPlayerMode == "talk")
            {
                mobTalk.TalkStart();
            }
        }
        else if (mobTalk.GetSetisTalk)
        {
            TalkAction();
        }
    }
}
