using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlock : MonoBehaviour
{
    public GameObject m_prefabBird;

    public Vector2 m_boundOffset;
    public Vector2 m_depthPositionRange;
    public Vector2 m_baseHorizontalVelocityRange;
    public Vector2Int m_flockSizeRange;

    [HideInInspector]
    public List<Bird> m_birds = new List<Bird>();

    private CameraBehaviour m_camera;

    [HideInInspector]
    public Direction m_direction;
    [HideInInspector]
    public float m_baseHorizontalVelocity;
    [HideInInspector]
    public int m_flockSize;

    private void OnEnable()
    {
        m_camera = GameObject.FindGameObjectWithTag("CameraBase").GetComponent<CameraBehaviour>();
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
			List<Bird> toRemove = new List<Bird>();

			bool stillAlive = false;
			foreach (Bird bird in m_birds)
			{
				if (bird != null)
				{
					if (!m_camera.cameraBoundaries.IsInBoundaries(m_direction, bird.transform.position, m_boundOffset))
					{
						Destroy(bird.gameObject);
					}
					else
					{
						stillAlive = true;
					}
				}
			}

			if (!stillAlive)
			{
				gameObject.SetActive(false);
			}
		}
    }


    void CreateFlock()
    {
        ClearFlock();

        m_flockSize = Random.Range(m_flockSizeRange.x, m_flockSizeRange.y);
        m_direction = (Random.Range(0.0f, 1.0f) < 0.5f) ? Direction.LEFT : Direction.RIGHT;

        m_baseHorizontalVelocity = Random.Range(m_baseHorizontalVelocityRange.x, m_baseHorizontalVelocityRange.y);
        if (m_direction == Direction.LEFT) m_baseHorizontalVelocity = -m_baseHorizontalVelocity;

        Vector3 randomBasePosition = RandomStartPosition();

        for (int i = 0; i < m_flockSize; ++i)
        {
            CreateBird(randomBasePosition);
        }
    }

    private Vector3 RandomStartPosition()
    {
        Vector3 startPosition;

        float deltaX = m_camera.cameraWidth / 2 + m_boundOffset.x;
        if (m_direction == Direction.RIGHT) deltaX = -deltaX;
        startPosition.x = m_camera.transform.position.x + deltaX;

        startPosition.y = Random.Range(m_camera.cameraBoundaries.m_minPosition.y - m_boundOffset.y, m_camera.cameraBoundaries.m_maxPosition.y + m_boundOffset.y);
        startPosition.z = Random.Range(m_camera.transform.position.z + m_depthPositionRange.x, m_camera.transform.position.z + m_depthPositionRange.y); ;

        return startPosition;
    }

    void ClearFlock()
    {
        if (m_birds.Count != 0)
        {
            foreach (Bird bird in m_birds)
            {
                if(bird != null)
                    Destroy(bird.gameObject);
            }
            m_birds.Clear();
        }
    }

    void CreateBird(in Vector3 _basePosition)
    {
        Vector3 smallRandomOffset = Vector3.right * Random.Range(-Mathf.Abs(m_boundOffset.y), Mathf.Abs(m_boundOffset.y));

        GameObject go = Instantiate(m_prefabBird, _basePosition + smallRandomOffset, Quaternion.identity);

        Bird bird = go.GetComponent<Bird>();
        if (bird == null)
        {
            Debug.LogError("Error while instantiating a bird");
            return;
        }

        bird.m_flock = this;
        m_birds.Add(bird);
    }
}
