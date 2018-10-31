using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	private AudioSource[] audioSources;

	public float minHoverVolume = 0.3f;
	public float maxHoverVolume = 0.6f;

	private readonly int hoverInactifSoundIndex = 0;
	private readonly int hoverActifSoundIndex = 1;
	private readonly int notSpacializedSoundIndex = 2;
	private float desiredVolumeActif;
	private float desiredVolumeInactif;
	private bool hovering;
    private float smoothTime = 0.3f;
    private float velocityVolumeActif = 0.0f;
    private float velocityVolumeInactif = 0.0f;

	void Awake () {
		if(SoundManager.Instance == null) {
			SoundManager.Instance = this;
		}

		this.audioSources = GetComponents<AudioSource>();

		this.hovering = false;
	}

	// Use this for initialization
	void Start () {
		this.desiredVolumeActif = 0.0f;
		this.desiredVolumeInactif = this.minHoverVolume;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		this.audioSources[hoverInactifSoundIndex].volume = Mathf.SmoothDamp(this.audioSources[hoverInactifSoundIndex].volume, this.desiredVolumeInactif, ref this.velocityVolumeInactif, this.smoothTime);
		this.audioSources[hoverActifSoundIndex].volume = Mathf.SmoothDamp(this.audioSources[hoverActifSoundIndex].volume, this.desiredVolumeActif, ref this.velocityVolumeActif, this.smoothTime);
		
		if(this.audioSources[hoverInactifSoundIndex].volume <= 0.0001f) {
			this.audioSources[hoverInactifSoundIndex].volume = 0.0f;
		}

		if(this.audioSources[hoverActifSoundIndex].volume <= 0.0001f) {
			this.audioSources[hoverActifSoundIndex].volume = 0.0f;
		}
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
			this.desiredVolumeActif = this.maxHoverVolume;
			this.desiredVolumeInactif = 0.0f;
			this.audioSources[hoverActifSoundIndex].time = this.audioSources[hoverInactifSoundIndex].time;
		}
		
	}

	/// <summary>
	/// Call this method when you want to stop the hover effect.
	/// </summary>
	public void StopHoverSong () {
		if(this.hovering) {
			this.hovering = false;
			this.desiredVolumeActif = 0.0f;
			this.desiredVolumeInactif = this.minHoverVolume;
			this.audioSources[hoverInactifSoundIndex].time = this.audioSources[hoverActifSoundIndex].time;
		}
	}
}
