using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text", menuName = "Narrative Text", order = 1)]
public class NarrativeText : ScriptableObject {

	public string title;
	[TextArea]
	public string[] displayedTexts;
}
