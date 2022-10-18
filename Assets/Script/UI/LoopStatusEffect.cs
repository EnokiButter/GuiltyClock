using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoopStatusEffect : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float startpoint;
    [SerializeField] float endpoint;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent < RectTransform > ();
    }

    // Update is called once per frame
    void Update()
    {
        rect.localPosition -= new Vector3(0.005f * speed,0,0);

                //Yが-11まで来れば、21.33まで移動する
        if(rect.localPosition.x <= endpoint){
            rect.localPosition = new Vector3(startpoint, -1.3f, 0f);
        }
    }
}
