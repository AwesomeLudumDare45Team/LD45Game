using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject m_model;
    public Vector2 m_sizeFactorVariationRange;
    public Vector2 m_fallDistanceRange;
    public Vector2 m_impulseFactorRange;

    [HideInInspector]
    public BirdFlock m_flock;

    private Rigidbody m_rb;
    private float m_fallDistance;
    private Vector3 m_basePosition;
    private bool m_impulse;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();

        if (m_flock.m_direction == Direction.LEFT) m_model.transform.Rotate(Vector3.up, 180);
        m_model.transform.localScale *= Random.Range(m_sizeFactorVariationRange.x, m_sizeFactorVariationRange.y);

        m_basePosition = m_rb.transform.position;
        m_fallDistance = Random.Range(m_fallDistanceRange.x, m_fallDistanceRange.y);
        m_impulse = false;
    }

    void Update()
    {
        m_rb.AddForce(m_flock.m_baseHorizontalVelocity * Vector3.right, ForceMode.Force);

        if (m_impulse)
        {
            if (m_rb.velocity.y < 0 || m_rb.transform.position.y > (m_basePosition.y - m_fallDistance))
                m_impulse = false;
        }
        else if ( m_rb.transform.position.y < (m_basePosition.y-m_fallDistance))
        {
            m_impulse = true;
            float impulseFactor = Random.Range(m_impulseFactorRange.x, m_impulseFactorRange.y);
            m_rb.AddForce(impulseFactor * Vector3.up, ForceMode.Impulse);
            m_fallDistance = Random.Range(m_fallDistanceRange.x, m_fallDistanceRange.y);
        }


    }
}
