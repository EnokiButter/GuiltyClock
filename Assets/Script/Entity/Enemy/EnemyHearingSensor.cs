using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearingSensor : MonoBehaviour
{

    GameObject Player;
    PlayerStatus playerStatus;
    GameObject EnemyBody;
    EnemyStatus enemyStatus;


    private bool isDiscoverH;
    private bool isAttentionH;

    [SerializeField] private float hearinglevel;
    [SerializeField, Range(0,2.0f)] private float atnpoint;
    [SerializeField, Range(0, 2.0f)] private float dsvpoint;
    private float discoverMeter;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBody = transform.parent.gameObject.transform.Find("Sprite").gameObject;
        enemyStatus = EnemyBody.GetComponent<EnemyStatus>();
        Player = GameObject.Find("Actor1");
        playerStatus = Player.GetComponent<PlayerStatus>();
        discoverMeter = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && !playerStatus.GetIsSneek() && playerStatus.GetIsMove())//範囲にプレイヤーが入った&&Sneakじゃない
        {
            float distance = (other.transform.position - transform.position).magnitude;//プレイヤーとの距離を取得
            if (distance <= 6f * hearinglevel * 0.01f)
            {
                if (discoverMeter < 2.5f)
                {
                    discoverMeter += Time.deltaTime;
                }
            }
        }
    }

    public bool GetisDiscoverH()
    {
        return isDiscoverH;
    }

    public bool GetisAttentionH()
    {
        return isAttentionH;
    }

    public void DiscoverMeter()
    {
        if (0 < discoverMeter)
        {
            discoverMeter -= Time.deltaTime ;
        }

        if (atnpoint < discoverMeter)
        {
            isAttentionH = true;
        }
        else
        {
            isAttentionH = false;
        }

        if (dsvpoint < discoverMeter)
        {
            isDiscoverH = true;
        }
        else if (discoverMeter < atnpoint)
        {
            isDiscoverH = false;
        }

    }

    public void ErrorCatch()
    {
        if(dsvpoint < atnpoint)
        {
            Debug.LogError("atnpoint < dsvpoint になるように設定してください");
        }
        if(dsvpoint == 0)
        {
            Debug.LogError("dsvpoint は0よりも大きい値で設定してください");
        }
        if(atnpoint == 0)
        {
            Debug.LogError("atnpoint は0よりも大きい値で設定してください");
        }

    }

    public void HearingSensor()    {
        DiscoverMeter();
        enemyStatus.SetisDiscoverH(isDiscoverH);
        enemyStatus.SetisAttentionH(isAttentionH);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
