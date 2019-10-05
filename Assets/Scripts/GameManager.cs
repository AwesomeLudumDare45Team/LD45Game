using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

    public Boundaries worldBoundaries;

	public bool drawBorder;

	private void OnDrawGizmos()
	{
		if(drawBorder)
		{
			Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
			Gizmos.DrawCube(Vector3.zero, new Vector3(worldBoundaries.m_maxPosition.x - worldBoundaries.m_minPosition.x, worldBoundaries.m_maxPosition.y - worldBoundaries.m_minPosition.y, 0.1f));
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

    private void Update()
    {
        
    }
}
