using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public Vector2 minBorder;
	public Vector2 maxBorder;

	public bool drawBorder;

	private void OnDrawGizmos()
	{
		if(drawBorder)
		{
			Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
			Gizmos.DrawCube(Vector3.zero, new Vector3(maxBorder.x - minBorder.x, maxBorder.y - minBorder.y, 0.1f));
		}
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(this.gameObject);
		}
	}
}
