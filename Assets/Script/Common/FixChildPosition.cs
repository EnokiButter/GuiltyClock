using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixChildPosition : MonoBehaviour
{
    Vector3 def;

    void Awake()
    {
        def = transform.position;
    }

    void Update()
    {
        transform.position = def;
        Vector3 result = transform.localPosition;
    }
}
