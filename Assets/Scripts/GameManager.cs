using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int chainsBroken;

    public float StartTime;
    private float TimeLeft;
    public TextMeshProUGUI TimerText;
    public AudioSource confettiSound;
    public AudioSource[] noiseList;
    public GameObject winScreen;

    private bool won = false;

    void Start()
    {
        chainsBroken = 0;
        TimeLeft = StartTime;
    }

    void Update()
    {
        if (chainsBroken == 5) 
        {
            foreach (AudioSource sound in noiseList) 
            {
                sound.Stop();
            }

            if (!won)
            {
                won = true;
                winScreen.SetActive(true);
                confettiSound.Play();
                Invoke("LoadSuccess", 3);
            }
            
        }

        if (TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            if(TimeLeft > 60)
            {
                FormatToMinSec();
            }
            else
            {
                TimerText.text = Mathf.FloorToInt(TimeLeft).ToString();
            }

        }
        else
        {
            TimerText.text = "0";
            SceneManager.LoadScene("FailEnd");
        }
    }

    void FormatToMinSec()
    {
        float mins = Mathf.FloorToInt(TimeLeft / 60);
        float secs = Mathf.FloorToInt(TimeLeft % 60);

        TimerText.text = string.Format("{0:0}:{1:00}", mins, secs);
    }

    private void LoadSuccess()
    {
        SceneManager.LoadScene("SuccessEnd");
    }
}
