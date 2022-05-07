using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    
    private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    private float bufferX = 0.7f;
    private float bufferZ = 0.8f;
    private float bufferY = 0.6f;
    public float CameraDistanceZ = 4f;
    public float CameraDistanceY = 3f;
    private Vector3 CameraPos;
    public float CameraSpeedLo = 0.01f;
    public float CameraSpeedHi = 0.08f;

 
	// Use this for initialization
	void Start () {
        //playerの情報を取得
        this.player = GameObject.Find("Actor1");
        CameraPos.x = 0;
        CameraPos.z = 0;
        CameraPos.y = 0;
    }
	// Update is called once per frame
	void Update () {
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position;
        //x軸上でのバッファ
        if (offset.x > bufferX / 2)
        {
            CameraPos.x = -CameraSpeedLo;
            if (offset.x > bufferX) {
                CameraPos.x = -CameraSpeedHi;
            }
        }
        else if (-offset.x > bufferX / 2)
        {
            CameraPos.x = CameraSpeedLo;
            if (-offset.x > bufferX) {
                CameraPos.x = CameraSpeedHi;
            }
        }
        else
        {
            CameraPos.x = 0;
        }
        //z軸上でのバッファ
        if (offset.z > bufferZ - CameraDistanceZ)
        {
            CameraPos.z = -CameraSpeedHi;
        }
        else if (-offset.z > bufferZ + CameraDistanceZ)
        {
            CameraPos.z = CameraSpeedHi;
        }
        else
        {
            CameraPos.z = 0;
        }
        //y軸上でのバッファ
        if (offset.y > bufferY + CameraDistanceY)
        {
            CameraPos.y = -CameraSpeedHi;
        }
        else if (-offset.y > bufferY - CameraDistanceY)
        {
            CameraPos.y = CameraSpeedHi;
        }
        else
        {
            CameraPos.y = 0;
        }

        transform.position += CameraPos;
	}
    

}
