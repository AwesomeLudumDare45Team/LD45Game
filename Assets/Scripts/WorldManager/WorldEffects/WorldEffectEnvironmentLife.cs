using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectEnvironmentLife : WorldEffect
{
    public LifeFactory m_lifeFactory;

    public override void Initialize()
    {
        m_lifeFactory.DisableProduction();
    }

    public override void Execute()
    {
        m_lifeFactory.EnableProduction();
    }
}
