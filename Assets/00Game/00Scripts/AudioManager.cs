using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip------")]
    public AudioClip backGround;
    public AudioClip playerAttack;
    public AudioClip playerJump;
    public AudioClip playerSlide;
    public AudioClip playerDefend;
    private void Start()
    {
        musicSource.clip = backGround;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
