using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager m_instance { get; private set; }

    public GameObject m_wallUp;
    public GameObject m_wallDown;
    public GameObject m_wallRight;
    public GameObject m_wallLeft;


    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
            return;
        }

        m_instance = this;
    }
}
