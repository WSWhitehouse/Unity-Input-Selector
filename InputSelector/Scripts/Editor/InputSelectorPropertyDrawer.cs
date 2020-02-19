// ------------------------------------------- //
// Author  : William Whitehouse / WSWhitehouse //
// GitHub  : github.com/WSWhitehouse           //
// Created : 30/06/2019                        //
// Edited  : 19/02/2020                        // 
// ------------------------------------------- //

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace WSWhitehouse.InputSelector.Editor
{
    [CustomPropertyDrawer(typeof(InputSelectorAttribute))]
    public class InputSelectorPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            List<string> tagList = new List<string> {"<NoInput>"};
            tagList.AddRange(GetInputManagerAxes());
            string propertyString = property.stringValue;
            int index = -1;
            if (propertyString == "")
            {
                index = 0;
            }
            else
            {
                for (int i = 1; i < tagList.Count; i++)
                {
                    if (tagList[i] != propertyString)
                    {
                        continue;
                    }

                    index = i;
                    break;
                }
            }

            index = EditorGUI.Popup(position, label.text, index, tagList.ToArray());

            if (index == 0)
            {
                property.stringValue = "";
            }
            else if (index >= 1)
            {
                property.stringValue = tagList[index];
            }
            else
            {
                property.stringValue = "";
            }

            EditorGUI.EndProperty();
        }

        private static IEnumerable<string> GetInputManagerAxes()
        {
            List<string> inputAxes = new List<string>();
            SerializedProperty inputAxesProperty =
                new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0])
                    .FindProperty("m_Axes");
            inputAxesProperty.Next(true);
            inputAxesProperty.Next(true);
            while (inputAxesProperty.Next(false))
            {
                SerializedProperty axes = inputAxesProperty.Copy();
                axes.Next(true);
                inputAxes.Add(axes.stringValue);
            }

            return inputAxes;
        }
    }
}