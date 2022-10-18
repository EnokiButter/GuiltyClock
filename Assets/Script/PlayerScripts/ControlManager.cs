using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    //プレイヤーで自由に動かせるものの管理をする
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

        //pauseメニュー内の操作に関する取得はここらへんに書く

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
            playerConScript.ActorCon();         //移動
            coremoveScript.SetRotate();
        }
        //modeGearScript.RevolverMove();      //フォロワーモード変更
        pauseMovingScript.PauseMenuInOut(); //ポーズメニュー開く閉じる
    }

    public void Talk()
    {
        if (0.01f <= playerConScript.Action() && playerConScript.Action() < 0.6f && !talkActionOnce)
        {//アクションボタンが押されたとき
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
            if (pStatus.GetSetActionAble)//アクショナブルなオブジェクトを補足
            {
                if (0.01f < playerConScript.Action() && playerConScript.Action() < 0.6f) {//アクションボタンが押されたとき
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
