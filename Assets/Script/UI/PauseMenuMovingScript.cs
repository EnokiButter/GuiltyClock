using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuMovingScript : MonoBehaviour
{

    GameObject GameCon;
    GameConScript gcscript;

    private Image mesh = null; //�w�i�̍����Ԋ|���B�V�X�e�����j���[�p
    private Transform pausebase = null; //�|�[�Y���j���[�x�[�X
    private float xposition; // ���j���[�x�[�X���������߂�y�x�N�g��

    private bool pauseswitch;//pause��Ԃ�character���삩
    private bool pausepulse;//�|�[�Y�{�^����A�łł��Ȃ��悤�ɂ��邽�߂̂���

    private float movingsec = 0;// ���j���[�C���A�E�g��Sin�ōs���̂ŁA�����Ɏg�����Ԃ��v��

    private float alpha = 0;

    [SerializeField] private float posemenu_disppoint; //pause���j���[���o�����̍��W
    [SerializeField] private float posemenu_hidepoint; //pause���j���[�����������̍��W

    // Start is called before the first frame update
    void Start()
    {
        pauseswitch = false;
        pausepulse = false;
        GameCon = GameObject.Find("GameCon");
        gcscript = GameCon.GetComponent<GameConScript>();//�Q�[���R���g���[���[������
        mesh = transform.Find("Mesh").GetComponent<Image>();//Mesh�̃C���[�W�R���|�[�l���g���擾
        pausebase = transform.Find("PauseBase").GetComponent<RectTransform>();//Base�̍��W�Ƃ������

        xposition = pausebase.localPosition.x;
    }

    IEnumerator BaseInAnimCor()
    {
        while (movingsec < 1.9)
        {
            movingsec += Time.fixedDeltaTime * 5f;
            pausebase.localPosition = new Vector3(xposition, 1200f * (-Mathf.Sin(movingsec) + 0.85f),0);
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }
        pausepulse = false;
    }
    IEnumerator BaseOutAnimCor()
    {
        while (0 < movingsec)
        {
            movingsec -= Time.fixedDeltaTime * 10f;
            pausebase.localPosition = new Vector3(xposition, 1200f * (-Mathf.Sin(movingsec) + 0.85f), 0);
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
        }
        pausepulse = false;
    }

    public void PauseMenuInOut()
    {
        if (Input.GetButtonDown("Pause") && pauseswitch == false && !pausepulse)
        {
            pauseswitch = true;//���̏�Ԃ̎���pause���j���[���샂�[�h�ɂȂ��Ă�B
            pausepulse = true;
            gcscript.TimeStop(true);
            StartCoroutine(MeshInOut(true));
            StartCoroutine("BaseInAnimCor");
        }
        else if (Input.GetButtonDown("Pause") && pauseswitch == true && !pausepulse)
        {
            pauseswitch = false;//���̏�Ԃ̎���character���샂�[�h�ɂȂ��Ă�B
            pausepulse = true;
            StartCoroutine(MeshInOut(false));
            StartCoroutine("BaseOutAnimCor");
            gcscript.TimeStop(false);
        }
    }

    IEnumerator MeshInOut(bool meshinout)//�V�X�e�����j���[�p�̂��
    {
        if (meshinout)
        {
            while (alpha < 0.5)
            {
                alpha +=Time.fixedDeltaTime*2;
                mesh.color = new Color(0, 0, 0, alpha);
                Debug.Log("ok");
                yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
            }
        }
        else
        {
            while (0 < alpha)
            {
                alpha -= Time.fixedDeltaTime*3;
                mesh.color = new Color(0, 0, 0, alpha);
                yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
