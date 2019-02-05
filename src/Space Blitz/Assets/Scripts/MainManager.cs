using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    // Attributes    
    private GameObject healthBar;
    private Image panel;
    private UIManager ui;
    private AudioSource audioSrc;
    private SpaceshipController controller;

    public GameObject[] pauseObjects;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        Time.timeScale = 1.0f;

        pauseObjects = GameObject.FindGameObjectsWithTag("Menu");
        healthBar = GameObject.FindGameObjectWithTag("Health");        

        ui = FindObjectOfType<UIManager>();

        if (SceneManager.GetActiveScene().name == "SelectionScene" || SceneManager.GetActiveScene().name == "DemoScene")
            audioSrc = ui.audioSrc;

        controller = new SpaceshipController();

        if (SceneManager.GetActiveScene().name == "DemoScene")
            HidePaused();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Uses the ESC button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseControl();
        }
    }

    /// <summary>
    /// Pauses the game
    /// </summary>
    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {            
            Time.timeScale = 0;            
            ShowPaused();
            audioSrc.Pause();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;            
            HidePaused();
            audioSrc.UnPause();
        }
    }

    /// <summary>
    /// Shows objects with ShowOnPause tag
    /// </summary> 
    public void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
            g.SetActive(true);

        healthBar.SetActive(false);
    }

    /// <summary>
    /// Hides objects with ShowOnPause tag
    /// </summary>
    public void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
            g.SetActive(false);

        healthBar.SetActive(true);
    }

    public void ShipSelection()
    {
        if (SceneManager.GetActiveScene().name == "DemoScene")
            audioSrc.Stop();
        PlayerPrefs.SetInt("Stop", 2);
        SceneManager.LoadScene("SelectionScene", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        audioSrc.Stop();
        PlayerPrefs.SetInt("Stop", 2);        
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);        
    }

    /// <summary>
    /// Restarts the minigame
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1;
        audioSrc.Stop();
        audioSrc.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    /// <summary>
    /// Quits out the game
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
