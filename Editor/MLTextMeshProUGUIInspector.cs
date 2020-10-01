namespace MLTool.Editor
{
    using UnityEngine;
    using UnityEditor;
    using TMPro.EditorUtilities;

    [CustomEditor(typeof(MLTextMeshProUGUI), true), CanEditMultipleObjects]
    public class MLTextMeshProUGUIInspector : TMP_EditorPanel
    {
        private SerializedProperty mlKeyProperty;
        private SerializedProperty refreshOnEnableProperty;

        [MenuItem("GameObject/UI/ML - TextMeshPro - Text")]
        public static void CreatText()
        {
            MLTextMeshProUGUI text = CreateUtility.Create<MLTextMeshProUGUI>("MLText(TMP)");
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
            mlKeyProperty.stringValue = EditorGUILayout.TextField("mlKey", mlKeyProperty.stringValue);
            refreshOnEnableProperty.boolValue = EditorGUILayout.Toggle("RefreshOnEnable", refreshOnEnableProperty.boolValue);
            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }
    }
}