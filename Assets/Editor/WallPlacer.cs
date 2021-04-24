using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WallRecursion))]
public class WallPlacer : Editor
{


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Left"))
        {

            NextWall(0);
        }

        if (GUILayout.Button("Forward"))
        {

            NextWall(1);
        }

        if (GUILayout.Button("Right"))
        {

            NextWall(2);
        }

        GUILayout.EndHorizontal();

        if (GUILayout.Button("Back"))
        {

            NextWall(3);
        }
    }

    void NextWall(int num)
    {

        WallRecursion rec = (WallRecursion)target;
        GameObject newWall = rec.PlaceWall(num);
        Selection.objects = new Object[] { newWall };
    }
}
