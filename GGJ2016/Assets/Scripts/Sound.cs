using UnityEngine;
using System.Collections;

public class Sound {
	//Example:
	//Sound sound = new Sound(audio, "Sounds/takeover sfx");
	public AudioSource audio;

    public Sound(AudioSource audio, string file, float volume = 1){
		this.audio = audio;
		AudioClip clip = Resources.Load(file) as AudioClip;
        audio.PlayOneShot(clip, volume);
	}
}