using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    private CameraBehaviour m_camera;
    public Vector2 m_horizontalVariationRange;
    public Vector2 m_depthVariationRange;
    public Vector2 m_sizeFactorVariationRange;
    public float m_maxDistance;
    public float m_growFactor;

    private PlayerController m_player;
    private float m_maxSizeFactor;


    private void OnEnable()
    {
        m_camera = GameObject.FindGameObjectWithTag("CameraBase").GetComponent<CameraBehaviour>();
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        transform.position = RandomStartPosition();
        m_maxSizeFactor = Random.Range(m_sizeFactorVariationRange.x, m_sizeFactorVariationRange.y);
        transform.localScale = Vector3.zero;
    }

    private Vector3 RandomStartPosition()
    {
        Vector3 startPosition = m_player.transform.position;

        float deltaX = Random.Range(m_horizontalVariationRange.x, m_horizontalVariationRange.y);
        if (Random.Range(0.0f, 1.0f) > 0.5)
            deltaX = -deltaX;
        startPosition.x += deltaX;

        float deltaZ = Random.Range(m_depthVariationRange.x, m_depthVariationRange.y);
        if (Random.Range(0.0f, 1.0f) > 0.5f)
            deltaZ = -deltaZ;
        startPosition.z +=  deltaZ;

        return startPosition;
    }

    void Update()
    {
		if (!GameManager.instance.isPaused)
		{
			float distance = Mathf.Abs(m_player.transform.position.x - transform.position.x);
			if (distance > m_maxDistance)
			{
				gameObject.SetActive(false);
				return;
			}
			float distanceFactor = Mathf.Pow((m_maxDistance - distance) / m_maxDistance, 2f);
			float targetSize = m_maxSizeFactor * distanceFactor;

			float deltaScale = targetSize - transform.localScale.magnitude;

			transform.localScale += Vector3.one * deltaScale * m_growFactor * Time.deltaTime;
		}
    }

}
