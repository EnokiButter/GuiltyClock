using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDontDestroy : SingletonMonoBehaviour<UIDontDestroy>
{
    // Start is called before the first frame update
    void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
