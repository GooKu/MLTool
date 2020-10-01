namespace MLTool
{
    public static class TextExtension
    {
        public static void MutliText(this UnityEngine.UI.Text text, string key)
        {
            text.text = WordDic.Get(key);
        }

        public static void MutliText(this TMPro.TextMeshProUGUI text, string key)
        {
            text.text = WordDic.Get(key);
        }
    }
}