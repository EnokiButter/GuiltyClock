using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConScript : MonoBehaviour
{
    public bool isPause;
    [SerializeField, Disable] public bool isTalking;

    void Start()
    {
        isPause = false;
        isTalking = false;
    }

    public bool GetSetIsTalking
    {
        get { return isTalking; }
        set { isTalking = value; }
    }

    public bool GetSetIsPause
    {
        get { return isPause; }
        set { isPause = value; }
    }

    public void ConTime(float timesc) //分ける必要あったかは不明。わかりやすいからいいか。
    {
        Time.timeScale = timesc;
        //Debug.Log(isPause);
    }

    public void TimeStop(bool stop) //いろんなとこで使うからシンプルに。
    {
        if (stop)
        {
            ConTime(0);
        }
        else
        {
            ConTime(1);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
