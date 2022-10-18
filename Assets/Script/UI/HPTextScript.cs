using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTextScript : MonoBehaviour
{
    GameObject player;
    PlayerStatus playerstatus;

    Text text = null;
    RectTransform rt;

    private int hp;
    private int hpmax;
    private bool isdamaging;

    private float textcolor;

    //条件を満たしたとき一回だけ動いてもらうためのやつ
    private bool vibpulse = false;
    private bool colpulse = false;

    void Start()
    {

        text = this.GetComponent<Text>();
        rt = GetComponent<RectTransform>();

        //プレイヤーのスクリプト取得 #1 オブジェクト発見
        player = GameObject.Find("Actor1");
        //プレイヤーのスクリプト取得 #2 スクリプト取得
        playerstatus = player.GetComponent<PlayerStatus>();

        hp = playerstatus.GetsetHP;
        hpmax = playerstatus.GetsetHPMAX;
        HPCount();
    }


    public void HPCount() {
        string hpstr = hp.ToString() + "/" + hpmax.ToString();
        gameObject.GetComponent<UnityEngine.UI.Text>().text = hpstr;
    }


    IEnumerator VibrationCor()
    {

        float vib = 5f;
        float vibtmp = vib / 2f;
        transform.localPosition += new Vector3(0, vib /2, 0);
        yield return new WaitForSecondsRealtime(0.05f);

        while (0 < vib)
        {
            transform.localPosition -= new Vector3(0,vib,  0);
            yield return new WaitForSecondsRealtime(0.05f);
            Debug.Log(transform.localPosition.x);
            transform.localPosition += new Vector3( 0,vib, 0);
            yield return new WaitForSecondsRealtime(0.05f);
            Debug.Log(transform.localPosition.x);
            vib --;
        }
        transform.localPosition -= new Vector3(0, vibtmp, 0);
        yield return new WaitForSecondsRealtime(0.05f);
    }

    public void HPVibration() {
        hp = playerstatus.GetsetHP;
        hpmax = playerstatus.GetsetHPMAX;
        isdamaging = playerstatus.GetIsDamaging();

        if (isdamaging && !vibpulse)
        {
            vibpulse = true;
            StartCoroutine("VibrationCor");
            StartCoroutine("TextDamageColorChangerCor");
        }
        if (!isdamaging)
        {
            vibpulse = false;
        }
    }


    IEnumerator TextDamageColorChangerCor()
    {
        for (int i = 3; i <= 10; i ++)
        {
            text.color = new Color(1f, (float)i / 10f,(float)i / 10f, 1f);
            yield return new WaitForSecondsRealtime(0.1f);
        }
        colpulse = false;
    }

    IEnumerator TextLowHPExpandCor()
    {
        for (int i = 1; i < 4; i++)
        {
            rt.localScale += new Vector3(0.1f,0.1f,0);
            yield return new WaitForSecondsRealtime(0.05f);
        }
        for (int i = 1; i < 4; i++)
        {
            rt.localScale -= new Vector3(0.1f,0.1f,0);
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

    public void LowHPAnim(){
        if (hp <= hpmax/5 && !colpulse) {
            colpulse = true;
            StartCoroutine("TextDamageColorChangerCor");
            StartCoroutine("TextLowHPExpandCor");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
