using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ItemPickUp))]
public class ItemPickUpEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ItemPickUp itemPickUp = (ItemPickUp)target;
        if (GUILayout.Button("PickUp"))
        {
            itemPickUp.PickUp();
        }
    }
}
