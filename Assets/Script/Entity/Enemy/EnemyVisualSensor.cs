using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisualSensor : MonoBehaviour
{

    GameObject EnemyBody;
    EnemyStatus enemyStatus;

    private bool isDiscoverV;
    private bool isAttentionV;

    private float discoverMeter;
    [SerializeField] private float enemyAngle = 45.0f;

    [SerializeField, Range(0, 2.0f)] private float atnpoint;
    [SerializeField, Range(0, 2.0f)] private float dsvpoint;
    // Start is called before the first frame update
    void Start()
    {
        EnemyBody = transform.parent.gameObject.transform.Find("Sprite").gameObject;
        enemyStatus = EnemyBody.GetComponent<EnemyStatus>();
        discoverMeter = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")//範囲にプレイヤーが入った
        {
            Vector3 posDelta = other.transform.position - transform.position;
            float targetAngle = Vector3.Angle(transform.forward, posDelta);

            if (targetAngle < enemyAngle)//視野角の範囲内
            {
                if (Physics.Raycast(transform.position, new Vector3(posDelta.x, 0f, posDelta.z), out RaycastHit hit))//視界にコライダーがある
                {
                    if (hit.collider == other)//レイを飛ばして接触するのがプレイヤー
                    {
                        float distance = posDelta.magnitude;
                        //Debug.Log("視界の範囲内＆視界の角度内＆障害物なし");
                        if(discoverMeter < 2f)
                        {
                            discoverMeter += Time.deltaTime / (distance / 10);
                        }
                    }
                }
            }
        }
    }

    public bool GetisDiscoverV()
    {
        return isDiscoverV;
    }

    public bool GetisAttentionV()
    {
        return isAttentionV;
    }

    public void DiscoverMeter()
    {
        if (0 <= discoverMeter - (Time.deltaTime * 4f / 5f))
        {
            discoverMeter -= Time.deltaTime * 4f / 5f;
        }

        if (atnpoint < discoverMeter)
        {
            isAttentionV = true;
        }
        else
        {
            isAttentionV = false;
        }

        if (dsvpoint < discoverMeter)
        {
            isDiscoverV = true;
        }else if (discoverMeter < atnpoint)
        {
            isDiscoverV = false;
        }
    }

    public void VisualSensor()
    {
        DiscoverMeter();
        enemyStatus.SetisDiscoverV(isDiscoverV);
        enemyStatus.SetisAttentionV(isAttentionV);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
