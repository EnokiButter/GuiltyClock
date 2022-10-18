using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

public class RoadText : MonoBehaviour
{
    [SerializeField] private TextAsset[] files;
    string[] result;



    string textbase;
    string textDeleteIndent;
    Regex deletIndent = new Regex("\\r\\n(\\r\\n)+");

    // Start is called before the first frame update
    void Start()
    {

    }

    public void RoadTextFile(int index)//sepまで分割だけはやる
    {
        try
        {
            var path = AssetDatabase.GetAssetPath(files[index]);
            using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                textbase = fs.ReadToEnd();
                textDeleteIndent = deletIndent.Replace(textbase, "\r\n");//改行だけの行は飛ばす

                //string[] del = { "<sep>" };//sepまで一気に表示してボタン入力待ち
                //result = textDeleteIndent.Split(del, StringSplitOptions.None);
                string[] del = { "\r\n" };//一行ずつ配列に代入
                result = textDeleteIndent.Split(del, StringSplitOptions.None);
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError(e);
        }
    }



    public string[] GetResult()
    {
        return result;
    }

    public TextAsset[] Getfiles()
    {
        return files;
    }


    // Update is called once per frame
    void Update()
    {

    }
}