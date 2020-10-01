namespace MLTool.Editor
{
    using UnityEditor;
    using UnityEngine;

    public static class CreateUtility
    {
        public static T Create<T>(string defaultName) where T : Component
        {
            GameObject go = new GameObject(defaultName, typeof(T));
            setParent(go);
            return go.GetComponent<T>();
        }

        private static void setParent(GameObject obj)
        {
            Transform objTransform = obj.transform;

            if (Selection.activeTransform == null || Selection.activeTransform.GetComponent<RectTransform>() == null)
            {
                Canvas canvas = (Canvas)Object.FindObjectOfType(typeof(Canvas));
                GameObject canvasObj = null;
                if (canvas == null)
                {
                    canvasObj = new GameObject("Canvas", typeof(Canvas));
                    canvasObj.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
                    canvasObj.AddComponent<UnityEngine.UI.CanvasScaler>();
                    checkRootEventSystem();
                }
                else
                {
                    canvasObj = canvas.gameObject;
                }

                objTransform.SetParent(canvasObj.transform);
            }
            else
            {
                objTransform.SetParent(Selection.activeTransform);
            }
            objTransform.localPosition = Vector2.zero;
            objTransform.localScale = Vector2.one;
        }

        private static void checkRootEventSystem()
        {
            GameObject[] rootObjs = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (GameObject obj in rootObjs)
            {
                if (obj.GetComponent<UnityEngine.EventSystems.EventSystem>() != null)
                    return;
            }
            GameObject eventSystemObj = new GameObject("EventSystem", typeof(UnityEngine.EventSystems.EventSystem));
            eventSystemObj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }
    }
}