using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSeeker : MonoBehaviour
{

	public Transform target;

    void Update()
    {
		if (target == null)
			transform.LookAt(transform.position + Vector3.forward);
		else
			transform.LookAt(target);
    }
}
