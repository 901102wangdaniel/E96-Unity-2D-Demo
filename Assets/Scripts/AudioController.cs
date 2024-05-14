using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public AudioSource sfxSource;


    public AudioClip background;
    public AudioClip menuClick;

    void Start() {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        sfxSource.PlayOneShot(clip);
    }
}
