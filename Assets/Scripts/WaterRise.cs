using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaterRise : MonoBehaviour
{
    public Image waterTexture;

    void Update()
    {
        
        Color tempColor = waterTexture.color;
        tempColor.a += Time.deltaTime / 90;
        waterTexture.color = tempColor;
    }

}