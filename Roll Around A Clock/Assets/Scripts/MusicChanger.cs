using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public string[] keys;
	public AudioClip[] sounds;
	
	public AudioSource backgroundMusic;
	
	int sound;
	
    void Start()
    {
        for (int i = 0; i < keys.Length; i++) {
			int state = PlayerPrefs.GetInt(keys[i]);
			if (state == 1) {
				sound = i;
			}
		}
		
		 backgroundMusic.clip = sounds[sound];
		 backgroundMusic.Play();
		
    }
}
