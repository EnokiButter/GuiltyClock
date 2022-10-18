//Guardman
//�����̌x�������Ă���x��������ł��B
//Guardman�͌��܂����o�H�Œ�@���Ă��܂��B
//���Ǝ��E�Ńv���C���[��T���܂��B
//�˗��傩�炽���������������Ă��Ȃ��̂ŏ����s�^�ʖڂł��B
//Guardman�͎��E�ɓ������v���C���[��ǂ������܂��B
//�������A�Օ����Ȃǂł��΂炭���E����v���C���[��������ƒǂ�������̂���߂ď��H�ɖ߂�܂��B
//�v���C���[�̉��������������A���̕����ɒ��ڂ��܂��B

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManManager : EnemyManager
{
    GuardManReaction reaction;
    // Start is called before the first frame update
    protected override void OnEnable()
    {
        base.OnEnable();
        reaction = GetComponent<GuardManReaction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameConScript.GetSetIsTalking){//��b���ɂ͓����Ȃ�

            base.VSensor();
            base.HSensor();
            if (eyeSensor.GetisDiscoverV())//�v���C���[����������
            {
                reaction.VDiscoverReaction();//�v���C���[��ǂ�������
            }
            else if (earSensor.GetisDiscoverH())//�v���C���[�̉��ɋC�Â�����
            {
                reaction.HDiscoverReaction();//�v���C���[�̉��̂����������
            }
            else
            {
                base.NomalMove();
            }
        }
    }
}
