using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixChildRotation : MonoBehaviour
{

    Vector3 def;

    void Awake()
    {
        def = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;

        transform.localRotation = Quaternion.Euler(def - _parent);

        Vector3 result = transform.localRotation.eulerAngles;
        //Debug.Log("def=" + def + "     _parent=" + _parent + "     result=" + result);
    }


}