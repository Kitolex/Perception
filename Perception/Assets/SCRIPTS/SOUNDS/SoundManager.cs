using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	private AudioSource[] audioSources;

	public float maxHoverVolume = 0.4f;

	private readonly int hoverSoundIndex = 0;
	private readonly int notSpacializedSoundIndex = 1;
	private float desiredVol;
    private float smoothTime = 0.3f;
    private float velocity = 0.0f;

	void Awake () {
		if(SoundManager.Instance == null) {
			SoundManager.Instance = this;
		}

		this.audioSources = GetComponents<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		this.audioSources[hoverSoundIndex].volume = Mathf.SmoothDamp(this.audioSources[hoverSoundIndex].volume, this.desiredVol, ref this.velocity, this.smoothTime);

		if(this.audioSources[hoverSoundIndex].volume <= 0.0001f) {
			this.audioSources[hoverSoundIndex].volume = 0.0f;
		}
	}

	public void PlayOneTimeNotSpacializedSound (AudioClip audioClip) {
		this.audioSources[notSpacializedSoundIndex].PlayOneShot(audioClip);
	}

	public void PlayHoverSong () {
		this.desiredVol = this.maxHoverVolume;
	}

	public void StopHoverSong () {
		this.desiredVol = 0.0f;
	}
}
