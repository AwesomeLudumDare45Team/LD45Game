using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyFlock : MonoBehaviour
{
    public GameObject m_prefabButterfly;

    public float m_boundOffsetDeletion;
    public Vector2 m_flockRadiusRange;
    public Vector2 m_depthPositionRange;
    public Vector2Int m_flockSizeRange;

    [HideInInspector]
    public List<Butterfly> m_butterflies = new List<Butterfly>();


    private CameraBehaviour m_camera;
    private Rigidbody m_playerRb;

    [HideInInspector]
    public Vector3 m_flockCenter;
    [HideInInspector]
    public float m_flockRadius;
    [HideInInspector]
    public int m_flockSize;

    private void OnEnable()
    {
        m_camera = GameObject.FindGameObjectWithTag("CameraBase").GetComponent<CameraBehaviour>();
        m_playerRb = GameManager.instance.player.GetComponent<Rigidbody>();
        CreateFlock();
    }

    private void OnDisable()
    {
        ClearFlock();
    }

    void Update()
    {
		if (!GameManager.instance.isPaused)
		{
			if (!m_camera.cameraBoundaries.IsInBoundariesAll(m_flockCenter, m_boundOffsetDeletion))
			{
				for (int i = 0; i < m_butterflies.Count; ++i)
				{
					Destroy(m_butterflies[i].gameObject);
				}
				m_butterflies.Clear();
				gameObject.SetActive(false);
			}
		}
    }

    void CreateFlock()
    {
        ClearFlock();

        m_flockSize = Random.Range(m_flockSizeRange.x, m_flockSizeRange.y);
        m_flockRadius = Random.Range(m_flockRadiusRange.x, m_flockRadiusRange.y);
        m_flockCenter = RandomStartPosition();

        for (int i = 0; i < m_flockSize; ++i)
        {
            CreateButterfly();
        }
    }

    private Vector3 RandomStartPosition()
    {
        Vector3 startPosition;

        startPosition.x = Random.Range(m_camera.cameraBoundaries.m_minPosition.x + m_flockRadius, m_camera.cameraBoundaries.m_maxPosition.x - m_flockRadius);
        startPosition.y = Random.Range(m_camera.cameraBoundaries.m_minPosition.y + m_flockRadius, m_camera.cameraBoundaries.m_maxPosition.y - m_flockRadius);
        startPosition.z = Random.Range(m_camera.transform.position.z + m_depthPositionRange.x, m_camera.transform.position.z + m_depthPositionRange.y); ;

        return startPosition;
    }

    void ClearFlock()
    {
        if (m_butterflies.Count != 0)
        {
            foreach (Butterfly butterfly in m_butterflies)
            {
                if (butterfly != null)
                    Destroy(butterfly.gameObject);
            }
            m_butterflies.Clear();
        }
    }

    void CreateButterfly()
    {
        Vector3 randomOffset = Random.insideUnitSphere * m_flockRadius;

        GameObject go = Instantiate(m_prefabButterfly, m_flockCenter + randomOffset, Quaternion.identity);

        Butterfly butterfly = go.GetComponent<Butterfly>();
        if (butterfly == null)
        {
            Debug.LogError("Error while instantiating a butterfly");
            return;
        }

        butterfly.m_flock = this;
        m_butterflies.Add(butterfly);
    }
}
