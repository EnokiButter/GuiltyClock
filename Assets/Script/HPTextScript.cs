using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTextScript : MonoBehaviour
{

    void Start()
    {

    }

    public void HPCount(int hpnow,int hpmax) {
        string hpstr = hpnow.ToString() + "/" + hpmax.ToString();
        gameObject.GetComponent<UnityEngine.UI.Text>().text = hpstr;
    }

    public void HPVibration(){

    }
    private void HPExpansion(){

    }

    // Update is called once per frame
    void Update()
    {
    }
}
