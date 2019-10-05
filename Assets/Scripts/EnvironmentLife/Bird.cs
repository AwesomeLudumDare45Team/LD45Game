using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [HideInInspector]
    public BirdFlock m_flock;

    private Rigidbody m_rb;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 speed = m_flock.m_baseHorizontalVelocity * Vector3.right;
        m_rb.transform.position += speed * Time.deltaTime;
    }
}
