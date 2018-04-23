using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinKey : MonoBehaviour
{
    public InputField pinInput;
    public GameObject canvasUI;
    public GameObject canvasIncor;

    public DoorBank pintuku;

	// Use this for initialization
	void Start ()
    {
        pinInput.ActivateInputField();
	}
	
	// Update is called once per frame
	void Update ()
    {
        pinInput.ActivateInputField();
        if (canvasIncor == true)
        {
            Interact.Instance.interactIcon.enabled = false;
        }
    }

    public void CloseUI()
    {
        canvasUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void CloseUIIncor()
    {
        canvasIncor.SetActive(false);
        canvasUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OKIncorr()
    {
        canvasIncor.SetActive(false);
        canvasUI.SetActive(true);
    }

    public void OKButton()
    {
        if (pinInput.text == "3358570")
        {
            canvasUI.SetActive(false);
            pintuku.isLocked = false;
            Time.timeScale = 1;
        }
        else
        {
            canvasUI.SetActive(false);
            canvasIncor.SetActive(true);
            pinInput.text = null;
        }
    }
}
