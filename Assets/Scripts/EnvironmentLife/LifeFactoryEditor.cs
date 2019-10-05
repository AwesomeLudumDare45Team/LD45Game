using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LifeFactory))]
public class LifeFactoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LifeFactory lifeFactory = (LifeFactory)target;
        if (GUILayout.Button("Enable Production"))
        {
            lifeFactory.EnableProduction();
        }
        if (GUILayout.Button("Disable Production"))
        {
            lifeFactory.DisableProduction();
        }
        if (GUILayout.Button("Try Activate"))
        {
            lifeFactory.TryActivate();
        }
    }
}
