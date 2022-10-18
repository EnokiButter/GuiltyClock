using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerStatus : MonoBehaviour
{
    [SerializeField,Range(0,4)] private int modeSelector;//���[�h
    [SerializeField, Disable] private string modeName;//���[�h���C���X�y�N�^�[�\���p

    [SerializeField] private int springMax;//�[���}�C�̃L���p
    [SerializeField] private int springtmp;//�[���}�C�̌��݂̊����

    [SerializeField] private int steamMax;//���C�̃L���p
    [SerializeField] private int steamBottle;//���C�̃X�g�b�N
    [SerializeField] private int steamtmp;//���݂̏��C��


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
                modeName = "�v���y��";
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
