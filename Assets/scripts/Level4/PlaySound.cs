using JetBrains.Annotations;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play(float vol = 1f)
    {
        if(vol == 0f) { source.volume = 1f; }
        else { source.volume = vol; }
        
        source.Play();
    }
}
