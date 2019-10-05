using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
	[HideInInspector]
	public Camera cam;

	public float cameraWidth;
	float cameraHeight;

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 cameraPositionOffset;

	public Image left, right, bottom, top;
    public float epsilonDisplay = 0.5f;

    [HideInInspector]
    public Boundaries cameraBoundaries;

	private void Start()
	{
		cam = transform.Find("Camera").GetComponent<Camera>();
		cam.transform.position = cameraPositionOffset;
		cam.transform.rotation = Quaternion.LookRotation(-this.cameraPositionOffset);
	}

	private void OnValidate()
	{
		transform.Find("Camera").GetComponent<Camera>().orthographicSize = cameraWidth * 0.28125f;
		cameraHeight = cameraWidth * 0.5625f;
	}

	void FixedUpdate()
	{
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothSpeed);

        if (GameManager.instance == null)
        {
            Debug.LogError("Missing Game Manager");
            return;
        }
        Boundaries worldBoundaries = GameManager.instance.worldBoundaries;

        Vector2 cameraSizeOffset = new Vector2(cameraWidth / 2, cameraHeight / 2);

        left.enabled = worldBoundaries.DistanceToBoundary(Direction.LEFT, smoothedPosition, cameraSizeOffset) < epsilonDisplay;
        right.enabled = worldBoundaries.DistanceToBoundary(Direction.RIGHT, smoothedPosition, cameraSizeOffset) < epsilonDisplay;
        bottom.enabled = worldBoundaries.DistanceToBoundary(Direction.DOWN, smoothedPosition, cameraSizeOffset) < epsilonDisplay;
        top.enabled = worldBoundaries.DistanceToBoundary(Direction.UP, smoothedPosition, cameraSizeOffset) < epsilonDisplay;
        smoothedPosition = worldBoundaries.BoundPositionAll(smoothedPosition, cameraSizeOffset);

        transform.position = smoothedPosition;
	}
}
