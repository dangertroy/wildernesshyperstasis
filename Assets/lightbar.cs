using UnityEngine;
using System.Collections;

public class lightbar : MonoBehaviour {

    public GameObject[] leds = new GameObject[12];
    public float timer = 0f;
    public float newR, newG, newB, modeDelayTime;
    public enum mode { random, fire, off}
    public mode MyMode;
    // Use this for initialization
	void Start () {
        MyMode = mode.random;
        modeDelayTime = 1f;
	}

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if(timer > modeDelayTime)
        {
            timer = 0;
            UpdateLeds();
        }
    }

    void selectState()
    {
        if(MyMode == mode.random)
        {
            randomMode();
        }
        else if (MyMode == mode.fire)
        {
            fireMode();
        }
        else if (MyMode == mode.off)
        {
            offMode();
        }
    }

    void randomMode() {
        modeDelayTime = 1f;
        newR = Random.Range(0f, 1f);
        newG = Random.Range(0f, 1f);
        newB = Random.Range(0f, 1f);
    }

    void fireMode()
    {
        modeDelayTime = .2f;
        newR = Random.Range(0f, 1f);
        newG = Random.Range(0f, newR);
        newB = 0f;
    }

    void offMode()
    {
        modeDelayTime = 1f;
        newR = 0f;
        newG = 0f;
        newB = 0f;
    }

    void UpdateLeds () {
        for(int i = 0; i < leds.Length; i++)
        {
            selectState();
            leds[i].GetComponent<led>().setR(newR);
            leds[i].GetComponent<led>().setG(newG);
            leds[i].GetComponent<led>().setB(newB);
        }

    }
}
