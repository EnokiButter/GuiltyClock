using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    private Image image = null;
    [SerializeField] private float _startpoint;
    [SerializeField] private float _endpoint;
    [SerializeField] private float _interval;
    private float speed = 10;
    [SerializeField]bool _smooth;

    [SerializeField] private Color _color;
    private Color colortmp;
    RectTransform rect;

    GameObject player;
    PlayerStatus playerstatus;


    private float hp;
    private float hptmp;
    private float hpmax;
    private int damage;
    private bool pulse = false;
    public bool health = false;

    private float rCol;
    private float gCol;
    private float bCol;


    // Start is called before the first frame update
    void Start()
    {
        this.TryGetComponent(out image);
        rect = GetComponent<RectTransform>();
        player = GameObject.Find("Actor1");
        playerstatus = player.GetComponent<PlayerStatus>();

        colortmp = _color;
        this.image.color = _color;
        rCol = _color.r;
        gCol = _color.g;
        bCol = _color.b;
        hptmp = playerstatus.GetsetHP;
    }

    IEnumerator Slide(float diffvalue,float maxvalue,bool smooth) {
        float xTmp = rect.localPosition.x;
        float movediff = (_startpoint - _endpoint) * (diffvalue/maxvalue);
        speed = -movediff;

        if (smooth)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            while (xTmp + movediff <= rect.localPosition.x)
            {
                yield return new WaitForSecondsRealtime(_interval);
                rect.localPosition -= new Vector3(Time.unscaledDeltaTime * speed, 0, 0);
            }
        }
        else
        {
            rect.localPosition = new Vector3(xTmp + movediff, 0, 0);
            ColorChanger();
        }
    }

    public void ColorChanger() {
        if (hp / hpmax == 1.0f) 
        {
            colortmp = _color;
        }
        if ((0.5f < hp / hpmax) && (hp / hpmax < 1.0f))
        {
            colortmp = new Color(rCol, gCol, bCol - 0.5f);
        }
        if ((0.3f < hp / hpmax) && (hp / hpmax <= 0.5f)) 
        {
            colortmp = new Color(rCol + 1f,gCol,bCol - 1f);
        }
        if (hp / hpmax <= 0.3f)
        {
            colortmp = new Color(rCol + 1f,gCol - 1f,bCol - 1f);
        }
    }

    public void InitBar() 
    {
        float xtmp = rect.localPosition.x;
        float nowposi =  _endpoint + (_startpoint - _endpoint) * (hp / hpmax);
        rect.localPosition = new Vector3(nowposi, 0, 0);
        ColorChanger();
    }

    public void StatusBarAnim()
    {
        damage = playerstatus.GetDamage();
        hpmax = playerstatus.GetsetHPMAX;
        hp = playerstatus.GetsetHP;

        //ƒ_ƒ[ƒWŽž‚Ìˆ—‚½‚¿
        if (playerstatus.GetIsDamaging() && !pulse)
        {
            StartCoroutine(Slide(-damage, hpmax, _smooth));
            pulse = true;
        }
        else if (!playerstatus.GetIsDamaging() && pulse)
        {
            pulse = false;
        }

        if (hptmp < hp)
        {//‰ñ•œ‚µ‚½‚Æ‚«‚Ìˆ—
            InitBar();
        }
        this.image.color = colortmp;

        hptmp = hp;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
