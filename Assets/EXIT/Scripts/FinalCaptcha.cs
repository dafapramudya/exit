using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalCaptcha : MonoBehaviour
{
    public InputField captcha;
    public GameObject panelFinal;
    public GameObject finalIncor;

    public DoorFinal pintuFinal;

	// Use this for initialization
	void Start ()
    {
        captcha.ActivateInputField();
	}
	
	// Update is called once per frame
	void Update ()
    {
        captcha.ActivateInputField();
        //maksudnya jika finalIncor gameObject setActivenya true
        //maka mengeset agar interactIcon di disabled
        if (finalIncor == true)
        {
            Interact.Instance.interactIcon.enabled = false;
        }
	}

    public void TutupUI()
    {
        panelFinal.SetActive(false);
        Time.timeScale = 1;
    }

    public void OKIncor()
    {
        finalIncor.SetActive(false);
        panelFinal.SetActive(true);
    }

    public void CloseIncor()
    {
        finalIncor.SetActive(false);
        panelFinal.SetActive(false);
        Time.timeScale = 1;
    }

    public void TombolOK()
    {
        if(captcha.text == "I want to EXIT")
        {
            panelFinal.SetActive(false);
            pintuFinal.isLocked = false;
            Time.timeScale = 1;
        }
        else
        {
            panelFinal.SetActive(false);
            finalIncor.SetActive(true);
            captcha.text = null;
        }
    }
}
