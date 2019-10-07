using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerFactory : LifeFactory
{
    public float m_minPlayerSpeed;
    private PlayerController m_playerController;

    protected override void Init()
    {
        base.Init();

        m_playerController = GameManager.instance.player.GetComponent<PlayerController>();
    }

    protected override void Produce()
    {
        if (m_productionEnabled && m_poolInstantiated.Count > 0)
        {
            m_productionTimer -= Time.deltaTime;
        
            if (m_productionTimer < 0 && m_playerController.grounded && (Mathf.Abs(m_playerController.direction.x) > m_minPlayerSpeed))
                TryActivate();
        }
    }
}
