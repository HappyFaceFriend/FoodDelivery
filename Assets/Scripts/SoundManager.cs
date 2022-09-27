using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField] AudioSource _bgmSource;
    [SerializeField] AudioSource _sfxSource;

    public AudioClip AttackSound;
    public AudioClip HitSound;
    public AudioClip ClearSound;
    public AudioClip OverSound;
    public AudioClip GemSound;
    public AudioClip AlertSound;
    public AudioClip ButtonSound;

    private void Awake()
    {
        _instance = this;
    }
    public void PlayButtonSound()
    {
        PlaySound(ButtonSound);
    }
    public void PlaySound(AudioClip sound, float volume = 0.5f)
    {
        _sfxSource.PlayOneShot(sound, volume);
    }
}
