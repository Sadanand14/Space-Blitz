using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // 已经花费的时间
    private Text countdown;
    private float timeSpend;
    private int hour;

    // 显示时间区域的文本
    public Text text_timeSpend;
    public int minute;
    public int second;
    public int millisecond;

    // Use this for initialization
    void Start()
    {
        countdown = GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>();
        timeSpend = 0.0f;
        text_timeSpend = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.text == "GO!")
            timeSpend += Time.deltaTime;

        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;
        millisecond = (int)((timeSpend - (int)timeSpend) * 1000);

        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D3}", minute, second, millisecond);
    }

    public int getMin()
    {
        return minute;
    }

    public int getSec()
    {
        return second;
    }

    public int getMilliSec()
    {
        return millisecond;
    }
}
