using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	public Image imageCover;
	public Text textValue;
	public Button button;
	[NonSerialized] public int value;
}