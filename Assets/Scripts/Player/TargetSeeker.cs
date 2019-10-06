using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{
	public Transform target;

	[HideInInspector]
	public GameObject arrow;

	private void Awake()
	{
		arrow = transform.GetChild(0).gameObject;
	}

	void Update()
    {
		float angle = Vector3.Angle(Vector3.up, target.position - transform.position);

		transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
    }

	bool IsLeft(Vector3 A, Vector3 B)
	{
		return -A.x * B.y + A.y * B.x < 0.0f;
	}
}
