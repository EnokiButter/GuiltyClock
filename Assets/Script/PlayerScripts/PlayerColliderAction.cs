using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderAction : MonoBehaviour
{
    BeAction beAction;
    PlayerStatus playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }
    private void OnCollisionEnter(Collision other)
    {
        // 敵、罠、攻撃タグのオブジェクトと接触時　&&　ダメージフラッシュしていない　&&　死んでないとき
        if (((other.gameObject.tag == "EnemyAttack") || (other.gameObject.tag == "Trap") || (other.gameObject.tag == "Enemy"))
            &&
            (!playerStatus.GetIsDamaging())
            &&
            (playerStatus.GetsetHP != 0)
            )
        {
            //ノックバック実行
            playerStatus.KnockBack(other);
            //敵のダメージを取得
            playerStatus.SetDamage(other.gameObject.GetComponent<EnemyStatus>().GetAtk());
            //ダメージ実行
            playerStatus.Damage(playerStatus.GetDamage());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        beAction = other.gameObject.GetComponent<BeAction>();
        if (beAction != null)//アクション可能オブジェクト認識
        {
            playerStatus.GetSetActionAble = true;
            beAction.GetSetActionAble = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        beAction = other.gameObject.GetComponent<BeAction>();
        if (beAction != null)
        {
            playerStatus.GetSetActionAble = false;
            beAction.GetSetActionAble = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
