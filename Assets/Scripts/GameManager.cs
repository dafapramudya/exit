using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public int currentSkinIndex = 0;
    public int currency = 0;
    public int skinAvailability = 1;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        if (PlayerPrefs.HasKey("CurrentSkin"))
        {
            //We Had A Previous Session
            currentSkinIndex = PlayerPrefs.GetInt("CurrentSkin");
            currency = PlayerPrefs.GetInt("Currency");
            skinAvailability = PlayerPrefs.GetInt("SkinAvaibility");
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("CurrentSkin", currentSkinIndex);
        PlayerPrefs.SetInt("Currency", currency);
        PlayerPrefs.SetInt("SkinAvaibility", skinAvailability);
    }

    // Use this for initialization
    void Start()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
