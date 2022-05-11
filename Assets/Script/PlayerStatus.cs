using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private bool isDamaging = false;
    private Vector3 KnockBackVec;

    private string HitPointToString;

    [SerializeField] private int HitPointMax = 20;
    [SerializeField] private int HitPoint;
    [SerializeField] float knokcBackhigh = 1f;
    [SerializeField] float knokcBackLevel = 3f;
    [SerializeField] float flashInterval;
    [SerializeField] int loopCount;

    //HPのやつ
    GameObject HPText;
    HPTextScript hpTextScript;

    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        //スプライト描画のためにレンダラー取得
        sp = GetComponent<SpriteRenderer>();

        //----------------HPに関する初期設定--------------------
        //HP初期化
        InitHitPoint();
        //HPテキストのスクリプト取得 #1 テキストUI発見
        HPText = GameObject.Find ("UI/HP/HPText");
        //HPテキストのスクリプト取得 #2 スクリプト取得
        hpTextScript = HPText.GetComponent<HPTextScript>();
        //HP描画
        HPDraw();
    }


    //ダメージ状態のゲッター
    public bool getIsDamaging(){
        return this.isDamaging;
    }
    //HPの描画用
    public void HPDraw() {
        //HPをHPTextさんに描画させる
        hpTextScript.HPCount(HitPoint,HitPointMax);
    }
    //hpの計算用
    public int HPgetset {
        get { return HitPoint; }
        set { HitPoint = value; }
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

    //接触判定
    void OnCollisionEnter(Collision other)
    {
        // 敵、罠、攻撃タグのオブジェクトと接触時　&&　ダメージフラッシュしていない　&&　死んでないとき
        if (((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "EnemyAttack") || (other.gameObject.tag == "Trap"))
            &&
            (!isDamaging)
            &&
            (HitPoint != 0)
            )
        {
            //ノックバック実行
            KnockBack(other);
            //敵のダメージを取得
            int dmg = other.gameObject.GetComponent<EnemyStatus>().AtkGet();
            //ダメージ実行
            Damage(dmg);
            HPDraw();
        }
    }

    //ノックバック
    void KnockBack(Collision other) {
        var rigidbody = GetComponent<Rigidbody>();
        //ノックバックのベクトルを取得(トレちゃんと敵の座標の差)
        KnockBackVec = this.transform.position - other.transform.position;
        KnockBackVec.y += knokcBackhigh;
        //ノックバック実行
        rigidbody.AddForce(KnockBackVec * knokcBackLevel, ForceMode.VelocityChange);
    }

    //ダメージ計算用
    void Damage(int dmg) {
        int tmpPoint = HitPoint;
        tmpPoint = tmpPoint - dmg;
        HitPoint = tmpPoint;
        if (HitPoint <= 0) {
            HitPoint = 0;
        }
        isDamaging = true;
        StartCoroutine(DamageFlash());
    }

    //ダメージフラッシュ
    IEnumerator DamageFlash()
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
        isDamaging = false;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(HitPoint);
    }
}
