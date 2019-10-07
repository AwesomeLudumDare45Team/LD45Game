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
		if (!GameManager.instance.isPaused)
			transform.LookAt(target);
    }
}
