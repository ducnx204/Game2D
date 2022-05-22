using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public GameObject prefab;

    public AudioClip coin;
    private AudioSource coinSource;

    public AudioClip die;
    private AudioSource dieSource;

    public AudioClip jump;
    private AudioSource jumpSource;

    public AudioClip theme;
    private AudioSource themeSource;


    private void Awake()
    {
        instance = this;
    }

    public void PlaySound(AudioClip clip, float volume, bool isLoopback)
    {
        if(clip == this.theme)
        {
            Play(clip, ref themeSource, volume, isLoopback);
        }
    }

    public void PlaySound(AudioClip clip, float volume)
    {
        if(clip == this.coin)
        {
            Play(clip, ref coinSource, volume);
            return;
        }
        if (clip == this.die)
        {
            Play(clip, ref dieSource, volume);
            return;
        }
        if (clip == this.jump )
        {
            Play(clip, ref jumpSource, volume);
            return;
        }
        
    }

    private void Play(AudioClip clip, ref AudioSource audioSource, float volume, bool isLoopback = false)
    {
        // nếu đang chơi thì ko thực hiện
        if(audioSource != null && audioSource.isPlaying)
        {
            return;
        }
        // còn nếu chưa có thì tạo instance qua prefab
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();

        audioSource.volume = volume;
        audioSource.loop = isLoopback;
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(audioSource.gameObject, audioSource.clip.length);
    }

    public void StopSound(AudioClip clip)
    {
        // gọi phương thức Stop của coinSource. nếu coinSoure khác none
        if(clip == this.coin)
        {
            coinSource?.Stop(); return;
        }
        if (clip == this.die)
        {
            dieSource?.Stop(); return;
        }
        if (clip == this.jump)
        {
            jumpSource?.Stop(); return;
        }
        if (clip == this.theme)
        {
            themeSource?.Stop(); return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
