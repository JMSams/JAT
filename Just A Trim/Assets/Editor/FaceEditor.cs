using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace HairyIndies.JAT
{
    [CustomEditor(typeof(Face))]
    public class FaceEditor : Editor
    {
        CustomEditorList eyeList;
        CustomEditorList noseList;
        CustomEditorList earList;
        CustomEditorList lipList;
        CustomEditorList headList;

        CustomEditorList beardList;
        CustomEditorList headHairList;
        CustomEditorList earHairList;
        CustomEditorList noseHairList;
        CustomEditorList eyebrowList;

        void OnEnable()
        {
            beardList = new CustomEditorList(serializedObject, serializedObject.FindProperty("beardPrefabs"), "Beard Prefabs");
            headHairList = new CustomEditorList(serializedObject, serializedObject.FindProperty("headHairPrefabs"), "Head Hair Prefabss");
            earHairList = new CustomEditorList(serializedObject, serializedObject.FindProperty("earHairPrefabs"), "Ear Hair Prefabs");
            noseHairList = new CustomEditorList(serializedObject, serializedObject.FindProperty("noseHairPrefabs"), "Nose Hair Prefabs");
            eyebrowList = new CustomEditorList(serializedObject, serializedObject.FindProperty("eyebrowPrefabs"), "Eyebrow Prefabs");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            beardList.DoLayoutList();
            headHairList.DoLayoutList();
            earHairList.DoLayoutList();
            noseHairList.DoLayoutList();
            eyebrowList.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}