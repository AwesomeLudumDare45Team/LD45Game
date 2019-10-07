using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager m_instance { get; private set; }

    public int m_numItemToPickUp;

    public enum EnvironmentElement { GRASS, WEED, TREE, LIERE, MAX}
    [HideInInspector]
    public Dictionary<EnvironmentElement, string> m_elementTag = new Dictionary<EnvironmentElement, string>();
    [HideInInspector]
    public Dictionary<EnvironmentElement, bool> m_elementActivation = new Dictionary<EnvironmentElement, bool>();

    private void Awake()
    {
        if (m_instance != null)
        {
            Destroy(this);
            return;
        }

        m_instance = this;

        m_elementTag.Clear();
        m_elementTag.Add(EnvironmentElement.GRASS, "Grass");
        m_elementTag.Add(EnvironmentElement.WEED, "Weed");
        m_elementTag.Add(EnvironmentElement.TREE, "Tree");
        m_elementTag.Add(EnvironmentElement.LIERE, "Liere");

        m_elementActivation.Clear();
        m_elementActivation.Add(EnvironmentElement.GRASS, false);
        m_elementActivation.Add(EnvironmentElement.WEED, false);
        m_elementActivation.Add(EnvironmentElement.TREE, false);
        m_elementActivation.Add(EnvironmentElement.LIERE, false);
    }
}
