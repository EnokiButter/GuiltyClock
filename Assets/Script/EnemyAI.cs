using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public Transform central;
    private NavMeshAgent agent;

    [SerializeField] 
    float radius = 1;
    float waitTime = 2;
    float time = 0;


    bool discover=false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        this.agent.speed = 2.5f;
        this.agent.angularSpeed = 60f;
        this.agent.acceleration = 4f;
        GotoNextPoint();
    }

 void GotoNextPoint()
    {
        //NavMeshAgentのストップを解除
        agent.isStopped = false;

        //目標地点のX軸、Z軸をランダムで決める
        float posX = Random.Range(-1 * radius, radius);
        float posZ = Random.Range(-1 * radius, radius);

        //CentralPointの位置にPosXとPosZを足す
        Vector3 pos = central.position;
        pos.x += posX;
        pos.z += posZ;
        
        //NavMeshAgentに目標地点を設定する
        agent.destination = pos;
    }

    void StopHere()
    {
        //NavMeshAgentを止める
        agent.isStopped = true;
        //待ち時間を数える
        time += Time.deltaTime;

        //待ち時間が設定された数値を超えると発動
        if(time > waitTime)
        {
            //目標地点を設定し直す
            GotoNextPoint();
            time = 0;
        }
    }

    void Update()
    {
        //経路探索の準備ができておらず
        //目標地点までの距離が1m未満ならNavMeshAgentを止める
        if (!agent.pathPending && agent.remainingDistance < 1f)
            StopHere();
    }
}
