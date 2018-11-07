using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager2 : MonoBehaviour {

	public static SoundManager2 Instance;

	private AudioSource[] audioSources;

	public float minHoverVolume = 0.3f;
	public float maxHoverVolume = 0.4f;

	public float minHoverPitch = 0.8f;
	public float maxHoverPitch = 0.9f;
    public float smoothTimeVolume = 0.7f;
    public float smoothTimePitch = 0.7f;

	private readonly int hoverSoundIndex = 0;
	private readonly int hoverActifSoundIndex = 1;
	private readonly int notSpacializedSoundIndex = 2;
	private float desiredVolume;
	private float desiredPitch;
	private bool hovering;
    private float velocityVolume = 0.0f;
    private float velocityPitch = 0.0f;

	void Awake () {
		if(SoundManager2.Instance == null) {
			SoundManager2.Instance = this;
		}

		this.audioSources = GetComponents<AudioSource>();

		this.hovering = false;
	}

	// Use this for initialization
	void Start () {
		this.desiredVolume = this.minHoverVolume;
		this.desiredPitch = this.minHoverPitch;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		this.audioSources[hoverSoundIndex].volume = Mathf.SmoothDamp(this.audioSources[hoverSoundIndex].volume, this.desiredVolume, ref this.velocityVolume, this.smoothTimeVolume);
		this.audioSources[hoverSoundIndex].pitch = Mathf.SmoothDamp(this.audioSources[hoverSoundIndex].pitch, this.desiredPitch, ref this.velocityPitch, this.smoothTimePitch);
		
		// if(this.audioSources[hoverSoundIndex].volume <= 0.0001f) {
		// 	this.audioSources[hoverSoundIndex].volume = 0.0f;
		// }

		// if(this.audioSources[hoverActifSoundIndex].volume <= 0.0001f) {
		// 	this.audioSources[hoverActifSoundIndex].volume = 0.0f;
		// }
	}

	public void PlayOneTimeNotSpacializedSound (AudioClip audioClip) {
		this.audioSources[notSpacializedSoundIndex].PlayOneShot(audioClip);
	}

	/// <summary>
	/// Call this method when you want to start the hover effect.
	/// </summary>
	public void StartHoverSong () {

		if( ! this.hovering) {
			this.hovering = true;
			this.desiredVolume = this.maxHoverVolume;
			this.desiredPitch = this.maxHoverPitch;
			// this.audioSources[hoverActifSoundIndex].time = this.audioSources[hoverSoundIndex].time;
		}
		
	}

	/// <summary>
	/// Call this method when you want to stop the hover effect.
	/// </summary>
	public void StopHoverSong () {
		if(this.hovering) {
			this.hovering = false;
			this.desiredVolume = this.minHoverVolume;
			this.desiredPitch = this.minHoverPitch;
			// this.audioSources[hoverSoundIndex].time = this.audioSources[hoverActifSoundIndex].time;
		}
	}
}
