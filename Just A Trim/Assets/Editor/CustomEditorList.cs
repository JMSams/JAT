using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace BJGames.JAT
{
    public class CustomEditorList : ReorderableList
    {
        public CustomEditorList(SerializedObject serializedObject, SerializedProperty serializedProperty, string header)
            : base(serializedObject, serializedProperty, true, true, true, true)
        {
            this.drawHeaderCallback = (Rect rect) =>
            {
                EditorGUI.LabelField(rect, header);
            };

            this.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                EditorGUI.PropertyField(rect, this.serializedProperty.GetArrayElementAtIndex(index));
            };

            this.onSelectCallback = (ReorderableList list) =>
            {
                Object element = list.serializedProperty.GetArrayElementAtIndex(list.index).objectReferenceValue as Object;
                if (element)
                    EditorGUIUtility.PingObject(element);
            };
        }
    }
}