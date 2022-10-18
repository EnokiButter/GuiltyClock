using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAnim : MonoBehaviour
{
    private Animator anim = null;
    private string[] dirNames = new string[] { "Winding", "ReWind", "Decrease" };
    private bool wait;
    FollowerCon fCon;
    

    // Start is called before the first frame update
    void Start()
    {
        wait = false;
        anim = GetComponent<Animator>();
    }

    public string[] GetDirNames()
    {
        return dirNames;
    }
    public bool GetWait()
    {
        return wait;
    }

    public void Winding(string dir,float animspeed, bool doing)
    {
        anim.SetBool(dir,doing);
        anim.speed = animspeed;
        if (dir == "ReWind")
        {
            wait = true;
        }
    }


    public void AnimOff(string dir)
    {
        anim.SetBool(dir,false);
    }
    public void WindInterval() {
        wait = false;
    }


    // Update is called once per frame
    void Update()
    {
    }
}
