using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    //UIの管理クラス。プレイヤー側で自由に動かせないものたち。

    GameObject HPBar;
    GameObject HPDamageBar;
    GameObject HPText;

    StatusBar hpBarScript;
    StatusBar damageBarScript;
    HPTextScript hpTextManager;


    // Start is called before the first frame update
    void Start()
    {
        HPBar = GameObject.Find("UI/HP/HPBaseMask/HPBar");
        hpBarScript = HPBar.GetComponent<StatusBar>();

        HPDamageBar = GameObject.Find("UI/HP/HPBaseMask/DamageBar");
        damageBarScript = HPDamageBar.GetComponent<StatusBar>();


        HPText = GameObject.Find("UI/HP/HPText");
        hpTextManager = HPText.GetComponent<HPTextScript>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBarScript.StatusBarAnim();
        damageBarScript.StatusBarAnim();

        hpTextManager.HPVibration();
        hpTextManager.HPCount();
        hpTextManager.LowHPAnim();
    }
}
