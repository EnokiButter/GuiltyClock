using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixChildRotation : MonoBehaviour
{

    Vector3 def;
    [SerializeField] private bool FollowX;
    [SerializeField] private bool FollowY;
    [SerializeField] private bool FollowZ;

    void Awake()
    {
        def = transform.localRotation.eulerAngles;
    }

    void Update()
    {
        Vector3 _parent = transform.parent.transform.localRotation.eulerAngles;
        if (FollowX)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(def.x, def.y - _parent.y, def.z - _parent.z));
        }
        if (FollowY)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(def.x - _parent.x, _parent.y, def.z - _parent.z));
        }
        if (FollowZ)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(def.x - _parent.x, def.y - _parent.y, _parent.z));
        }
        if (!FollowX && !FollowY && !FollowZ)
        {
            transform.localRotation = Quaternion.Euler(def - _parent);
        }

        Vector3 result = transform.localRotation.eulerAngles;
    }


}