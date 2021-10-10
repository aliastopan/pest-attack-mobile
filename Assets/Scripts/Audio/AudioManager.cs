using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake() 
    {
        foreach (Sound sound in sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
        }    
    }

    

    public void Play(string name)
    {
        Sound sound  = System.Array.Find(sounds, s => s.Name == name);
        if(sound == null)
        {
            Debug.LogWarning($"Sound of name {name} is not found.");
            return;
        }
        sound.Source.Play();
    
        //FindObjectOfType<AudioManager>().Play(STRING_NAME);
    }

}
