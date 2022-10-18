//Guardman
//建物の警備をしている警備員さんです。
//Guardmanは決まった経路で偵察しています。
//音と視界でプレイヤーを探します。
//依頼主からたいした給料を貰っていないので少し不真面目です。
//Guardmanは視界に入ったプレイヤーを追いかけます。
//しかし、遮蔽物などでしばらく視界からプレイヤーが消えると追いかけるのをやめて順路に戻ります。
//プレイヤーの音が聞こえた時、その方向に注目します。

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
        if (!gameConScript.GetSetIsTalking){//会話中には動かない

            base.VSensor();
            base.HSensor();
            if (eyeSensor.GetisDiscoverV())//プレイヤーを見つけた時
            {
                reaction.VDiscoverReaction();//プレイヤーを追いかける
            }
            else if (earSensor.GetisDiscoverH())//プレイヤーの音に気づいた時
            {
                reaction.HDiscoverReaction();//プレイヤーの音のする方を向く
            }
            else
            {
                base.NomalMove();
            }
        }
    }
}
