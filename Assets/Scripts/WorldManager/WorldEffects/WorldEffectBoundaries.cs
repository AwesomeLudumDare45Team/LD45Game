using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectBoundaries : WorldEffect
{
    public Vector2 m_minPosition;
    public Vector2 m_maxPosition;

    public bool m_drawBorder;

    private void OnDrawGizmos()
    {
        if (m_drawBorder)
        {
            Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.25f);
            Gizmos.DrawCube(Vector3.zero, new Vector3(m_maxPosition.x - m_minPosition.x, m_maxPosition.y - m_minPosition.y, 0.1f));
        }
    }

    public override void Initialize()
    {
        //
    }

    public override void Execute()
    {
        GameManager gm = GameManager.instance;

        if(gm == null)
        {
            Debug.LogError("Missing world manager or wall in it");
            return;
        }

        gm.worldBoundaries.m_minPosition = m_minPosition;
        gm.worldBoundaries.m_maxPosition = m_maxPosition;
    }
}
