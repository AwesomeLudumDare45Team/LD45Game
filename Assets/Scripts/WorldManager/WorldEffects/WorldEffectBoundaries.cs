using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectBoundaries : WorldEffect
{
    public Vector2 m_minPosition;
    public Vector2 m_maxPosition;

    public override void Initialize()
    {
        //
    }

    public override void Execute()
    {
        gameObject.SetActive(true);
        WorldManager wm = WorldManager.GetWorldManager();

        if(wm == null || wm.m_wallDown == null || wm.m_wallUp == null || wm.m_wallRight == null || wm.m_wallLeft == null)
        {
            Debug.LogError("Missing world manager or wall in it");
            return;
        }

        wm.m_wallDown.transform.SetPositionAndRotation(new Vector3(wm.m_wallDown.transform.position.x, m_minPosition.y, wm.m_wallDown.transform.position.z), Quaternion.identity);
        wm.m_wallUp.transform.SetPositionAndRotation(new Vector3(wm.m_wallUp.transform.position.x, m_maxPosition.y, wm.m_wallUp.transform.position.z), Quaternion.identity);
        wm.m_wallLeft.transform.SetPositionAndRotation(new Vector3(m_minPosition.x, wm.m_wallLeft.transform.position.y, wm.m_wallLeft.transform.position.z), Quaternion.identity);
        wm.m_wallRight.transform.SetPositionAndRotation(new Vector3(m_maxPosition.x, wm.m_wallRight.transform.position.y, wm.m_wallRight.transform.position.z), Quaternion.identity);
    }
}
