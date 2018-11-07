using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour {

	[HideInInspector]
	public static SubtitleManager Instance;

	public Text subtitle;
	public Image background;
	public NarrativeText[] narrativesTexts;

	private Dictionary<string, string[]> texts;
	private string[] currentTexts;
	private int currentTextsIndice;

	void Awake () {
		if(SubtitleManager.Instance == null) {
			SubtitleManager.Instance = this;
		}
	}

	// Use this for initialization
	void Start () {

		this.texts = new Dictionary<string, string[]>();

		foreach(NarrativeText nt in narrativesTexts) {
			this.texts[nt.title] = nt.displayedTexts;
		}

		this.startTextsSequence("Text1");
	}

	public void startTextsSequence (string title) {
		this.currentTexts = this.texts[title];
		this.currentTextsIndice = 0;
		this.background.enabled = true;
		this.subtitle.enabled = true;
		StartCoroutine(displayText());
	}

	private IEnumerator displayText () {

		if(this.currentTextsIndice == this.currentTexts.Length) {

			stopTextsSequence();

		} else {

			string text = this.currentTexts[this.currentTextsIndice];

			this.subtitle.text = text;

			this.currentTextsIndice++;

			yield return new WaitForSeconds(estimatedTimeToRead(text));
			StartCoroutine(displayText());
		}
	}

	public void stopTextsSequence () {
		this.background.enabled = false;
		this.subtitle.enabled = false;
	}

	private float estimatedTimeToRead (string text) {

		int wordCount = text.Split(' ').Length;

		return (float)wordCount / 200.0f * 60.0f * 1.2f;
	}
}
