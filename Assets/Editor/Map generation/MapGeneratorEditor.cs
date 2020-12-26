using UnityEngine;
using UnityEditor;

/* Map generator Editor that adds additional in-Editor functionality */
[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Defining target inspector
        MapGenerator mapGen = (MapGenerator)target;

        //Generate map if any inspector changes were made and if generator class have autoUpdate enabled
        if (DrawDefaultInspector() && mapGen.autoUpdate) mapGen.GenerateMap();
        GUILayout.Space(20);
        //Or if corresponding button was pressed
        if (GUILayout.Button("Generate Map")) mapGen.GenerateMap();
    }
}
