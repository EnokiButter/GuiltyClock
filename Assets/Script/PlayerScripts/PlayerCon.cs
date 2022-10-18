using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
	private Rigidbody rb; //リジッドボディを取得するための変数
	PlayerStatus status;

	MobTalk mobtalk;//

	PlayerAnimManager anim_manager;//アニメーション動かすクラス

	private float h = 0;
	private float v = 0;
	private float rh = 0;
	private float rv = 0;

	private float actionCounter;//アクションボタンを押されている時間を計測

	private bool isDamaging;
	[SerializeField, Disable] private bool isGround;
	[SerializeField, Disable] private bool isSneek;
	[SerializeField, Disable] private bool isMove;
	private bool stiffens;

	[SerializeField] public float speed;
	[SerializeField] public float speedDef;
	[SerializeField] public float sneakMag;
	[SerializeField] public float upForce = 300f;

	// Start is called before the first frame update
	void Start(){
		h = 0;
		v = 0;
		rh = 0;
		rv = 0;
		isMove = false;
		isSneek = false;
		anim_manager = this.GetComponent<PlayerAnimManager>();
		rb = GetComponent<Rigidbody>();
		status = this.GetComponent<PlayerStatus>();
	}

	public float GetSetRH
    {
		get { return rh; }
        set { h = value; }
    }

	public float GetSetRV
    {
        get { return rv; }
        set { v = value; }
    }


	public bool GetIsSneek()
    {
		return isSneek;
    }

	public void ActorMove(){
		h = 0;
		v = 0;
		//スピード計算
		if (Input.GetButton("Sneak"))
		{
			isSneek = true;
			status.SetIsSneek(isSneek);
			speed = sneakMag;
			anim_manager.SquatPlayer(isSneek);
		}
		else
		{
			isSneek = false;
			status.SetIsSneek(isSneek);
			speed = speedDef;
			anim_manager.SquatPlayer(isSneek);
		}
		//前後左右移動

		if (Input.GetKey("w") || Input.GetKey("up"))
		{
			v = 1;
			rv = 1;
			anim_manager.RunPlayer("Back",true);
		}
		else {
			anim_manager.RunPlayer("Back", false);
		}
		if (Input.GetKey("s") || Input.GetKey("down"))
		{
			v = -1;
			rv = -1;
			anim_manager.RunPlayer("Front", true);
		}
		else {
			anim_manager.RunPlayer("Front", false);
		}
		if (Input.GetKey("d") || Input.GetKey("right"))
		{
			h = 1;
			rh = 1;
			anim_manager.RunPlayer("FrontRight", true);
		}
        else
        {
			anim_manager.RunPlayer("FrontRight", false);
		}
		if (Input.GetKey("a") || Input.GetKey("left"))
		{
			h = -1;
			rh = -1;
			anim_manager.RunPlayer("FrontLeft", true);
		}
		else {
			anim_manager.RunPlayer("FrontLeft", false);

		}

        if (Input.GetKeyUp("w") || Input.GetKeyUp("s"))
        {
			rv = 0;
        }
		if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
			rh = 0;
        }

		transform.localPosition += new Vector3(h, 0, v).normalized * speed * Time.deltaTime;
		if((h == 0 && v == 0) || !isGround)
        {
			isMove = false;
			status.SetIsMove(isMove);
        }
        else
        {
			isMove = true;
			status.SetIsMove(isMove);
		}
	}
	public void ActorJump(){
		//ジャンプ
		if (isGround == true)
		{
			if (Input.GetKeyDown("space") || Input.GetButtonDown("Jump"))
			{
				isGround = false;
				//ジャンプ処理は力学で
				rb.AddForce(new Vector3(0, upForce, 0));
				//anim_manager.RunPlayer("Jump", true); //これはジャンプのフラグ用です
			}
		}
	}
    //接地の時の処理
    public void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
			speed = speedDef;
			isMove = true;
			status.SetIsMove(isMove);
			//anim_manager.RunPlayer("Jump", false);//これはジャンプのフラグ用です
		}
    }

	public float Action()
    {
        if (Input.GetKey("o")) {
			actionCounter += Time.deltaTime;
		}
		if(!Input.GetKey("o"))
		{
			actionCounter = 0f;
        }
		return actionCounter;
		//Debug.Log(actionCounter);
    }

	public void ActorCon()
    {
		stiffens = status.GetStiffens();//硬直していないとき
		if (!stiffens)
		{
			ActorMove();
			ActorJump();
			Action();
		}
	}

	public void StartTalk()
    {
		status.GetSetPlayerMode = "talk";
		anim_manager.RunPlayer("Front", false);
		anim_manager.RunPlayer("Back", false);
		anim_manager.RunPlayer("FrontRight", false);
		anim_manager.RunPlayer("FrontLeft", false);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}

