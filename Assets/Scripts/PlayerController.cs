using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;

	public float speed;
	[HideInInspector]
	public Vector3 direction;

	private float teleportOffset = 0.1f;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
    {
		//temporary movement for tests
		direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
		Vector3 velocity = direction * speed * Time.deltaTime;
		rb.MovePosition(transform.position + velocity);

		CheckBorders();
	}

	void CheckBorders()
	{
		if (transform.position.x < GameManager.instance.minBorder.x)
		{
			Vector3 newPos = transform.position;
			newPos.x = GameManager.instance.maxBorder.x - teleportOffset;
			transform.position = newPos;
		}
		if (transform.position.x > GameManager.instance.maxBorder.x)
		{
			Vector3 newPos = transform.position;
			newPos.x = GameManager.instance.minBorder.x + teleportOffset;
			transform.position = newPos;
		}
		if (transform.position.y < GameManager.instance.minBorder.y)
		{
			Vector3 newPos = transform.position;
			newPos.y = GameManager.instance.maxBorder.y - teleportOffset;
			transform.position = newPos;
		}
		if (transform.position.y > GameManager.instance.maxBorder.y)
		{
			Vector3 newPos = transform.position;
			newPos.y = GameManager.instance.minBorder.y + teleportOffset;
			transform.position = newPos;
		}

	}
}
