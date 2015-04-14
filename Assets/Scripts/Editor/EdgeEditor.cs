using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Edge))]
[CanEditMultipleObjects]
public class EdgeEditor : Editor {

	public override void OnInspectorGUI() {
		serializedObject.Update ();
		serializedObject.FindProperty("color").enumValueIndex = (int)(ColoredObject.ColorType)EditorGUILayout.EnumPopup((ColoredObject.ColorType)serializedObject.FindProperty("color").enumValueIndex);

		Edge[] edges = new Edge[targets.Length];
		SerializedObject[] renderObjs = new SerializedObject[targets.Length];
		for(int i = 0; i < targets.Length; i++) {
			edges[i] = (Edge)targets[i];
			renderObjs[i] = new SerializedObject(edges[i].GetComponent<SpriteRenderer>());
			renderObjs[i].Update();
		}

		GUILayout.BeginHorizontal();

		if(GUILayout.Button("Green")) {
			for(int i = 0; i < targets.Length; i++) {
				edges[i].color = Edge.ColorType.Green;
				renderObjs[i].FindProperty("m_Color").colorValue = Color.green;
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}
		if(GUILayout.Button("Purple")) {
			for(int i = 0; i < targets.Length; i++) {
				edges[i].color = Edge.ColorType.Purple;
				renderObjs[i].FindProperty("m_Color").colorValue = new Color(.5f, 0f, 1f, 1f);
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}
		if(GUILayout.Button("Red")) {
			for(int i = 0; i < targets.Length; i++) {
				edges[i].color = Edge.ColorType.Red;
				renderObjs[i].FindProperty("m_Color").colorValue = Color.red;
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}
		if(GUILayout.Button("Blue")) {
			for(int i = 0; i < targets.Length; i++) {
				edges[i].color = Edge.ColorType.Blue;
				renderObjs[i].FindProperty("m_Color").colorValue = Color.blue;
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}

		GUILayout.EndHorizontal();

		for(int i = 0; i < targets.Length; i++) {
			renderObjs[i].ApplyModifiedProperties();
			serializedObject.ApplyModifiedProperties ();
		}
	}
}
