using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffectEnable : WorldEffect
{
    public bool m_recursiveManagementOfEnvironmentElement;

    public override void Initialize()
    {
        gameObject.SetActive(false);
        if (m_recursiveManagementOfEnvironmentElement)
            transform.tag = "RecursiveEnable";
    }

    public override void Execute()
    {
        if (m_recursiveManagementOfEnvironmentElement)
            EnvironmentElementRecursiveActivation(gameObject.transform);
        gameObject.SetActive(true);
    }


    private void EnvironmentElementRecursiveActivation(in Transform _parent)
    {
        for (int i = 0; i < _parent.childCount; ++i)
        {
            Transform child = _parent.GetChild(i);
            EnvironmentElementActivation(child);

            if (child.childCount > 0)
                EnvironmentElementRecursiveActivation(child);
        }
    }

    private void EnvironmentElementActivation(in Transform _transform)
    {
        bool activate = false;
        bool deactivate = false;
        if (_transform.CompareTag("Grass"))
        {
            activate = WorldManager.m_instance.m_elementActivation[WorldManager.EnvironmentElement.GRASS];
            deactivate = !activate;
        }
        else if (_transform.CompareTag("Weed"))
        {
            activate = WorldManager.m_instance.m_elementActivation[WorldManager.EnvironmentElement.WEED];
            deactivate = !activate;
        }
        else if (_transform.CompareTag("Tree"))
        {
            activate = WorldManager.m_instance.m_elementActivation[WorldManager.EnvironmentElement.TREE];
            deactivate = !activate;
        }

        if(activate)
            _transform.gameObject.active = true;
        if (deactivate)
            _transform.gameObject.active = false;
    }
}
