using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int HitPoint = 5;
    private Vector3 KnockBackVec;
    [SerializeField] private int atk = 3;
    
    public int AtkGet(){
        return atk;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
/*
    void OnCollisionEnter(Collision other)
    {
        var rigidbody = GetComponent<Rigidbody>();
        // "enemy"タグのオブジェクトと接触時
        if ((other.gameObject.tag == "Player"))
        {
            int tmpPoint = HitPoint;
            tmpPoint = tmpPoint - 2;
            HitPoint = tmpPoint;
            Debug.Log(HitPoint);
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        
    }
}
