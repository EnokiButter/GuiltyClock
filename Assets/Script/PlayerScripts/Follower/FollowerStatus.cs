using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerStatus : MonoBehaviour
{
    [SerializeField,Range(0,4)] private int modeSelector;//モード
    [SerializeField, Disable] private string modeName;//モード名インスペクター表示用

    [SerializeField] private int springMax;//ゼンマイのキャパ
    [SerializeField] private int springtmp;//ゼンマイの現在の巻き具合

    [SerializeField] private int steamMax;//蒸気のキャパ
    [SerializeField] private int steamBottle;//蒸気のストック
    [SerializeField] private int steamtmp;//現在の蒸気量


    // Start is called before the first frame update
    void Start()
    {
        modeSelector = 0;
    }
    


    // Update is called once per frame
    void Update()
    {
        switch (modeSelector)
        {
            case 0:
                modeName = "プロペラ";
                break;
            case 1:
                modeName = "B";
                break;
            case 2:
                modeName = "C";
                break;
            case 3:
                modeName = "D";
                break;
            case 4:
                modeName = "E";
                break;
        }    
    }
}
