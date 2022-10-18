using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject Eye;
    GameObject Ear;

    private bool isDiscover;

    protected EnemyVisualSensor eyeSensor;
    protected EnemyHearingSensor earSensor;
    protected EnemyMove enemyMove;

    protected GameObject GameCon;
    protected GameConScript gameConScript;

    // Start is called before the first frame update
    protected virtual void OnEnable()
    {
        Eye = transform.Find("Eye").gameObject;
        eyeSensor = Eye.GetComponent<EnemyVisualSensor>();
        Ear = transform.Find("Ear").gameObject;
        earSensor = Ear.GetComponent<EnemyHearingSensor>();

        GameCon = GameObject.Find("GameCon");
        gameConScript = GameCon.GetComponent<GameConScript>();


        enemyMove = this.GetComponent<EnemyMove>();
    }


    public void VSensor()
    {
        eyeSensor.VisualSensor();
    }
    public void HSensor()
    {
        earSensor.HearingSensor();
    }
    public void NomalMove()
    {
        enemyMove.EntityMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameConScript.GetSetIsTalking)//‰ï˜b’†‚É‚Í“®‚©‚È‚¢
        {
            VSensor();
            HSensor();
            NomalMove();
        }
    }
}
