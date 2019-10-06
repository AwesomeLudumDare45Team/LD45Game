using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLifeManager : MonoBehaviour
{
    public static EnvironmentLifeManager m_instance { get; private set; }




    public BirdFlock m_birdFlockPrefab;

    public bool m_birds;
    public bool m_butterflies;
    public bool m_airplanes;
    public bool m_flowers;

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
            return;
        }

        m_instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
