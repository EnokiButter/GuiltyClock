using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    //エネミーの状態やフラグを管理。全部ここに入れろ。
    //勝手に他のスクリプト同士でフラグのやり取りをするな。ここを一回介せ。
    [SerializeField] private int HitPoint = 5;//HP
    [SerializeField] private int atk = 3;//攻撃力
    [SerializeField] private bool isDiscoverV;//視覚ハッケンフラグ
    [SerializeField] private bool isAttentionV;//視覚警戒フラグ
    [SerializeField] private bool isDiscoverH;//音発見フラグ
    [SerializeField] private bool isAttentionH;//音警戒フラグ
    [SerializeField] private bool isHostile;//敵対フラグ

    public bool GetSetisHostile{//敵対フラグのGetSet。これは簡単に変更できていいのでGetSetで書いた
        get { return isHostile; }
        set { isHostile = value; }
    }

    public void SetisDiscoverV(bool onoff)//視覚発見フラグのSet。気軽に変更されても困るのでGetSetは分割
    {
        isDiscoverV = onoff;
    }
    public bool GetisDiscoverV()//視覚発見フラグのGet。
    {
        return isDiscoverV;
    }

    public void SetisAttentionV(bool onoff)
    {
        isAttentionV = onoff;
    }
    public bool GetisAttentionV()//視覚警戒フラグのGet。
    {
        return isAttentionV;
    }

    public void SetisDiscoverH(bool onoff)
    {
        isDiscoverH = onoff;
    }
    public bool GetisDiscoverH()//聴覚発見フラグのGet。
    {
        return isDiscoverH;
    }

    public void SetisAttentionH(bool onoff)
    {
        isAttentionH = onoff;
    }
    public bool GetisAttentionH()//聴覚警戒フラグのGet。
    {
        return isAttentionH;
    }

    public int GetAtk(){
        return atk;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        
    }
}
