using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroFade : MonoBehaviour
{

    public AudioClip introSong;
    public AudioClip ghostNormal;

    public AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();

        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro() {
        source.clip = introSong;
        source.Play();
        yield return new WaitForSeconds(introSong.length);
        source.clip = ghostNormal;
        source.Play();
        source.loop = true;
    }
}
