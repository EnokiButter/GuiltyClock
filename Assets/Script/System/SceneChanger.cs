using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string sceneName;
    private float pos_x;
    private float pos_y;
    private float pos_z;

    GameObject FadeImageObj;
    GameObject CoverBlack;
    FadeImage fadeimageScr;
    GameObject Player;

    private GameObject Gate;
    private ChangeSceneDestination changeSDist;
    private Vector3 Pos;

    // Start is called before the first frame update
    void OnEnable()
    {
        FadeImageObj = GameObject.Find("UI/FadeCanvas/FadeImage");
        fadeimageScr = FadeImageObj.GetComponent<FadeImage>();
        CoverBlack = GameObject.Find("UI/FadeCanvas/CoverBlack");
        Player = GameObject.Find("Actor1");
    }
    public void ChangeScene(string name)
    {
        StartCoroutine(SceneOut(name));
    }

    public IEnumerator SceneOut(string name)
    {
        FadeImageObj.transform.localPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, FadeImageObj.transform.position.z);
        while (true)
        {
            if (fadeimageScr.Range + Time.deltaTime < 1)
            {
                fadeimageScr.Range += Time.deltaTime / (fadeimageScr.Range + 0.1f);
            }
            else
            {
                fadeimageScr.Range = 1;
                CoverBlack.SetActive(true);
                break;
            }
            yield return null;
        }
        SceneManager.LoadScene(name);
        this.transform.parent.transform.position = Pos;
        StartCoroutine("SceneEnter");
    }

    public IEnumerator SceneEnter()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        CoverBlack.SetActive(false);
        FadeImageObj.transform.localPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, FadeImageObj.transform.position.z);
        fadeimageScr.Range = 1;
        while (true)
        {
            if (0 < fadeimageScr.Range - Time.deltaTime)
            {
                fadeimageScr.Range -= Time.deltaTime / (fadeimageScr.Range + 0.1f);
            }
            else
            {
                fadeimageScr.Range = 0;
                break;
            }
            yield return null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gate")
        {
            Gate = other.gameObject;
            changeSDist = Gate.GetComponent<ChangeSceneDestination>();
            
            sceneName = changeSDist.GetSceneName();//îÚÇ‘SceneÇéÊìæ
            Pos = changeSDist.GetPlayerPos();//PlayerÇ™îÚÇ‘ç¿ïWÇéÊìæ

            Debug.Log("changescene");
            ChangeScene(sceneName);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
