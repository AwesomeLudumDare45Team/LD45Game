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
        if (GameManager.instance == null)
        {
            Debug.LogError("Missing Game Manager");
            return;
        }

        Boundaries worldBoundaries = GameManager.instance.worldBoundaries;
        transform.position = worldBoundaries.WrapPositionAll(transform.position, teleportOffset);
	}
}
