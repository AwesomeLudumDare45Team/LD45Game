using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FlowerFactory))]
public class FlowerFactoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        FlowerFactory lifeFactory = (FlowerFactory)target;
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
