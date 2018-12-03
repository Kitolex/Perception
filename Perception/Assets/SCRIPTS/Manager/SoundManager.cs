using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

	public static SoundManager Instance;

	private AudioSource[] audioSources;

	[Header("Parameters")]

	public float minHoverVolume = 0.3f;
	public float maxHoverVolume = 0.4f;

	public float minHoverPitch = 0.8f;
	public float maxHoverPitch = 0.95f;

    public float smoothTimeVolume = 0.3f;
    public float smoothTimePitch = 0.1f;

	[Header("Audio clips")]

	public AudioClip glouglou;
	public AudioClip placardOpen;
	public AudioClip placardClose;
	public AudioClip placardLocked;

	private readonly int hoverSoundIndex = 0;
	private readonly int notSpacializedSoundIndex = 1;
	private float desiredVolume;
	private float desiredPitch;
	private bool hovering;
    private float velocityVolume = 0.0f;
    private float velocityPitch = 0.0f;

	void Awake () {
		if(SoundManager.Instance == null) {
			SoundManager.Instance = this;
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
		}
	}
}
