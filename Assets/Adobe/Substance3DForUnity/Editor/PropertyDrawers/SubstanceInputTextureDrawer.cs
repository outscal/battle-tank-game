using UnityEditor;
using Adobe.Substance.Input;
using UnityEngine;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputTexture))]
    internal class SubstanceInputTextureDrawer : SubstanceInputDrawer
    {
        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            switch (content.Description.WidgetType)
            {
                default:
                    return DrawDefault(position, valueProperty, content);
            }
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.ObjectField(position, valueProperty, content);
            var changed = EditorGUI.EndChangeCheck();

            if (changed)
            {
                var texture = valueProperty.objectReferenceValue as Texture2D;

                if (!texture.isReadable)
                    TextureUtils.SetReadableFlag(texture, true);
            }

            return changed;
        }
    }
}