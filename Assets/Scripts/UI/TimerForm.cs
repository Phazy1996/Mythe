using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerForm : MonoBehaviour
{
    [SerializeField]
    Image Timer;
    [SerializeField]
    Sprite daySprite;
    [SerializeField]
    Sprite nightSprite;

    [SerializeField]
    private float maxTime = 15f;
    [SerializeField]
    private float currentTime = 0;

    string[] DayLevels = { "FerryScene", "SebastiaanScene" };
    string[] NightLevels = { "PhineasScene", "JochemScene" };

    private bool _runOnce = false;


    public PlayerTransformation _checkMode;


    // Use this for initialization
    void Start()
    {
        if (CheckLevel(NightLevels))
        {
            GetComponent<Image>().sprite = nightSprite;
        }
        else if (CheckLevel(DayLevels))
        {
            GetComponent<Image>().sprite = daySprite;
        }
        else {
            gameObject.SetActive(false);
        }
        currentTime = maxTime;


        ///////
      //  
        //////
    }

    void DecreaseTime()
    {
        currentTime -= 0.5f;
        float calcTime = currentTime / maxTime;
        SetTime(calcTime);
        if(currentTime <= 0f)
        {
            currentTime = maxTime;
        }
    }

    void SetTime(float timeLeft)
    {
        Timer.fillAmount = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_runOnce)
        {
            StartCoroutine("InvokeThis");
            _runOnce = true;
        }
        
    }

    private IEnumerator InvokeThis()
    {
        InvokeRepeating("DecreaseTime", 0f, 0.5f);
        yield return new WaitForSeconds(15);
        _runOnce = false;
    }

    private bool CheckLevel(string[] _stringLevels) {
        

        for (int i = 0; i < _stringLevels.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == _stringLevels[i])
            {
                return true;
            }
        }
        return false;
    }
}
