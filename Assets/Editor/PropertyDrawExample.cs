using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ExampleScript.MyGenericClass<>))]
public class PropertyDrawExample : PropertyDrawer
{
    bool initializedDrawer;
    const float displayPropertyWidth = 125f;

    public void OnEnable(SerializedProperty property)
    {
        initializedDrawer = true;

    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (!initializedDrawer)
            OnEnable(property);

        /////Indent hack
        EditorGUI.BeginProperty(position, label, property);
        int indentSaved = EditorGUI.indentLevel;
        float widthFromIndentation = indentSaved * 9f;
        EditorGUI.indentLevel = 0;

        SerializedProperty myVar = property.FindPropertyRelative("myVariable");
        SerializedProperty toDisplay = property.FindPropertyRelative("toDisplay");

        Rect labelRect = new Rect(widthFromIndentation + position.x, position.y, 20, 20);
        Rect leftRect = new Rect(widthFromIndentation + position.x + 50, position.y, 60, 20);
        Rect rightRect = new Rect(widthFromIndentation + position.x + 100, position.y, 120, 20);

        //EditorGUI.LabelField(labelRect, property.name);
        //EditorGUI.PropertyField(labelRect, myBool);

        EditorGUI.PropertyField(labelRect, toDisplay, GUIContent.none);
        EditorGUI.LabelField(leftRect, label);

        if (toDisplay.boolValue)
        {
            EditorGUI.PropertyField(rightRect, myVar, GUIContent.none);
        }

        EditorGUI.EndProperty();
        EditorGUI.indentLevel = indentSaved;
    }
}
