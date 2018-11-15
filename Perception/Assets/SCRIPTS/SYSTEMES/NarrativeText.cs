using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeText : ScriptableObject {

	public string title;
	[TextArea]
	public string[] displayedTexts;
}
