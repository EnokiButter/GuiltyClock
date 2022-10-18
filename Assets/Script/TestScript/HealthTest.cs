using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    GameObject Actor;
    PlayerStatus psscript;

    int plushealth;
    bool regene;
    bool pulse;

    // Start is called before the first frame update
    void Start()
    {
        pulse = false;
        regene = false;
        plushealth = 3;
        Actor = GameObject.Find("Actor1");
        psscript = Actor.GetComponent<PlayerStatus>();
    }

    public void Health()
    {
        if (psscript.GetsetHP == psscript.GetsetHPMAX)
        {
            Debug.Log("ismax");
        }
        else
        {
            if (plushealth <= psscript.GetsetHPMAX - psscript.GetsetHP)
            {
                psscript.GetsetHP += plushealth;
            }
            else
            {
                psscript.GetsetHP += psscript.GetsetHPMAX - psscript.GetsetHP;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            if (regene)
            {
                Health();
            }
            else 
            {
                if (!pulse) {
                    Health();
                    pulse = true;
                }
                else { }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pulse = false;
    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
}
