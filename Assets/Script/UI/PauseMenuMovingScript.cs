using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuMovingScript : MonoBehaviour
{

    GameObject GameCon;
    GameConScript gcscript;

    private Image mesh = null; //背景の黒い網掛け。システムメニュー用
    private Transform pausebase = null; //ポーズメニューベース
    private float xposition; // メニューベースが動くためのyベクトル

    private bool pauseswitch;//pause状態かcharacter操作か
    private bool pausepulse;//ポーズボタンを連打できないようにするためのもの

    private float movingsec = 0;// メニューインアウトはSinで行うので、引数に使う時間を計測

    private float alpha = 0;

    [SerializeField] private float posemenu_disppoint; //pauseメニューが出た時の座標
    [SerializeField] private float posemenu_hidepoint; //pauseメニューが消えた時の座標

    // Start is called before the first frame update
    void Start()
    {
        pauseswitch = false;
        pausepulse = false;
        GameCon = GameObject.Find("GameCon");
        gcscript = GameCon.GetComponent<GameConScript>();//ゲームコントローラーを見る
        mesh = transform.Find("Mesh").GetComponent<Image>();//Meshのイメージコンポーネントを取得
        pausebase = transform.Find("PauseBase").GetComponent<RectTransform>();//Baseの座標とかを入手

        xposition = pausebase.localPosition.x;
    }

    IEnumerator BaseInAnimCor()
    {
        while (movingsec < 1.9)
        {
            movingsec += Time.fixedDeltaTime * 5f;
            pausebase.localPosition = new Vector3(xposition, 1200f * (-Mathf.Sin(movingsec) + 0.85f),0);
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }
        pausepulse = false;
    }
    IEnumerator BaseOutAnimCor()
    {
        while (0 < movingsec)
        {
            movingsec -= Time.fixedDeltaTime * 10f;
            pausebase.localPosition = new Vector3(xposition, 1200f * (-Mathf.Sin(movingsec) + 0.85f), 0);
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }
        pausepulse = false;
    }

    public void PauseMenuInOut()
    {
        if (Input.GetButtonDown("Pause") && pauseswitch == false && !pausepulse)
        {
            pauseswitch = true;//この状態の時はpauseメニュー操作モードになってる。
            pausepulse = true;
            gcscript.TimeStop(true);
            StartCoroutine(MeshInOut(true));
            StartCoroutine("BaseInAnimCor");
        }
        else if (Input.GetButtonDown("Pause") && pauseswitch == true && !pausepulse)
        {
            pauseswitch = false;//この状態の時はcharacter操作モードになってる。
            pausepulse = true;
            StartCoroutine(MeshInOut(false));
            StartCoroutine("BaseOutAnimCor");
            gcscript.TimeStop(false);
        }
    }

    IEnumerator MeshInOut(bool meshinout)//システムメニュー用のやつ
    {
        if (meshinout)
        {
            while (alpha < 0.5)
            {
                alpha +=Time.fixedDeltaTime*2;
                mesh.color = new Color(0, 0, 0, alpha);
                Debug.Log("ok");
                yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
            }
        }
        else
        {
            while (0 < alpha)
            {
                alpha -= Time.fixedDeltaTime*3;
                mesh.color = new Color(0, 0, 0, alpha);
                yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
