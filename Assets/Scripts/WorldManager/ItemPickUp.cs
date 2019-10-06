using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public List<WorldEffect> m_worldEffectList;
    public bool m_revertEffect = false;
    public bool m_debugDisableRemove;

    private bool m_deactivateNotDestroy = true;
    
    void Start()
    {
        m_debugDisableRemove = false;
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
                if (m_revertEffect)
                    worldEffect.Initialize();
                else
                    worldEffect.Execute();
            }
        }

        if (!m_revertEffect || !m_debugDisableRemove)
        {
            if (m_deactivateNotDestroy)
                gameObject.SetActive(false);
            else
                Destroy(gameObject);
        }
    }
}
