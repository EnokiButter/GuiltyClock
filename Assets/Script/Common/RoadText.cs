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

    public void RoadTextFile(int index)//sep�܂ŕ��������͂��
    {
        try
        {
            var path = AssetDatabase.GetAssetPath(files[index]);
            using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                textbase = fs.ReadToEnd();
                textDeleteIndent = deletIndent.Replace(textbase, "\r\n");//���s�����̍s�͔�΂�

                //string[] del = { "<sep>" };//sep�܂ň�C�ɕ\�����ă{�^�����͑҂�
                //result = textDeleteIndent.Split(del, StringSplitOptions.None);
                string[] del = { "\r\n" };//��s���z��ɑ��
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