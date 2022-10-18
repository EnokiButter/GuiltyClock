using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : SingletonMonoBehaviour<PlayerStatus>
{
    //プレイヤーの状態やフラグを管理。全部ここに入れろ。
    //勝手に他のスクリプト同士でフラグのやり取りをするな。ここを一回介せ。
    //インスタンス生成しまくったり継承したりしないので神状態でいい。
    private bool isDamaging = false;//ダメージフラッシュ無敵状態
    private bool isHealth = false;//回復状態
    private bool isSneek = false;//Sneak状態
    private bool isMove;//音の出る動き
    private bool isStiffens = false;//硬直状態

    private bool actionAble;//アクション範囲にアクション可能なオブジェクト発見
    public bool GetSetActionAble
    {
        get { return actionAble; }
        set { actionAble = value; }
    }

    BeAction beAction;

    private Vector3 KnockBackVec;
    private int damage;
    public enum PlayerMode//プレイヤーの状態
    {
        normal,
        talk
    }
    private PlayerMode playerMode;//プレイヤーの状態を保存しておくところ

    [SerializeField] private int HitPointMax = 20;
    [SerializeField] private int HitPoint;
    [SerializeField] private float knokcBackhigh = 1f;
    [SerializeField] private float knokcBackLevel = 3f;
    [SerializeField] private float flashInterval;
    [SerializeField] private int loopCount;

    SpriteRenderer sp;


    // Start is called before the first frame update
    void Awake()
    {
        if (this != Instance)//もし存在したら
        {
            Destroy(gameObject);//オリジナルは一人でいい
            return;//終わる
        }

        DontDestroyOnLoad(gameObject);//消えてなくならないように

        sp = GetComponent<SpriteRenderer>();//スプライト描画のためにレンダラー取得

        playerMode = PlayerMode.normal;//プレイヤーの状態を設定(移動)
        InitHitPoint();//HP初期化。いずれ消すかも。
    }



    //スニーク状態のゲッターセッター
    public void SetIsSneek(bool onoff)
    {
        isSneek = onoff;
    }
    public bool GetIsSneek()
    {
        return isSneek;
    }

    public void SetIsMove(bool onoff)//動いている状態のセッター
    {
        isMove = onoff;
    }
    public bool GetIsMove()//動いている状態のゲッター
    {
        return isMove;
    }

    //ダメージ状態のゲッター
    public bool GetIsDamaging(){
        return this.isDamaging;
    }
    //硬直状態のゲッター
    public bool GetStiffens(){
        return isStiffens;
    }

    public string GetSetPlayerMode
    {
        get { return playerMode.ToString(); }
        set
        {
            if (value == "normal") playerMode = PlayerMode.normal;
            else if (value == "talk") playerMode = PlayerMode.talk;
            else Debug.LogError("pStateに不正な値が入っています。");
        }
    }
    //hpのゲットセット
    public int GetsetHP {
        get { return HitPoint; }
        set { HitPoint = value; }
    }
    //hpmaxのゲットセット
    public int GetsetHPMAX{
        get { return HitPointMax; }
        set { HitPointMax = value; }
    }
    //最大HPアップ用
    public void SetMaxHP(int hpmax) {
        HitPointMax += hpmax;
    }
    //HP初期化
    public void InitHitPoint() {
        //HitPointが１００％の状態にする
        HitPoint = HitPointMax;
    }
    public int GetDamage() {//受けたダメージのゲッター。HPバー用
        return damage;
    }
    public void SetDamage(int dmg)
    {
        damage = dmg;
    }


    //ノックバック
    public void KnockBack(Collision other) {
        var rigidbody = GetComponent<Rigidbody>();
        //ノックバックのベクトルを取得(トレちゃんと敵の座標の差)
        KnockBackVec = this.transform.position - other.transform.position;
        KnockBackVec.y += knokcBackhigh;
        //ノックバック実行
        rigidbody.AddForce(KnockBackVec * knokcBackLevel, ForceMode.VelocityChange);
    }

    //ダメージ計算用
    public void Damage(int dmg) {
        int tmpPoint = HitPoint;
        tmpPoint = tmpPoint - dmg;
        HitPoint = tmpPoint;
        if (HitPoint <= 0) {
            HitPoint = 0;
        }
        isDamaging = true;
        isStiffens = true;
        StartCoroutine(DamageFlash());
    }

    //ダメージフラッシュ
    public IEnumerator DamageFlash()
    {
        for (int i = 0; i < loopCount; i++) {
            yield return new WaitForSeconds(flashInterval);
            //spriteRendererをオフ
            sp.enabled = false;

            //flashInterval待ってから
            yield return new WaitForSeconds(flashInterval);
            //spriteRendererをオン
            sp.enabled = true;
        }
        isStiffens = false;
        for (int i = 0; i < loopCount; i++)
        {
            yield return new WaitForSeconds(flashInterval);
            //spriteRendererをオフ
            sp.enabled = false;

            //flashInterval待ってから
            yield return new WaitForSeconds(flashInterval);
            //spriteRendererをオン
            sp.enabled = true;
        }
        isDamaging = false;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
