using UnityEngine;
using System.Collections;

public class pole : MonoBehaviour {

    public GameObject[] bars = new GameObject[4];
    public lightbar.mode newMode;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateBars();
	
	}

    void UpdateBars()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            bars[i].GetComponent<lightbar>().MyMode = newMode;
        }
    }
}
