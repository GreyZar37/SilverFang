using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioSource SFX, Music;
    public static float sfxVolume = 1f, MusicVolume = .7f;


    // Start is called before the first frame update
    void Start()
    {
        SFX = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
        Music = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        SFX.volume = sfxVolume;
        Music.volume = MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(AudioClip clipToPlay, float volume)
    {
        SFX.PlayOneShot(clipToPlay, volume);
    }

   
}
