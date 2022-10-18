using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneDestination : MonoBehaviour
{

    [SerializeField] private string sceneName;
    [SerializeField] private float pos_x;
    [SerializeField] private float pos_y;
    [SerializeField] private float pos_z;

    Vector3 playerPos;
    
    public string GetSceneName()
    {
        return sceneName;
    }
    public Vector3 GetPlayerPos()
    {
        playerPos = new Vector3(pos_x,pos_y,pos_z);
        return playerPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
