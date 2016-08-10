using UnityEngine;
using System.Collections;

public class lightbar : MonoBehaviour {

    public GameObject[] leds = new GameObject[12];
    public float timer = 0f;
    public float newR, newG, newB, modeDelayTime;
    public enum mode { RANDOM, FIRE, RAIN, WIND, OFF, ON, CASCADE}
    public mode MyMode;
    // Use this for initialization
	void Start () {
        MyMode = mode.RANDOM;
        modeDelayTime = 1f;
	}

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if(timer > modeDelayTime)
        {
            timer = 0;
			selectState ();
        }

    }

    void selectState()
    {
		if(MyMode == mode.RANDOM)
        {
            randomMode();
        }
		else if (MyMode == mode.FIRE)
        {
            fireMode();
        }
		else if (MyMode == mode.RAIN)
		{
			rainMode(1f);
		}
		else if (MyMode == mode.OFF)
		{
			offMode();
		}
		else if (MyMode == mode.ON)
		{
			onMode();
		}
    }

    void randomMode() {
        modeDelayTime = 1f;
		for(int i = 0; i < leds.Length; i++)
		{
			newR = Random.Range(0f, 1f);
			newG = Random.Range(0f, 1f);
			newB = Random.Range(0f, 1f);
			leds[i].GetComponent<led>().setRGB(newR, newG, newB);
		}
    }

    void fireMode()
    {
        modeDelayTime = .2f;
		for(int i = 0; i < leds.Length; i++)
		{
			newR = Random.Range(0f, 1f);
			newG = Random.Range(0f, newR);
			newB = 0f;
			leds[i].GetComponent<led>().setRGB(newR, newG, newB);
		}
    }

	void offMode()
	{
		modeDelayTime = 1f;
		for(int i = 0; i < leds.Length; i++)
		{
			newR = 0f;
			newG = 0f;
			newB = 0f;
			leds[i].GetComponent<led>().setRGB(newR, newG, newB);
		}
	}

	void onMode()
	{
		modeDelayTime = 1f;
		for(int i = 0; i < leds.Length; i++)
		{
			newR = 1f;
			newG = 1f;
			newB = 1f;
			leds[i].GetComponent<led>().setRGB(newR, newG, newB);
		}
	}

	void windMode(float delayTime)
	{
		modeDelayTime = delayTime;
		StartCoroutine ("wind");
	}

	IEnumerator wind()
	{
		float delayTime = modeDelayTime / leds.Length;
		for (int i = leds.Length; i >= 0; i--) {
			leds [i].GetComponent<led> ().setRGB (0f, 1f, Random.Range(0f, 0.4f));
			yield return new WaitForSeconds (delayTime);
			leds [i].GetComponent<led> ().setRGB (0f, 0f, 0f);
		}
	}


	void rainMode(float delayTime)
	{
		modeDelayTime = delayTime;
		StartCoroutine ("rain");
	}

	IEnumerator rain()
	{
		float delayTime = modeDelayTime / leds.Length;
		for (int i = 0; i < leds.Length; i++) {
			leds [i].GetComponent<led> ().setRGB (0f, 0.2f, 1f);
			yield return new WaitForSeconds (delayTime);
			leds [i].GetComponent<led> ().setRGB (0f, 0f, 0f);
		}
	}
}
