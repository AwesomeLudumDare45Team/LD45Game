using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    private static WorldManager m_instance;

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

    public static WorldManager GetWorldManager(){
        return m_instance;
    }
}
