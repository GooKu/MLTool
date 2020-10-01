namespace MLTool.Editor
{
    using UnityEditor;
    using UnityEngine;

    [CustomEditor(typeof(MLText))]
    public class MLTextInspector : UnityEditor.UI.TextEditor
    {
        private SerializedProperty mlKeyProperty;
        private SerializedProperty refreshOnEnableProperty;

        [MenuItem("GameObject/UI/ML - Text")]
        public static void CreatText()
        {
            MLText text = CreateUtility.Create<MLText>("MLText");
            text.raycastTarget = false;
            text.text = "New Text";
            text.color = Color.white;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            mlKeyProperty = serializedObject.FindProperty("mlKey");
            refreshOnEnableProperty = serializedObject.FindProperty("refreshOnEnable");
        }

        public override void OnInspectorGUI()
        {
            mlKeyProperty.stringValue = EditorGUILayout.TextField("MLKey", mlKeyProperty.stringValue);
            refreshOnEnableProperty.boolValue = EditorGUILayout.Toggle("RefreshOnEnable", refreshOnEnableProperty.boolValue);
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}