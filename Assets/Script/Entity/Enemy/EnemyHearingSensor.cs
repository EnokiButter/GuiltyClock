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
        if (other.tag == "Player" && !playerStatus.GetIsSneek() && playerStatus.GetIsMove())//�͈͂Ƀv���C���[��������&&Sneak����Ȃ�
        {
            float distance = (other.transform.position - transform.position).magnitude;//�v���C���[�Ƃ̋������擾
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
            Debug.LogError("atnpoint < dsvpoint �ɂȂ�悤�ɐݒ肵�Ă�������");
        }
        if(dsvpoint == 0)
        {
            Debug.LogError("dsvpoint ��0�����傫���l�Őݒ肵�Ă�������");
        }
        if(atnpoint == 0)
        {
            Debug.LogError("atnpoint ��0�����傫���l�Őݒ肵�Ă�������");
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
