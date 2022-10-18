using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindowScript : MonoBehaviour
{
    GameObject TalkWindow;
    [SerializeField] bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        TalkWindow = transform.Find("TalkWindow").gameObject;
    }

    public void ActivateTalkWindow(bool act)
    {
        TalkWindow.SetActive(act);
    }

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            ActivateTalkWindow(true);
        }
    }
}
