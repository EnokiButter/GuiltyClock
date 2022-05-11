using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Image image = null;
    
    // Start is called before the first frame update
    void Start()
    {
        this.TryGetComponent(out image);
    }

    // Update is called once per frame
    void Update()
    {
        this.image.color = new Color(0f,255f,0f,255f);
    }
}
