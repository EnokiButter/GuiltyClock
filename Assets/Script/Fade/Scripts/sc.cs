using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc : MonoBehaviour
{
    GameObject FadeImageObj;
    GameObject CoverBlack;
    FadeImage fadeimageScr;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        FadeImageObj = GameObject.Find("FadeCanvas/FadeImage");
        fadeimageScr = FadeImageObj.GetComponent<FadeImage>();
        CoverBlack = GameObject.Find("FadeCanvas/Image");
        Player = GameObject.Find("Player");
        StartCoroutine("SceneEnter");

    }

    public void SceneChanger()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fadeimageScr.Range == 0)
            {
                StartCoroutine("SceneOut");
            }
        }
    }

    public IEnumerator SceneOut()
    {
        FadeImageObj.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        while (true)
        {
            if (fadeimageScr.Range + Time.deltaTime < 1)
            {
                fadeimageScr.Range += Time.deltaTime/(fadeimageScr.Range+0.1f);
            }
            else
            {
                fadeimageScr.Range = 1;
                break;
            }
            yield return null;
        }
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            SceneManager.LoadScene("2");
        }
        if (SceneManager.GetActiveScene().name == "2") 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public IEnumerator SceneEnter()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        CoverBlack.SetActive(false);
        FadeImageObj.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
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


    // Update is called once per frame
    void Update()
    {
        SceneChanger();
    }
}
