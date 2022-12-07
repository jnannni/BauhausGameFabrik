using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] dreamWorldNPCSounds;
    public Sound[] soundEffects;
    
    private void Awake()
    {
        
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            //sound.source.loop = sound.loop;
        }
        foreach (Sound sound in dreamWorldNPCSounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            //sound.source.loop = sound.loop;
        }
    }

    private void Start()
    {
        StartCoroutine(PlaySound());
        UnityEngine.Random.seed = (int)System.DateTime.Now.Ticks;
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            Play("WakingWorld_Background");
        } else if (SceneManager.GetActiveScene().name == "DreamWorld")
        {
            Play("DreamWorld_Background");
        }
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(10f, 20f));

        int randomClipIndex = UnityEngine.Random.Range(0, soundEffects.Length);
        Sound s = soundEffects[randomClipIndex];

        yield return new WaitForSeconds(s.audioClip.length);
        StartCoroutine(PlaySound());
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayNPCVoice()
    {
        int random = UnityEngine.Random.Range(0, dreamWorldNPCSounds.Length);        
        Sound s = dreamWorldNPCSounds[random];
        s.source.Play();
    }
}
