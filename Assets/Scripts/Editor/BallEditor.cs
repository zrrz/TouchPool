using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Ball))]
[CanEditMultipleObjects]
public class BallEditor : Editor {

	public override void OnInspectorGUI() {
		serializedObject.Update ();
		serializedObject.FindProperty("color").enumValueIndex = (int)(ColoredObject.ColorType)EditorGUILayout.EnumPopup((ColoredObject.ColorType)serializedObject.FindProperty("color").enumValueIndex);
		serializedObject.FindProperty ("mask").intValue = EditorGUILayout.LayerField (serializedObject.FindProperty ("mask").intValue, GUILayout.Width(EditorGUIUtility.labelWidth));

		Ball[] balls = new Ball[targets.Length];
		SerializedObject[] renderObjs = new SerializedObject[targets.Length];
		for(int i = 0; i < targets.Length; i++) {
			balls[i] = (Ball)targets[i];
			renderObjs[i] = new SerializedObject(balls[i].GetComponent<SpriteRenderer>());
			renderObjs[i].Update();
		}

		GUILayout.BeginHorizontal();

		if(GUILayout.Button("Green")) {
			for(int i = 0; i < targets.Length; i++) {
				balls[i].color = Ball.ColorType.Green;
				renderObjs[i].FindProperty("m_Color").colorValue = Color.green;
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}
		if(GUILayout.Button("Purple")) {
			for(int i = 0; i < targets.Length; i++) {
				balls[i].color = Ball.ColorType.Purple;
				renderObjs[i].FindProperty("m_Color").colorValue = new Color(.5f, 0f, 1f, 1f);
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}
		if(GUILayout.Button("Red")) {
			for(int i = 0; i < targets.Length; i++) {
				balls[i].color = Ball.ColorType.Red;
				renderObjs[i].FindProperty("m_Color").colorValue = Color.red;
			}
			UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
		}
		if(GUILayout.Button("Blue")) {
			for(int i = 0; i < targets.Length; i++) {
				balls[i].color = Ball.ColorType.Blue;
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
