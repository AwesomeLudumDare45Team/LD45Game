using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public List<WorldEffect> m_worldEffectList;
    public bool m_debugDisableDestroy;
    
    void Start()
    {
        m_debugDisableDestroy = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        foreach (WorldEffect worldEffect in m_worldEffectList)
        {
            if(worldEffect != null)
            {
                worldEffect.Execute();
            }
        }

        if (!m_debugDisableDestroy)
        {
            Destroy(gameObject);
        }
    }
}
