using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGland : MonoBehaviour
{
    public GameObject m_modelGland;
    public GameObject m_modelGoldenGland;

    bool m_swapped;
    // Start is called before the first frame update
    void Start()
    {
        m_swapped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_swapped)
        {
            m_modelGland.SetActive(false);
            m_modelGoldenGland.SetActive(true);
            m_swapped = true;
        }
    }
}
