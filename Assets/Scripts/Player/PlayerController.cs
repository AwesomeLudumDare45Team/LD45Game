using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private float distToGround;

	//[HideInInspector]
	public bool grounded;

	public float speed;
	[HideInInspector]
	public Vector3 direction;

	public float jumpVelocity;
	public float fallingCoefficient;
	public float smallJumpCoefficient;
	public float airControlCoefficient;

	private float teleportOffset = 0.1f;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		distToGround = GetComponent<Collider>().bounds.extents.y;
	}

	void FixedUpdate()
    {
		Move();
		CheckBorders();
	}

	private void Update()
	{
		CheckGround();
		Jump();
	}

	void Move()
	{
		direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
		Vector3 velocity = direction * speed * Time.deltaTime;
		if(!grounded)
			velocity *= airControlCoefficient;
		rb.MovePosition(transform.position + velocity);
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

	void Jump()
	{
		if (Input.GetButtonDown("Jump") && grounded)
		{
			rb.velocity = Vector2.up * jumpVelocity;
		}

		if (rb.velocity.y < 0)
			rb.velocity += Vector3.up * Physics.gravity.y * (fallingCoefficient - 1) * Time.deltaTime;
		else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
			rb.velocity += Vector3.up * Physics.gravity.y * (smallJumpCoefficient - 1) * Time.deltaTime;
	}

	void CheckGround()
	{
		if (Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
			grounded = true;
		else
			grounded = false;
	}
}
