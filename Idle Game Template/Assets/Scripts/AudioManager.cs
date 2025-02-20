using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AustenKinney.Essentials;

public class AudioManager : Singleton<AudioManager>
{
    private List<AudioSource> audioSources = new List<AudioSource>();

    [SerializeField] private AudioSource musicSource;

    public void PlaySFX(AudioClip clip)
    {
        bool availableSource = false;

        for(int i = 0; i < audioSources.Count; i++)
        {
            if(audioSources[i].isVirtual)
            {
                audioSources[i].PlayOneShot(clip);
                availableSource = true;
                break;
            }
        }

        if(availableSource == false)
        {
            GameObject newObject = new GameObject("Audio Source");
            newObject.transform.parent = this.transform;
            AudioSource newSource = newObject.AddComponent<AudioSource>();
            newSource.PlayOneShot(clip);
            audioSources.Add(newSource);
        }
    }
}
