using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerFollow : MonoBehaviour
{
    GameObject PlayerCore;
    private Vector3 pos;
    private Vector3 targetpos;
    private Vector3 direction;

    float rad;//�p�x�擾�̂��߂̕ϐ�
    float degree;//�p�x�擾�̂��߂̕ϐ�
    Vector3 dt;//�p�x�擾�̂��߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        PlayerCore = GameObject.Find("Actor1/ActorCore/Followpoint");
    }

    public void FollowPlayer(bool onoff)
    {
        if (onoff)
            {

            pos = PlayerCore.transform.position;
            StrayWarp();
            targetpos = new Vector3(pos.x - PlayerCore.transform.forward.x, pos.y - PlayerCore.transform.forward.y, pos.z - PlayerCore.transform.forward.z);
        
            if ((GetABSVal(pos.x - this.transform.position.x) >= 0.1f) ||
                (GetABSVal(pos.z - this.transform.position.z) >= 0.1f) ||
                (GetABSVal(pos.y - this.transform.position.y) >= 0.1f)
                )
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, GetAngle(this.transform.position, pos), 0));
                this.transform.position += transform.forward * Time.deltaTime * 5;
            }
            if(GetABSVal(pos.y - this.transform.position.y) > 0f)
            {
                this.transform.position = new Vector3(this.transform.position.x, pos.y, this.transform.position.z);
            }
        }

    }

    public float GetABSVal(float val)//��Βl�����
    {
        if (val >= 0)
            return val;
        else
            return -val;
    }
    public float GetAngle(Vector3 start, Vector3 target)//�p�x���擾
    {
        dt = target - start;
        rad = Mathf.Atan2(dt.x,dt.z);
        degree = rad * Mathf.Rad2Deg;
        return degree;
    }

    public void StrayWarp()
    {
        if ((GetABSVal(pos.x - this.transform.position.x) >= 3f) ||
            (GetABSVal(pos.z - this.transform.position.z) >= 3f) ||
            (GetABSVal(pos.y - this.transform.position.y) >= 3f)
            )
        {
            this.transform.position = pos;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
