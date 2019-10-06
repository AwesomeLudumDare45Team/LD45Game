using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectEnvironmentElement : WorldEffect
{

    public WorldManager.EnvironmentElement m_element;

    public override void Initialize()
    {
        WorldManager.m_instance.m_elementActivation[m_element] = false;

        GameObject[] elementList = GameObject.FindGameObjectsWithTag("RecursiveEnable");

        for (int i = 0; i < elementList.Length; ++i)
        {
            EnvironmentElementRecursiveActivation(elementList[i].transform, false);
        }
    }

    public override void Execute()
    {
        WorldManager.m_instance.m_elementActivation[m_element] = true;

        GameObject[] elementList = GameObject.FindGameObjectsWithTag("RecursiveEnable");

        for (int i = 0; i < elementList.Length; ++i)
        {
            EnvironmentElementRecursiveActivation(elementList[i].transform, true);
        }
    }

    private void EnvironmentElementRecursiveActivation(in Transform _parent, bool _state)
    {
        for (int i = 0; i < _parent.childCount; ++i)
        {
            Transform child = _parent.GetChild(i);
            EnvironmentElementActivation(child, _state);

            if (child.childCount > 0)
                EnvironmentElementRecursiveActivation(child, _state);
        }
    }

    private void EnvironmentElementActivation(in Transform _transform, bool _state)
    {
        if (_transform.CompareTag(WorldManager.m_instance.m_elementTag[m_element]))
            _transform.gameObject.active = _state;
    }
}
