using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
	private Rigidbody rb; //リジッドボディを取得するための変数
	PlayerStatus PlSt;

	private bool isGround;
	private Animator anim = null;
	private float h = 0;
	private float v = 0;
	private bool isDamaged;

	[SerializeField] public float speed = 1.0f;
	[SerializeField] public float speedDef = 1.0f;
	[SerializeField] public float sneakMag = 5.0f;
	[SerializeField] public float upForce = 300f;

	// Start is called before the first frame update
	void Start(){
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		PlSt = this.GetComponent<PlayerStatus>();
	}

	// Update is called once per frame
	void FixedUpdate(){
		isDamaged = PlSt.getIsDamaged();
        if (!isDamaged) { 
			PlayerMove();
		}
    }
    void Update(){
		PlayerJump();
	}

	void PlayerMove(){
		h = 0;
		v = 0;
		//スピード計算
		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = sneakMag;
		}
		else
		{
			speed = speedDef;
		}
		//前後左右移動

		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			v = 1;
			anim.SetBool("RunBack", true);
		}
		else {
			anim.SetBool("RunBack", false);
		}
		if (Input.GetKey("s") || Input.GetKey("down"))
		{
			v = -1;
			anim.SetBool("RunFront", true);
		}
		else {
			anim.SetBool("RunFront", false);
		}
		if (Input.GetKey("d") || Input.GetKey("right"))
		{
			h = 1;
			anim.SetBool("RunFrontRight", true);
        }
        else
        {
			anim.SetBool("RunFrontRight", false);
		}
		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			h = -1;
			anim.SetBool("RunFrontLeft", true);
		}
		else {
			anim.SetBool("RunFrontLeft", false);
		}

		transform.localPosition += new Vector3(h, 0, v).normalized * speed * Time.fixedDeltaTime;
	}
	void PlayerJump(){
		//ジャンプ
		if (isGround == true)
		{
			if (Input.GetKeyDown("space"))
			{
				isGround = false;
				//ジャンプ処理は力学で
				rb.AddForce(new Vector3(0, upForce, 0));
			}
		}
	}
    //接地の時の処理
    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
			speed = speedDef;
        }
    }
}
