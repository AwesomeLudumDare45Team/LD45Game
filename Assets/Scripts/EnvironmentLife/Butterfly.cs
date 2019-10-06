using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public GameObject m_model;
    public Vector2 m_sizeFactorVariationRange;
    public Vector2 m_impulseFactorRange;
    public Vector2 m_impulseTimerRange;
    public float m_gravityFactor;

    [HideInInspector]
    public ButterflyFlock m_flock;

    private Rigidbody m_rb;
    private float m_impulseTimer;

    private bool m_flip;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_model.transform.localScale *= Random.Range(m_sizeFactorVariationRange.x, m_sizeFactorVariationRange.y);
        m_impulseTimer = Random.Range(m_impulseTimerRange.x, m_impulseTimerRange.y);
        m_flip = false;
    }

    void Update()
    {
        m_impulseTimer -= Time.deltaTime;

        Vector3 toCenter = m_flock.m_flockCenter - m_rb.position;
        toCenter.z = 0;

        if(m_impulseTimer < 0 || toCenter.magnitude > m_flock.m_flockRadius) {
            float impulseFactor = Random.Range(m_impulseFactorRange.x, m_impulseFactorRange.y);
            Vector3 impulse = Random.onUnitSphere;
            impulse.z = 0;

            if(toCenter.y<0)
                impulse.y = Mathf.Abs(impulse.y);

            
            impulse *= impulseFactor;

            if (toCenter.magnitude > m_flock.m_flockRadius && Vector3.Dot(impulse.normalized, toCenter.normalized) < 0.5)
                impulse = impulseFactor * toCenter.normalized;

            if (impulse.y <0)
                impulse.y /= 2;

            m_rb.AddForce( impulse, ForceMode.Impulse );

            m_impulseTimer = Random.Range(m_impulseTimerRange.x, m_impulseTimerRange.y);

            if (m_flip != (m_rb.velocity.x > 0))
                m_rb.transform.Rotate(Vector3.up, 180);

        }

        m_rb.AddForce(m_gravityFactor*Vector3.down, ForceMode.Acceleration);
    }
}
