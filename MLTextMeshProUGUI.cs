namespace MLTool
{
    using UnityEngine;
    using TMPro;

    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(CanvasRenderer))]
    [AddComponentMenu("UI/ML-TextMeshPro - Text (UI)")]
    [ExecuteAlways]
    public class MLTextMeshProUGUI : TextMeshProUGUI, IMLText
    {
        [SerializeField]
        private string mlKey = string.Empty;
        [SerializeField]
        private bool refreshOnEnable = false;

        public void Refresh()
        {
            this.text = WordDic.Get(mlKey);
        }

        protected override void Awake()
        {
            WordDic.Register(this);
            base.Awake();
        }

        protected override void OnDestroy()
        {
            WordDic.Deregister(this);
            base.OnDestroy();
        }

        protected override void OnEnable()
        {
            if (refreshOnEnable && WordDic.Initialized)
            {
                Refresh();
            }
            base.OnEnable();
        }
    }
}