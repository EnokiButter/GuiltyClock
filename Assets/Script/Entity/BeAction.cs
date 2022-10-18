using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAction : MonoBehaviour
{
    [SerializeField] private bool actionAble;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool GetSetActionAble
    {
        get { return actionAble; }
        set { actionAble = value; }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
