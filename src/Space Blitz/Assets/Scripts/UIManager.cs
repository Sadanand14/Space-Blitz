using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject[] shipList;
    private int index;
    private int scene;
    public AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        audioSrc = GameObject.FindGameObjectWithTag("Background").GetComponent<AudioSource>();

        scene = PlayerPrefs.GetInt("Stop");

        // Ensures that music does not overlap
        if (scene != 1)
            audioSrc.Play();
        else if (scene == 2)
            audioSrc.volume = 0f;
        else
            audioSrc.volume = 0.75f;

        index = PlayerPrefs.GetInt("ShipSelected");

        shipList = new GameObject[transform.childCount];

        // Fill Array with ship models
        for (int i = 0; i < transform.childCount; i++)
            shipList[i] = transform.GetChild(i).gameObject;

        // Turn off their render
        foreach (GameObject go in shipList)
            go.SetActive(false);

        // Toggle on the selected character
        if (shipList[index])
            shipList[index].SetActive(true);
    }

    // Update once per frame
    void Update()
    {
        foreach (GameObject go in shipList)
        {
            if (go == shipList[index])
            {
                continue;
            }
            go.SetActive(false);
            for (int i = 0; i < go.transform.childCount; i++)
            {
                go.transform.GetChild(i).gameObject.SetActive(false);
                if (go.transform.GetChild(i).gameObject.GetComponent<Camera>())
                {
                    go.transform.GetChild(i).tag = "Untagged";
                }
            }
        }
    }

    // Toggles left through ship options
    public void ToggleLeft()
    {
        // Toggle off the current model
        shipList[index].SetActive(false);

        index--;
        if (index < 0)
            index = shipList.Length - 1;

        // Switch to new model
        shipList[index].SetActive(true);
        for (int i = 0; i < shipList[index].transform.childCount; i++)
        {
            shipList[index].transform.GetChild(i).gameObject.SetActive(true);
            if (shipList[index].transform.GetChild(i).gameObject.GetComponent<Camera>())
            {
                shipList[index].transform.GetChild(i).tag = "MainCamera";
            }
        }
    }

    // Toggles right through ship options
    public void ToggleRight()
    {
        // Toggle off the current model
        shipList[index].SetActive(false);

        index++;
        if (index == shipList.Length)
            index = 0;

        // Switch to new model
        shipList[index].SetActive(true);
        for (int i = 0; i < shipList[index].transform.childCount; i++)
        {
            shipList[index].transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void ChangeScene()
    {
        PlayerPrefs.SetInt("ShipSelected", index);
        PlayerPrefs.SetInt("Stop", 1);
        DontDestroyOnLoad(audioSrc);
        SceneManager.LoadScene("DemoScene");
    }

    //DamageIndicator
    public int CurrentShipIndex
    {
        get
        {
            return index;
        }
    }
    //DamageIndicator
}
