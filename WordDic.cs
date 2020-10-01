namespace MLTool
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class WordDic
    {
        public static bool Initialized { get; private set;}

        private static Dictionary<string, string> contentDic = new Dictionary<string, string>();
        private static HashSet<IMLText> mlTexts = new HashSet<IMLText>();
        private static Regex csvRegex = new Regex("(?<=^|,)(\"(?:[^\"]|\"\")*\"|[^,]*)");

        public static void Init(string language, string source)
        {
            contentDic.Clear();
            var datas = source.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var head = datas[0].Split(',');
            int? _ = null;

            for (int i = 1; i < head.Length; i++)
            {
                if (head[i] == language)
                {
                    _ = i;
                    break;
                }
            }

            if (!_.HasValue)
            {
                throw new Exception("Invalid language:" + language);
            }

            var index = _.GetValueOrDefault();

            for (int i = 1; i < datas.Length; i++)
            {
                var data = csvRegex.Matches(datas[i]);
                var word = data[index].Value;
                if (word[0].Equals('\"'))
                {
                    word = word.Remove(word.Length - 1)
                          .Remove(0, 1)
                          .Replace("\"\"", "\"");
                }
                contentDic[data[0].Value] = word.Replace("\\n", "\n");
            }

            Initialized = true;

            foreach (var mlText in mlTexts)
            {
                mlText?.Refresh();
            }
        }

        public static string Get(string key)
        {
            if (contentDic.TryGetValue(key, out var value))
            {
                return value;
            }

            throw new Exception("Invalid key:" + key);
        }

        public static void Register(IMLText mLText)
        {
            mlTexts.Add(mLText);
        }

        public static void Deregister(IMLText mLText)
        {
            mlTexts.Remove(mLText);
        }

    }
}
