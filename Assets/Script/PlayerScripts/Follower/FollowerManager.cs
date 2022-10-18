using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerManager : SingletonMonoBehaviour<FollowerManager>
{
    FollowerFollow followScript;
    FollowerCon fCon;
    WindAnim wAnim;
    GameObject WindUI;

    // Start is called before the first frame update
    void Start()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);//�����ĂȂ��Ȃ�Ȃ��悤��
        followScript = GetComponent<FollowerFollow>();
        fCon = GetComponent<FollowerCon>();
        WindUI = GameObject.Find("UI/Winding");
        wAnim = WindUI.GetComponent<WindAnim>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {

            //Debug.Log(fCon.GetWind());
            followScript.FollowPlayer(true);

            if (fCon.GetActionMode() == 3)
            {
                if (Input.GetKeyDown("j"))//�������u��
                {
                    fCon.FollowerAction(fCon.GetActionMode());
                }
            }
            else
            {
                if (Input.GetKey("j"))//������Ă����
                {
                    fCon.FollowerAction(fCon.GetActionMode());
                }
            }
            if (Input.GetKeyDown("p") && !Input.GetKey("j"))
            {

                if (Array.IndexOf(wAnim.GetDirNames(), "ReWind") == -1)
                {
                    Debug.LogError("dir�ɂ�Winding, ReWind, Decrease�̂����ꂩ���w�肵�ĉ�����");
                    return;
                }

                if (!wAnim.GetWait())
                {
                    fCon.WindingPlus(fCon.GetWindLevel());
                    wAnim.Winding("ReWind", 5, true);
                }
            }
            else
            {
                fCon.WindingDecrease();
                if (fCon.GetWind() != 0)
                {
                    wAnim.Winding("Winding",1,true);
                }
                else
                {
                    wAnim.Winding("Winding", 0, false);
                }
            }
        }
    }
}
