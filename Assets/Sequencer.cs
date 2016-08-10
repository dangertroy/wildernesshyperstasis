using UnityEngine;
using System.Collections;

public class Sequencer : MonoBehaviour {

	public GameObject[] lightbars = new GameObject[40];
	public lightbar.mode newMode;
	bool cascadeToggle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateBars ();
	}

	void UpdateBars() {
		if (newMode == lightbar.mode.FIRE) {
			FireMode ();
		}
		else if (newMode == lightbar.mode.RAIN) {
			RainMode ();
		}
		else if (newMode == lightbar.mode.RANDOM) {
			RandomMode ();
		}
		else if (newMode == lightbar.mode.OFF) {
			OffMode ();
		}
		else if (newMode == lightbar.mode.ON) {
			OnMode ();
		}
		else if (newMode == lightbar.mode.CASCADE) {
			CascadeMode ();
		}
		else if (newMode == lightbar.mode.WIND) {
			WindMode ();
		}
	}

	void FireMode () {
		foreach (GameObject lb in lightbars) {
			lb.GetComponent<lightbar> ().MyMode = lightbar.mode.FIRE;
		}
	}

	void RainMode () {
		foreach (GameObject lb in lightbars) {
			lb.GetComponent<lightbar> ().MyMode = lightbar.mode.RAIN;
		}
	}

	void WindMode () {
		foreach (GameObject lb in lightbars) {
			lb.GetComponent<lightbar> ().MyMode = lightbar.mode.WIND;
		}
	}


	void OffMode () {
		foreach (GameObject lb in lightbars) {
			lb.GetComponent<lightbar> ().MyMode = lightbar.mode.OFF;
		}
	}

	void OnMode () {
		foreach (GameObject lb in lightbars) {
			lb.GetComponent<lightbar> ().MyMode = lightbar.mode.ON;
		}
	}

	void RandomMode () {
		foreach (GameObject lb in lightbars) {
			lb.GetComponent<lightbar> ().MyMode = lightbar.mode.RANDOM;
		}
	}

	void RainMode2()
	{
		StartCoroutine ("rain");
	}

	IEnumerator rain()
	{
		for (int i = 0; i < lightbars.Length; i++) {
			lightbars[i].GetComponent<lightbar> ().MyMode = lightbar.mode.RAIN;
			yield return new WaitForSeconds (1f);
			lightbars[i].GetComponent<lightbar> ().MyMode = lightbar.mode.OFF;
		}
	}

	void CascadeMode () {
		foreach (GameObject lb in lightbars) {
			if (cascadeToggle) {
				lb.GetComponent<lightbar> ().MyMode = lightbar.mode.ON;
			} else {
				lb.GetComponent<lightbar> ().MyMode = lightbar.mode.OFF;
			}
			cascadeToggle = !cascadeToggle;
		}
	}

}
