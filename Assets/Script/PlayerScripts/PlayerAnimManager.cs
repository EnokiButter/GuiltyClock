using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimManager : MonoBehaviour
{
    private Animator anim = null;
    PlayerCon pcon;
    // Start is called before the first frame update
    void Start()
    {
        pcon = GetComponent<PlayerCon>();
        anim = GetComponent<Animator>();
    }

    public void RunPlayer(string direction, bool doing)
    {
        if (0 < Time.timeScale) {
            if (pcon.GetIsSneek())
            {
                switch (direction)
                {
                    case "Front":
                        anim.SetBool("RunFront", doing);
                        break;
                    case "Back":
                        anim.SetBool("RunBack", doing);
                        break;
                    case "FrontRight":
                        anim.SetBool("RunFrontRight", doing);
                        break;
                    case "FrontLeft":
                        anim.SetBool("RunFrontLeft", doing);
                        break;
                    case "BackRight":
                        anim.SetBool("RunBackRight", doing);
                        break;
                    case "BackLeft":
                        anim.SetBool("RunBackLeft", doing);
                        break;
                    default:
                        Debug.Log("注意：関数RunPlayer()の第一引数にはFrontRight、FrontLeft、BackRight、BackLeftのいずれかを入力");
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case "Front":
                        anim.SetBool("RunFront", doing);
                        break;
                    case "Back":
                        anim.SetBool("RunBack", doing);
                        break;
                    case "FrontRight":
                        anim.SetBool("RunFrontRight", doing);
                        break;
                    case "FrontLeft":
                        anim.SetBool("RunFrontLeft", doing);
                        break;
                    case "BackRight":
                        anim.SetBool("RunBackRight", doing);
                        break;
                    case "BackLeft":
                        anim.SetBool("RunBackLeft", doing);
                        break;
                    default:
                        Debug.Log("注意：関数RunPlayer()の第一引数にはFrontRight、FrontLeft、BackRight、BackLeftのいずれかを入力");
                        break;
                }
            }
        }
    }

    public void SquatPlayer(bool doing)
    {
        anim.SetBool("Squat", doing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
