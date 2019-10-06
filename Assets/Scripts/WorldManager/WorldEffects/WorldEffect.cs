using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEffect : MonoBehaviour
{
    void Start()
    {
        Initialize();
    }

    public virtual void Initialize() { }
    public virtual void Execute() { }
}
