using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	private AudioSource[] audioSources;

	public float minHoverVolume = 0.3f;
	public float maxHoverVolume = 0.6f;

	public float minHoverPitch = 0.8f;
	public float maxHoverPitch = 1.2f;
	public bool debugVolume;
	public bool debugPitch;
	public bool debugBoth;

	private readonly int hoverSoundIndex = 0;
	private readonly int notSpacializedSoundIndex = 1;
	private float desiredVolume;
	private float desiredPitch;
    private float smoothTime = 0.3f;
    private float velocityVolume = 0.0f;
    private float velocityPitch = 0.0f;

	void Awake () {
		if(SoundManager.Instance == null) {
			SoundManager.Instance = this;
		}

		this.audioSources = GetComponents<AudioSource>();
	}

	// Use this for initialization
	void Start () {
		this.desiredVolume = this.minHoverVolume;
		this.desiredPitch = this.minHoverPitch;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		// this.desiredVolume = debugVolume ? maxHoverVolume : minHoverVolume;
		// this.desiredPitch = debugPitch ? maxHoverPitch : minHoverPitch;

		// if(debugBoth) {
		// 	this.desiredVolume = maxHoverVolume;
		// 	this.desiredPitch = maxHoverPitch;
		// }

		this.audioSources[hoverSoundIndex].volume = Mathf.SmoothDamp(this.audioSources[hoverSoundIndex].volume, this.desiredVolume, ref this.velocityVolume, this.smoothTime);
		this.audioSources[hoverSoundIndex].pitch = Mathf.SmoothDamp(this.audioSources[hoverSoundIndex].pitch, this.desiredPitch, ref this.velocityPitch, this.smoothTime);
		
		if(this.audioSources[hoverSoundIndex].volume <= 0.0001f) {
			this.audioSources[hoverSoundIndex].volume = 0.0f;
		}

		this.desiredVolume = this.minHoverVolume;
		this.desiredPitch = this.minHoverPitch;
	}

	public void PlayOneTimeNotSpacializedSound (AudioClip audioClip) {
		this.audioSources[notSpacializedSoundIndex].PlayOneShot(audioClip);
	}

	public void PlayHoverSong () {
		this.desiredVolume = this.maxHoverVolume;
		this.desiredPitch = this.maxHoverPitch;
	}

	// public void StopHoverSong () {
	// 	this.desiredVolume = this.minHoverVolume;
	// 	this.desiredPitch = this.minHoverPitch;
	// }
}
