using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private Collider coll;
	private Animator anim;

	//[HideInInspector]
	public bool grounded;

	public float speed;
	[HideInInspector]
	public Vector3 direction;

	public float jumpVelocity;
	public float fallingCoefficient;
	public float smallJumpCoefficient;
	public float airControlCoefficient;

	private float teleportOffset = 0.5f;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		coll = GetComponent<Collider>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
    {
		if (!GameManager.instance.isPaused)
		{
			Move();
			CheckBorders();
		}
	}

	private void Update()
	{
		if (!GameManager.instance.isPaused)
		{
			CheckGround();
			Jump();

			UpdateAnimatorParameters();
		}
	}

	void Move()
	{
		direction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
		Vector3 velocity = direction * speed * Time.deltaTime;
		if(!grounded)
			velocity *= airControlCoefficient;
		rb.MovePosition(transform.position + velocity);

		transform.LookAt(transform.position + direction);
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
		Vector3 leftRayPos = new Vector3(transform.position.x - coll.bounds.extents.x, transform.position.y + 0.1f, transform.position.z);
		Vector3 rightRayPos = new Vector3(transform.position.x + coll.bounds.extents.x, transform.position.y + 0.1f, transform.position.z);

		if (Physics.Raycast(leftRayPos, -Vector3.up, 0.2f) || Physics.Raycast(rightRayPos, -Vector3.up, 0.2f))
			grounded = true;
		else
			grounded = false;
	}

	void UpdateAnimatorParameters()
	{
		anim.SetFloat("Vx", direction.x);
		anim.SetFloat("Vy", rb.velocity.y);
		anim.SetBool("Grounded", grounded);

		if (!Input.GetButton("Jump"))
			anim.SetFloat("JumpSpeed", 1.5f);
		else
			anim.SetFloat("JumpSpeed", 0.6f);

	}
}
