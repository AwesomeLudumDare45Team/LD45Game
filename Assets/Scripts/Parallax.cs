using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public List<Transform> backgrounds;
	private List<float> parallaxScales;
	public float smoothing = 1.0f;

	private Transform cam;
	private Vector3 previousCamPos;

	private void Awake()
	{
		cam = Camera.main.transform;
	}

	// Start is called before the first frame update
	void Start()
    {
		previousCamPos = cam.position;

		parallaxScales = new List<float>();

		for(int i = 0; i < backgrounds.Count; i++)
		{
			parallaxScales.Add(-backgrounds[i].position.z);
		}
		parallaxScales.Reverse();
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < backgrounds.Count; i++)
		{
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
			Debug.Log(i);

			float backgroundTargetPosX = backgrounds[i].position.x - parallax;
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		previousCamPos = cam.position;
    }
}
