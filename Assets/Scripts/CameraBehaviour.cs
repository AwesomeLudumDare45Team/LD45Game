using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
	public float cameraWidth;
	float cameraHeight;

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	public Image left, right, bottom, top;

	private void OnValidate()
	{
		GetComponent<Camera>().orthographicSize = cameraWidth * 0.28125f;
		cameraHeight = cameraWidth * 0.5625f;
	}

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

		/*smoothedPosition.x = Mathf.Clamp(smoothedPosition.x,
										 GameManager.instance.minBorder.x + cameraWidth / 2,
										 GameManager.instance.maxBorder.x - cameraWidth / 2);
		smoothedPosition.y = Mathf.Clamp(smoothedPosition.y,
										 GameManager.instance.minBorder.y + cameraHeight / 2 + offset.y,
										 GameManager.instance.maxBorder.y - cameraHeight / 2 + offset.y);*/

		if (smoothedPosition.x <= GameManager.instance.minBorder.x + cameraWidth / 2)
		{
			smoothedPosition.x = GameManager.instance.minBorder.x + cameraWidth / 2;
			left.enabled = true;
		}
		else
		{
			left.enabled = false;
		}

		if (smoothedPosition.x >= GameManager.instance.maxBorder.x - cameraWidth / 2)
		{
			smoothedPosition.x = GameManager.instance.maxBorder.x - cameraWidth / 2;
			right.enabled = true;
		}
		else
		{
			right.enabled = false;
		}

		if (smoothedPosition.y <= GameManager.instance.minBorder.y + cameraHeight / 2 + offset.y)
		{
			smoothedPosition.y = GameManager.instance.minBorder.y + cameraHeight / 2 + offset.y;
			bottom.enabled = true;
		}
		else
		{
			bottom.enabled = false;
		}

		if (smoothedPosition.y >= GameManager.instance.maxBorder.y - cameraHeight / 2 + offset.y)
		{
			smoothedPosition.y = GameManager.instance.minBorder.y + cameraHeight / 2 + offset.y;
			top.enabled = true;
		}
		else
		{
			top.enabled = false;
		}


		transform.position = smoothedPosition;

		transform.rotation = Quaternion.LookRotation(-offset);
	}
}
