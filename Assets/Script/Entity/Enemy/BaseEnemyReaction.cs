using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyReaction : MonoBehaviour
{
    GameObject EnemyBody;
    EnemyStatus enst;

    protected GameObject Player;
    protected PlayerStatus ps;

    // Start is called before the first frame update
    protected virtual void OnEnable()
    {
        Player = GameObject.Find("Actor1");
        ps = Player.GetComponent<PlayerStatus>();
        EnemyBody = transform.Find("Sprite").gameObject;
        enst = EnemyBody.GetComponent<EnemyStatus>();
    }



    public abstract void HAttensionReaction();
    public abstract void HDiscoverReaction();
    public abstract void VAttensionReaction();
    public abstract void VDiscoverReaction();
    public abstract void LosesightReaction();

    // Update is called once per frame
    void Update()
    {
        
    }
}
