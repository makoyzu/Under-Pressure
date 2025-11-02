using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackFadeOut : MonoBehaviour
{
    public bool fadeOut = false;
    public Image blackScreen;

    void Start()
    {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut) 
        {
            Color tempColor = blackScreen.color;
            tempColor.a -= Time.deltaTime * 0.25f;
            blackScreen.color = tempColor;
            if (tempColor.a <= 0)
            {
                fadeOut = false;
                Destroy(blackScreen.gameObject);
            }
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        fadeOut = true;
    }
}
