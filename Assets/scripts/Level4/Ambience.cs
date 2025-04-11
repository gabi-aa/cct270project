using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = 0f;
        StartCoroutine(Fade(true, source, 2f, 0.6f));
        StartCoroutine(waiter());
        StartCoroutine(Fade(false, source, 2f, 0f));
    }

    private void Update()
    {
        if (!source.isPlaying)
        {
            source.Play();
            StartCoroutine(Fade(true, source, 2f, 0.2f));
//            StartCoroutine(waiter());
            StartCoroutine(Fade(false, source, 2f, 0f));
        }
    }

    public IEnumerator Fade(bool fadein, AudioSource source, float duration, float targetVol)
    {
        int wait_time = Random.Range(40, 360);

        if (!fadein)
        {
            double sourceLength = (double)source.clip.samples / source.clip.frequency;
            yield return new WaitForSecondsRealtime((float)sourceLength - duration);
        }

        float time = 0f;
        float startVol = source.volume;
        while(time < duration)
        {
            //string situation = fadein ? "fadein" : "fadeout";
            //Debug.Log(situation);
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(startVol, targetVol, time / duration);
            yield return null;
        }
        yield return new WaitForSeconds(wait_time);
    }

    public IEnumerator waiter()
    {
        int wait_time = Random.Range(5, 30);
        yield return new WaitForSeconds(wait_time);
    }

}
