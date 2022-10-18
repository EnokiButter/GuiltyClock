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
        // �G�A㩁A�U���^�O�̃I�u�W�F�N�g�ƐڐG���@&&�@�_���[�W�t���b�V�����Ă��Ȃ��@&&�@����łȂ��Ƃ�
        if (((other.gameObject.tag == "EnemyAttack") || (other.gameObject.tag == "Trap") || (other.gameObject.tag == "Enemy"))
            &&
            (!playerStatus.GetIsDamaging())
            &&
            (playerStatus.GetsetHP != 0)
            )
        {
            //�m�b�N�o�b�N���s
            playerStatus.KnockBack(other);
            //�G�̃_���[�W���擾
            playerStatus.SetDamage(other.gameObject.GetComponent<EnemyStatus>().GetAtk());
            //�_���[�W���s
            playerStatus.Damage(playerStatus.GetDamage());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        beAction = other.gameObject.GetComponent<BeAction>();
        if (beAction != null)//�A�N�V�����\�I�u�W�F�N�g�F��
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
