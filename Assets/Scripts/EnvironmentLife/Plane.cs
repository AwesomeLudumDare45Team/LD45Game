using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private CameraBehaviour m_camera;
    public Vector2 m_boundOffset;
    public Vector2 m_depthPositionRange;
    public Vector2 m_horizontalVelocityRange;

    private Rigidbody m_rb;
    private Direction m_direction;
    private float m_horizontalVelocity;

    public LineRenderer m_lineRenderer;
    public float m_trailStartDistance;
    public Vector2 m_trailSizeRange;
    public int m_trailNumberPoints;
    public float m_proportionFlicker;
    public float m_flickerSpeedFactor;
    private float m_trailSize;

    public GameObject m_model;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraBehaviour>();
        m_direction = (Random.Range(0.0f, 1.0f) < 0.5f) ? Direction.LEFT : Direction.RIGHT;

        m_horizontalVelocity = Random.Range(m_horizontalVelocityRange.x, m_horizontalVelocityRange.y);
        
        m_rb.transform.position = RandomStartPosition();
        m_rb.velocity = Vector3.zero;
        m_trailSize = m_trailSizeRange.x + (m_trailSizeRange.y - m_trailSizeRange.x) * (m_horizontalVelocity - m_horizontalVelocityRange.x) / (m_horizontalVelocityRange.y - m_horizontalVelocityRange.x) ;

        m_lineRenderer.positionCount= m_trailNumberPoints;
        if (m_direction == Direction.LEFT) m_horizontalVelocity = -m_horizontalVelocity;
        if (m_direction == Direction.LEFT) m_model.transform.Rotate(Vector3.up, 180);
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

    void Update()
    {
        Vector3 speed = m_horizontalVelocity * Vector3.right;
        m_rb.transform.position += speed * Time.deltaTime;

        UpdateTrail();

        if (!m_camera.cameraBoundaries.IsInBoundaries(m_direction, m_rb.transform.position, (m_trailSize + m_trailStartDistance) * 1.1f))
            gameObject.SetActive(false);  
    }

    private void UpdateTrail()
    {
        float factor = m_trailSize  / (m_trailNumberPoints - 1.0f);
        factor *= (1 + m_proportionFlicker * (Mathf.Abs(Mathf.Sin((Time.time * m_flickerSpeedFactor))) - 1));
        for (int i =0; i< m_lineRenderer.positionCount; ++i)
        {
            float deltaX = m_trailStartDistance + factor * i;
            if (m_direction == Direction.RIGHT) deltaX = -deltaX;
            m_lineRenderer.SetPosition(i, m_rb.transform.position + deltaX*Vector3.right);
        }
    }
}
