using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//Membuat class function levelData
public class LevelData
{
    public LevelData(string levelName)
    {
        //variabel data mengambil nilai dari levelName yang di PlayerPrefs kan.
        string data = PlayerPrefs.GetString(levelName);
        //Jika data kosong
        if (data == "")
            return;

        string[] allData = data.Split('&');
        BestTime = float.Parse (allData[0]);
        SilverTime = float.Parse (allData[1]);
        GoldTime = float.Parse (allData[2]);
    }

    public float BestTime { set; get; }
    public float SilverTime { set; get; }
    public float GoldTime { set; get; }
}

public class MainMenu : MonoBehaviour
{
    //Membuat sebuah variabel konstatanta yang berarti nilainya tetap. Variabel terbesut bernama cameraSpeedTransition dan bertipe data float
    private const float cameraSpeedTransition = 3.0f;

	public Sprite[] borders;
    //Membuat beberapa variabel GameObject, Material, Text dll dan memiliki hak akses publik sehinnga variabel tersebut dapat muncul dalam inspektor dan digunakan untuk mereferensi objek.
    public GameObject levelBtnPrefabs;
    public GameObject levelBtnContainer;
    public GameObject shopBtnPrefabs;

    //Membuat sebuah variabel private yang bertipe data Transform, tipe data ini akan mengatur posisi, rotasi dan scale dari sebuah objek. 
    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    private bool nextLevelLocked = false;

	// Use this for initialization
	void Start ()
    {
        cameraTransform = Camera.main.transform;
        //Membuat variabel array thumbnails bertipe data Sprite yang isinya yaitu mengambil semua isi data yang bertipe sprite yang ada pada folder Resources, disana tertulis "Level" yg brarti difolder Resources masih ada folder Levels yang isinya menyimpan asset/sprite tersbt.
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
        foreach(Sprite thumbnail in thumbnails)
        {
            GameObject container = Instantiate(levelBtnPrefabs) as GameObject;
            container.GetComponent<Image>().sprite = thumbnail;
            container.transform.SetParent(levelBtnContainer.transform,false);
            LevelData level = new LevelData(thumbnail.name);
			string menit = ((int)level.BestTime / 60).ToString("00");
			string keloro = (level.BestTime % 60).ToString("00.00");

			GameObject bottomPanel = container.transform.GetChild (0).GetChild (0).gameObject;
			bottomPanel.GetComponent<Text>().text = (level.BestTime != 0.0f) ? menit +":"+ keloro : "Belum selesai";

            container.transform.GetChild(1).GetComponent<Image>().enabled = nextLevelLocked;
            //interactable adalah sebuah boolean, guna dipasang disini adalah untuk merubah nilai dari variabel nextLevelLocked menjadi true, sehingga level yg masih terkunci bisa terbuka.
            container.GetComponent<Button>().interactable = !nextLevelLocked;
			if (level.BestTime == 0.0f) 
			{
				nextLevelLocked = true;
			} 
			else if (level.BestTime < level.GoldTime) 
			{
				//mengambil bingkai emas
				bottomPanel.GetComponentInParent<Image>().sprite = borders[2];
			} 
			else if (level.BestTime < level.SilverTime) 
			{
				//mengambil bingkai silver
				bottomPanel.GetComponentInParent<Image>().sprite = borders[1];
			}
			else
			{
				//mengammbil bingkai perak
				bottomPanel.GetComponentInParent<Image>().sprite = borders[0];
			}

            //nama dari gambar yang ada di folder Resources/Levels
            string sceneName = thumbnail.name;
            //Menyisipkan function LoadScene yang memiliki parameter sceneName yang isinya diganti dengan thumbnail.name, yaitu merupakan nama dari gambar yang ada di folder Resources/Levels
            container.GetComponent<Button>().onClick.AddListener(() => LoadScene(sceneName));
        }
	}
	
    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
        ButtonSound.Instance.Moni();
    }

	// Update is called once per frame
	void Update ()
    {
	    if(cameraDesiredLookAt != null)
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, cameraSpeedTransition * Time.deltaTime);
        }
	}

  //  private void ChangePlayerSkins(int index)
  //  {
		//if((GameManager.Instance.skinAvailability & 1 << index) == 1 << index)
  //      {
  //          float x = (index % 4) * 0.25f;
  //          float y = ((int)index / 4) * 0.25f;

  //          if (y == 0.0f)
  //              y = 0.75f;
  //          else if (y == 0.25f)
  //              y = 0.5f;
  //          else if (y == 0.50f)
  //              y = 0.25f;
  //          else if (y == 0.75f)
  //              y = 0.0f;

  //          GameManager.Instance.Save();
  //      }
  //  }
}
