using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private bool isDamaged = false;
    private Vector3 KnockBackVec;

    [SerializeField] private int HitPoint = 5;
    [SerializeField] float knokcBackhigh = 2f;
    [SerializeField] float knokcBackLevel = 3f;
    [SerializeField] float flashInterval;
    [SerializeField] int loopCount;

    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    //hp�̌v�Z�p
    public int HPgetset {
        get { return HitPoint; }
        set { HitPoint = value; }
    }

    public bool getIsDamaged (){
        return this.isDamaged;
    }

    //
    void OnCollisionEnter(Collision other)
    {
        // "enemy"�^�O�̃I�u�W�F�N�g�ƐڐG��
        if (((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "EnemyAttack") || (other.gameObject.tag == "Trap"))
            &&
            (!isDamaged))
        {
            KnockBackVec = this.transform.position - other.transform.position;
            KnockBackVec.y += knokcBackhigh;
            Damage(2,KnockBackVec);
        }
    }

    void Damage(int dmg, Vector3 KBV) {
        var rigidbody = GetComponent<Rigidbody>();
        int tmpPoint = HitPoint;
        tmpPoint = tmpPoint - dmg;
        HitPoint = tmpPoint;
        isDamaged = true;
        rigidbody.AddForce(KBV * knokcBackLevel, ForceMode.VelocityChange);
        StartCoroutine(DamageFlash());
    }

    IEnumerator DamageFlash()
    {
        for (int i = 0; i < loopCount; i++) {
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I�t
            sp.enabled = false;

            //flashInterval�҂��Ă���
            yield return new WaitForSeconds(flashInterval);
            //spriteRenderer���I��
            sp.enabled = true;
        }
        isDamaged = false;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(HitPoint);
    }
}
