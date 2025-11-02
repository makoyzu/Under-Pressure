using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PanicLevel : MonoBehaviour
{
    float Panic;

    public Image potraitImage;
    public IconChange neutralIcon;
    public IconChange panicIcon;
    public IconChange hystericalIcon;
    public IconChange flickerIcon;
    public AudioSource heartbeatPlayer;
    public AudioClip heartbeat;
    public AudioClip fasterHeartbeat;
    public AudioClip panicHeartbeat;

    private IconChange currentFrame;

    public void AddPanic()
    {
        Panic += 5;
        Debug.Log("Panic:" + Panic);

    }

    private void Start()
    {
        currentFrame = neutralIcon;
        StartCoroutine(IconFrame());
    }
    private void Update()
    {
        if (Panic < 30)
        {
            currentFrame = neutralIcon;
            heartbeatPlayer.clip = heartbeat;
            heartbeatPlayer.volume = 0.3f;
        }

        if (Panic > 30 && Panic < 70)
        {
            currentFrame = panicIcon;
            heartbeatPlayer.clip = heartbeat;
            heartbeatPlayer.volume = 1;
        }
        if (Panic > 70 && Panic < 90)
        {
            currentFrame = hystericalIcon;
            heartbeatPlayer.clip = fasterHeartbeat;
        }

        if (Panic > 90 && Panic <= 100)
        {
            currentFrame = flickerIcon;
            heartbeatPlayer.clip = panicHeartbeat;
        }

        if (Panic >= 100)
        {
            SceneManager.LoadScene("FailEnd");
        }

        if (!heartbeatPlayer.isPlaying)
        {
            heartbeatPlayer.Play();
        }

        Panic -= Time.deltaTime * 5;

        if (Panic <= 0)
        {
            Panic = 0;
        }
    }

    private IEnumerator IconFrame()
    {
        while (true)
        {
            potraitImage.sprite = currentFrame.one;
            yield return new WaitForSeconds(0.2f);
            potraitImage.sprite = currentFrame.two;
            yield return new WaitForSeconds(0.2f);
            potraitImage.sprite = currentFrame.three;
            yield return new WaitForSeconds(0.2f);
            potraitImage.sprite = currentFrame.four;
            yield return new WaitForSeconds(0.2f);
        }
    }
}