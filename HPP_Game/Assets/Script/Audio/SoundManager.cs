using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    Dictionary<string, AudioClip> sounds = new Dictionary<string, AudioClip>();

    List<AudioSource> currentSound = new();

    private void Awake()
    {
        Instance = this;

        var loadedSound = Resources.LoadAll<AudioClip>("AudioSources");
        foreach (var sound in loadedSound)
        {
            sounds.Add(sound.name, sound);
        }
    }

    public void PlaySound(GameObject subject, string soundName, bool loop )
    {
        AudioSource[] source = subject.GetComponents<AudioSource>();
        AudioSource availableSource = null;
        
        foreach (var sound in source)
        {
            if (sound.isPlaying)
            {
                availableSource = sound;
                break;
            }
        }

        if(availableSource == null) availableSource = subject.AddComponent<AudioSource>();

        availableSource.clip = sounds[soundName];
        availableSource.loop = loop;
        availableSource.Play();

        currentSound.Add(availableSource);
    }

    public void StopSound(GameObject subject, string soundName)
    {
        currentSound.Find(sound => sound.name == soundName).Stop();
    }
    public void StopAllSounds()
    {
        while(currentSound.Count > 0)
        {
            currentSound[0].Stop();
            currentSound.RemoveAt(0);
        }
    }


    void Start()
    {
/*        PlaySound(GameObject.Find("Player"), "TaserGun", false);*/
    }

    void Update()
    {
        int i = 0;
        while(i < currentSound.Count)
        {
            var source = currentSound[i];
            if(!source.isPlaying)
            {
                print("REMOVE!");
                currentSound.RemoveAt(i);
                continue;
            }
            i++;
        }
    }
}
