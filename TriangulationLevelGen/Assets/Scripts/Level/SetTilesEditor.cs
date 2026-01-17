using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SetTiles))]
public class SetTilesEditor : Editor
{
    SetTiles setTiles;
    private void Awake()
    {
        setTiles = (SetTiles)target;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Generate Level"))
        {
            setTiles.GenerateLevel();
        }
    }
}
