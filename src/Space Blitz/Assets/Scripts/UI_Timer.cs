using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    public GameObject Item;
    public GameObject itemInfo;
    public GameObject timer;
    public Text grade;
    public string score;
    public string nameOne;

    private List<Score> scoreList;
    private GameObject gameOverPane;
    private Text text_timeSpend;
    private string nextline;
    private int minute;
    private int second;
    private int millisecond;    

    // Use this for initialization
    void Start()
    {
        scoreList = new List<Score>();

        nextline = "123";

        StreamReader sr = new StreamReader(Application.dataPath + "/RankingList.txt");
        while ((nextline = sr.ReadLine()) != null)
        {
            scoreList.Add(JsonUtility.FromJson<Score>(nextline));
        }
        sr.Close();

        gameOverPane = GameObject.FindGameObjectWithTag("GameOver");
        gameOverPane.SetActive(false);
    }

    public void getScore()
    {
        score = timer.GetComponent<Timer>().text_timeSpend.text;
        minute = timer.GetComponent<Timer>().minute;
        second = timer.GetComponent<Timer>().second;
        millisecond = timer.GetComponent<Timer>().millisecond;
        grade.text = timer.GetComponent<Timer>().text_timeSpend.text;
    }

    public void gameEnd()
    {
        gameOverPane.SetActive(true);

        scoreList.Add(new Score(nameOne, score, minute, second, millisecond));
        scoreList.Sort();

        StreamWriter sw = new StreamWriter(Application.dataPath + "/RankingList.txt");

        if (scoreList.Count > 5) for (int i = 5; i <= scoreList.Count; i++)
                scoreList.RemoveAt(i);

        for (int i = 0; i < scoreList.Count; i++)
        {
            sw.WriteLine(JsonUtility.ToJson(scoreList[i]));
        }
        sw.Close();

        for (int i = 0; i < scoreList.Count; i++)
        {
            GameObject item = Instantiate(Item.gameObject, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), itemInfo.transform);

            item.gameObject.SetActive(true);

            item.transform.Find("Number").GetComponent<Text>().text = (i + 1).ToString();
            item.transform.Find("Score").GetComponent<Text>().text = scoreList[i].score;
        }

        //text_timeSpend.enabled = false;
    }
}
