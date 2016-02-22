using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerForm : MonoBehaviour
{

    public Image Timer;
    public float maxTime = 30f;
    public float currentTime = 0;

    // Use this for initialization
    void Start()
    {
        currentTime = maxTime;
        InvokeRepeating("decreaseTime", 0f, 0.5f);
    }

    void decreaseTime()
    {
        currentTime -= 1f;
        float calcTime = currentTime / maxTime;
        SetHealth(calcTime);
    }

    void SetHealth(float timeLeft)
    {
        Timer.fillAmount = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
