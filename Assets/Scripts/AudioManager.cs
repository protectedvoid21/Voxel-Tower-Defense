using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance;
    
    public Sound[] sounds;

    private void Awake() {
        instance = this;
        
        foreach(var sound in sounds) {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
    }

    public void Play(string name) {
        Sound sound = Array.Find(sounds, searchedSound => searchedSound.name == name);
        sound?.audioSource.Play();
    }
}