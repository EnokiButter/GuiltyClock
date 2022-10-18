using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreMove : MonoBehaviour
{
    PlayerCon pccon;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pccon = GetComponentInParent<PlayerCon>();
    }

    public void SetRotate()
    {
        //Debug.Log("( " + pccon.GetSetRH + ", " + pccon.GetSetRV + ")");

        if(pccon.GetSetRH == 1f){
            if (pccon.GetSetRV == 1f) {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 45f, 0));
            }
            else if (pccon.GetSetRV == 0) {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 90f, 0));
            }
            else if (pccon.GetSetRV == -1) {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 145f, 0));
            }
        }else if (pccon.GetSetRH == -1) {
            if (pccon.GetSetRV == 1f)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, -45f, 0));
            }
            else if (pccon.GetSetRV == 0)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, -90f, 0));
            }
            else if (pccon.GetSetRV == -1)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, -135f, 0));
            }
        }
        else if(pccon.GetSetRH == 0)
        {
            if (pccon.GetSetRV == 1f)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0, 0));
            }
            else if (pccon.GetSetRV == -1)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0));
            }
        }

        if (pccon.GetIsSneek())
        {
            this.transform.localPosition = new Vector3(0,-1f,0);
        }
        else
        {
            this.transform.localPosition = new Vector3(0, 1, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
