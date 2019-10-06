using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectEnable : WorldEffect
{
    public override void Initialize()
    {
        gameObject.SetActive(false);
    }

    public override void Execute()
    {
        gameObject.SetActive(true);
    }
}
