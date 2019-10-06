using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject m_model;
    public Vector2 m_sizeFactorVariationRange;

    [HideInInspector]
    public BirdFlock m_flock;

    private Rigidbody m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();

        if (m_flock.m_direction == Direction.LEFT) m_model.transform.Rotate(Vector3.up, 180);
        m_model.transform.localScale *= Random.Range(m_sizeFactorVariationRange.x, m_sizeFactorVariationRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = m_flock.m_baseHorizontalVelocity * Vector3.right;
        m_rb.transform.position += speed * Time.deltaTime;
    }
}
