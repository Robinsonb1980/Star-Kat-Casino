using CSFramework;
using UnityEngine;

public class MiniGame : MonoBehaviour {
	public Transform transCards;
	private Card[] cards;
	private Card resultCard;
	private SlotEvent e;

	private void Awake() { gameObject.SetActive(false); }

	public void Activate(SlotEvent _e) {
		e = _e;
		gameObject.SetActive(true);
		cards = transCards.GetComponentsInChildren<Card>();

		foreach (var _c in cards) {
			var c = _c;
			float a = Random.Range(0, 100);
			int value = 0;
			if (a > 90) value = 10;
			else if (a > 70) value = 5;
			else if (a > 40) value = 3;
			else if (a > 10) value = 2;
			else value = 1;
			c.value = value;
			c.textValue.text = "" + value;
			c.button.interactable = true;
			c.button.onClick.AddListener(() => {
				c.imageCover.CrossFadeColor(new Color(1f, 1f, 1f, 0f), 2, true, true);
				resultCard = c;
				_Deactivate();
			});
		}
	}

	public void _Deactivate() {
		foreach (var c in cards) c.button.interactable = false;
		Invoke("Deactivate", 4);
	}

	public void Deactivate() {
		Debug.Log("result card:" + resultCard.name + " value:" + resultCard.value);
		e.Deactivate();
		gameObject.SetActive(false);
	}
}