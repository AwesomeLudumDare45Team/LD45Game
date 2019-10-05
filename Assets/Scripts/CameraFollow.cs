using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public float cameraWidth;
	float cameraHeight;

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	private void OnValidate()
	{
		GetComponent<Camera>().orthographicSize = cameraWidth * 0.28125f;
		cameraHeight = cameraWidth * 0.5625f;
	}

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

		smoothedPosition.x = Mathf.Clamp(smoothedPosition.x,
										 GameManager.instance.minBorder.x + cameraWidth / 2,
										 GameManager.instance.maxBorder.x - cameraWidth / 2);
		smoothedPosition.y = Mathf.Clamp(smoothedPosition.y,
										 GameManager.instance.minBorder.y + cameraHeight / 2 + offset.y,
										 GameManager.instance.maxBorder.y - cameraHeight / 2 + offset.y);

		transform.position = smoothedPosition;

		transform.rotation = Quaternion.LookRotation(-offset);
	}
}
