using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class TimeUp : MonoBehaviour
{
    public float timeValue = 120;
    private float timerButton = 10;
    private bool startTimerButton = false;
    public Button delayButton;
    public AudioSource layer1;
    public AudioSource layer2;
    public AudioSource layer3;
    public AudioSource layer4;
    public AudioSource layer5;
    public AudioSource layer6;
    public AudioSource layer7;
    public AudioMixer audioMixer;
    public string exposedParameter;
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CountTime();
        DisplayTime(timeValue);
        if (startTimerButton) {
            ReactivateButton();
        }
    }

    void CountTime() {
        /*if (timeValue < 100)
        {
            StartCoroutine(FadeMixerGroup.StartFade(audioMixer, exposedParameter, 3f, 1f));
        }*/
        layer2.volume = timeValue < 100 ? 1 : 0; 
        layer3.volume = timeValue < 80 ? 1 : 0; 
        layer4.volume = timeValue < 60 ? 1 : 0; 
        layer5.volume = timeValue < 40 ? 1 : 0; 
        layer6.volume = timeValue < 20 ? 1 : 0; 
        layer7.volume = timeValue < 10 ? 1 : 0; 

        timeValue = timeValue > 0 ? timeValue -= Time.deltaTime : 0;
    }

    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
            GameOver();
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }

    public void AddSeconds()
    {
        startTimerButton = true;
        timeValue += 10;
    }

    void ReactivateButton() {
        timerButton = timerButton > 0 ? timerButton -= Time.deltaTime : 0;
        
        if (timerButton < 0)
        {
            startTimerButton = false;
            delayButton.interactable = true;
            timerButton = 10;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
