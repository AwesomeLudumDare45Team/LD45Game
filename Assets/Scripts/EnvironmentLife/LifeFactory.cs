using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeFactory : MonoBehaviour
{
    public GameObject m_lifePrefab;
    public int m_poolSize;
    public Vector2 m_timeToRespawn;

    protected bool m_productionEnabled;
    protected List<GameObject> m_poolInstantiated = new List<GameObject>();
    protected List<GameObject> m_poolActivated = new List<GameObject>();
    protected float m_productionTimer;

    void Start()
    {
        Init();
    }
    void Stop()
    {
        ClearPools();
    }

    protected virtual void Init()
    {
        m_productionEnabled = false;
        m_lifePrefab.SetActive(false);
        m_productionTimer = -1;
        FillPool();
    }

    void Update()
    {
        List<GameObject> deactivated = new List<GameObject>();

        foreach(GameObject go in m_poolActivated)
        {
            if (!go.activeSelf)
            {
                deactivated.Add(go);
            }
        }

        foreach (GameObject go in deactivated)
        {
            m_poolActivated.Remove(go);
            m_poolInstantiated.Add(go);
        }

        Produce();
    }

    protected virtual void Produce()
    {
        if (m_productionEnabled && m_poolInstantiated.Count > 0)
        {
            m_productionTimer -= Time.deltaTime;
            if (m_productionTimer < 0) TryActivate();
        }
    }

    public virtual void TryActivate()
    {
        if(m_poolInstantiated.Count > 0)
        {
            m_productionTimer = Random.Range(m_timeToRespawn.x, m_timeToRespawn.y);
            m_poolInstantiated[0].SetActive(true);
            m_poolActivated.Add(m_poolInstantiated[0]);
            m_poolInstantiated.RemoveAt(0);
        }
    }

    void ClearPools()
    {
        if (m_poolInstantiated.Count != 0)
        {
            foreach (GameObject go in m_poolInstantiated)
            {
                Destroy(go);
            }
            m_poolInstantiated.Clear();
        }

        if (m_poolActivated.Count != 0)
        {
            foreach (GameObject go in m_poolActivated)
            {
                Destroy(go);
            }
            m_poolActivated.Clear();
        }
    }

    void FillPool()
    {
        ClearPools();

        for (int i = 0; i < m_poolSize; ++i)
        {
            GameObject go = Instantiate(m_lifePrefab);
            m_poolInstantiated.Add(go);
        }
    }

    public void EnableProduction()
    {
        m_productionEnabled = true;
    }
    public void DisableProduction()
    {
        m_productionEnabled = false;
    }
}
