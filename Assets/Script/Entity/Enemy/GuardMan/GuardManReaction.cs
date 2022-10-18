using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManReaction : BaseEnemyReaction
{

    Vector3 playerPos;
    [SerializeField] float stopx;
    [SerializeField] float stopz;
    [SerializeField] float chaseSpeed;
    float rad;//Šp“xŽæ“¾‚Ì‚½‚ß‚Ì•Ï”
    float degree;//Šp“xŽæ“¾‚Ì‚½‚ß‚Ì•Ï”
    Vector3 dt;//Šp“xŽæ“¾‚Ì‚½‚ß‚Ì•Ï”
    private float discoverWait;
    private bool isChase;

    // Start is called before the first frame update
    protected override void OnEnable()
    {
        base.OnEnable();
        discoverWait = 0.5f;
        isChase = false;
    }



    public override void HAttensionReaction()
    {
        throw new System.NotImplementedException();
    }
    public override void HDiscoverReaction()
    {
            playerPos = Player.transform.position;
            this.transform.rotation = Quaternion.Euler(new Vector3(0, GetAngle(this.transform.position, playerPos), 0));

    }
    public override void VAttensionReaction()
    {
        throw new System.NotImplementedException();
    }

    public override void VDiscoverReaction()
    {
        if (!isChase)
        {
            StartCoroutine("DiscoverWait");
        }
        else
        {
            playerPos = Player.transform.position;
            if ((GetABSVal(playerPos.x - this.transform.position.x) >= stopx) ||
                (GetABSVal(playerPos.z - this.transform.position.z) >= stopz))
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, GetAngle(this.transform.position, playerPos), 0));
                this.transform.position += transform.forward * Time.deltaTime * chaseSpeed;
            }
        }
    }
    public override void LosesightReaction()
    {
        throw new System.NotImplementedException();
    }



    IEnumerator DiscoverWait()
    {
        yield return new WaitForSecondsRealtime(discoverWait);
        isChase = true;
    }
    public float GetABSVal(float val)//â‘Î’lŽæ‚é‚â‚Â
    {
        if (val >= 0)
            return val;
        else
            return -val;
    }
    public float GetAngle(Vector3 start, Vector3 target)//Šp“x‚ðŽæ“¾
    {
        dt = target - start;
        rad = Mathf.Atan2(dt.x, dt.z);
        degree = rad * Mathf.Rad2Deg;
        return degree;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
