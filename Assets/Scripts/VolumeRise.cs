using UnityEngine;

public class VolumeRise : MonoBehaviour
{
    public AudioSource audioSource;

    private float volume = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        volume += Time.deltaTime / 90;
        audioSource.volume = volume;
    }
}
