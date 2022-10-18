using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EntityAI : MonoBehaviour
{
    [SerializeField] private float speed;   //移動速度
    [SerializeField] private float speedtmp;   //移動速度

    [SerializeField] private float waitTime;//動きごとの待機時間

    private Vector3 destination; //　目的地

    //到着地点の座標の各要素(yは基本使わないけど一応)
    [SerializeField] private float stopx;
    [SerializeField] private float stopy=0;
    [SerializeField] private float stopz;
    private float stopwatch;

    float rad;//角度取得のための変数
    float degree;//角度取得のための変数
    Vector3 dt;//角度取得のための変数

    private bool isEntitymoving;

    [SerializeField] private bool isSearch;

    private bool waiting; //移動できる状態か否か
    

    [SerializeField] private Transform[] patrolPositions;    //　巡回する位置
    private int nowPatrolPosition = 0;//　次に巡回する位置

    protected virtual void OnEnable()
    {
        isEntitymoving = false;
        //インスタンス生成時に毎回リセットしてほしいのでここで設定
        waiting = true;
        var patrolParent = this.transform.Find("PatrolPositions").gameObject; //　巡回地点を設定
        patrolPositions = new Transform[patrolParent.transform.childCount];
        for (int i = 0; i < patrolParent.transform.childCount; i++)
        {
            patrolPositions[i] = patrolParent.transform.GetChild(i);
        }
    }

    public void SetNextPosition() //　巡回地点を順に周る
    {
        nowPatrolPosition++;
        if (nowPatrolPosition >= patrolPositions.Length)
        {
            nowPatrolPosition = 0;
        }
        SetDestination(patrolPositions[nowPatrolPosition].position);
        GetAngle(this.transform.position, destination);
    }
   
    public void SetDestination(Vector3 position) //　目的地を設定する
    {
        destination = position;
    }

    public Vector3 GetDestination() //　目的地を取得する
    {
        return destination;
    }

    public float GetAngle(Vector3 start, Vector3 target)//角度を取得
    {
        dt = target - start;
        rad = Mathf.Atan2(dt.x, dt.z);
        degree = rad * Mathf.Rad2Deg;
        return degree;
    }

    public float GetABSVal(float val)//絶対値取るやつ
    {
        if (val >= 0)
            return val;
        else
            return -val;
    }


    public void EntityMove()
    {//エンティティの動作

        if (waiting)
        {
            waiting = false;
            stopwatch = 0;
            SetNextPosition();
        }
        else
        {
            isEntitymoving = true;
            if ((GetABSVal(destination.x - this.transform.position.x) >= stopx) ||
                (GetABSVal(destination.z - this.transform.position.z) >= stopz))
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, GetAngle(this.transform.position, destination), 0));
                this.transform.position += transform.forward * Time.deltaTime * speed;
            }
            else
            {
                isEntitymoving = false;
                OnOffTimer(waitTime, true);
            }
        }

    }
    public void OnOffTimer(float waittimer, bool onoff)
    {
        stopwatch += Time.deltaTime;
        if (waittimer <= stopwatch)
        {
            waiting = onoff;
        }
    }
    public void InitDestination() { //一番近い目的地に向かわせる
        
    }


    private void Update()
    {

    }

}
//参考サイト：https://gametukurikata.com/navigation/movetodestination
//サイトではNavMeshの機能で動かしているが、融通が利かないので自作する。
