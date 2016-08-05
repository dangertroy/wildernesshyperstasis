using UnityEngine;
using System.Collections;

public class led : MonoBehaviour {

    public float r, g, b;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Renderer>().material.color = new Vector4(r, g, b, 1.0f);
	}

    public void setR(float value)
    {
        r = value;
    }

    public void setG(float value)
    {
        g = value;
    }

    public void setB(float value)
    {
        b = value;
    }

	public void setRGB(float newR, float newG, float newB)
	{
		r = newR;
		g = newG;
		b = newB;
	}

}
