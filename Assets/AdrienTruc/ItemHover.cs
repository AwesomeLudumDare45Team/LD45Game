using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HoverMode {turn, oscillate};

public class ItemHover : MonoBehaviour
{
	public HoverMode mode;

	//for oscillation
	private float angleMod = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!GameManager.instance.isPaused)
		{
			transform.position += new Vector3(0, Mathf.Cos(Time.time) * 0.005f, 0);
			if (mode == HoverMode.turn)
			{
				transform.localEulerAngles += new Vector3(0, 1, 0);
			}
			else if (mode == HoverMode.oscillate)
			{
				transform.localEulerAngles += new Vector3(0, angleMod, 0);
				if (transform.localEulerAngles.y <= -30.0f || transform.localEulerAngles.y >= 30.0f)
					angleMod *= -1;
			}
		}
    }
}
