# MLTool
MLTool is a simple multi language soultion for Unity.

Available Unity version: 2019 upper

Sample project: https://github.com/GooKu/MLToolSample

***
# Feature
* Update text content by key.
* Runtime refresh text content as target language change.
* Support extension of UGUI Text and TextMeshPro - Text.
* Support newline string:"\n"
***
# Format of the source file
MLTool implement mutli language setting by inject the external source file.  
MLTool support comma-separated CSV to be the source file format.  
The first column is the keys column, each of them should be string value and unique.  
The heads form the second column mean language key, they are using to assign target language at runtime.  
The content of source file should like:
```
id,zh-tw,en
key1,哈囉,Hello
key2,世界,World
```

About edit/maintain source file, you can use third-party softwar like: [CSVpad](http://www.trustfm.net/software/utilities/CSVpad.php)
***
# APIs and feature

## WordDic
WordDic is the main class of MLTool work.
### WordDic.Init
public static void Init(string language, string source)
#### Parameters
| Parameter | Description |
| :-----| :----- |
| language | The target language you want to use match the head of source file(from second column). |
| source | The source file's string, it should including language key, text key, and text content. |
#### Description
You must have to initialize before using other MLTool API/component.
Using WordDic.Init to initialize MLTool.
```
using UnityEngine;
using MLTool;
public class SampleCode : MonoBehaviour
{
    [SerializeField]
    private TextAsset lines = null;

    private void Start()
    {
        WordDic.Init("en", lines.text);
    }
}
```

### WordDic.Get
public static string Get(string key)
#### Parameters
| Parameter | Description |
| :-----| :----- |
| key | The key of the target text content. |
#### Description
Return the target text content with target language,
```
using UnityEngine;
using MLTool;
public class SampleCode : MonoBehaviour
{
    [SerializeField]
    private TextAsset lines = null;

    private void Start()
    {
        WordDic.Init("en", lines.text);
        Debug.Log(WordDic.Get("key1"));
    }
}
```

### WordDic.Register
public static void Register(IMLText mLText)
#### Parameters
| Parameter | Description |
| :-----| :----- |
| mLText | The instance of IMLText you want to register. |
#### Description
MLTool will call IMLText.Refresh who register as WordDic.Init. 

### WordDic.Deregister
public static void Deregister(IMLText mLText)
#### Parameters
| Parameter | Description |
| :-----| :----- |
| mLText | The instance of IMLText you want to deregister. |
#### Description
MLTool will not call IMLText.Refresh who deregister as WordDic.Init. 


## TextExtension
TextExtension is the class which shortcut extensions of UnityEngine.UI.Text and TMPro.TextMeshProUGUI.  
You can use it by using name space: MLTool.
```
using UnityEngine;
using UnityEngine.UI;
using TMPro.TextMeshProUGUI;
using MLTool;
public class SampleCode : MonoBehaviour
{
    [SerializeField]
    private TextAsset lines = null;
    [SerializeField]
    private Text sampleText = null;
    [SerializeField]
    private TextMeshProUGUI sampleTMPText = null;

    private void Start()
    {
        WordDic.Init("en", lines.text);
        sampleText.MutliText("key1");
        sampleTMPText.MutliText("key1");
    }
}
```

## MLText
MLText is the text component of overwirite UnityEngine.UI.Text.  
You can setting word key at the inspector, MLTool will auto-refresh text content as WordDic.Init.  
You can create the componet by:
* Select menu item at GameObject->UI->ML-Text
* Right click on hierarchy, select menu item at UI->ML - Text

#### Properties
| Propertie | Description |
| :-----| :----- |
| mlKey | The key of the target text content. |
| refreshOnEnable | It will auto refresh text as component enable if setting true. This is using for the text object which instance after WordDic.Init. |


## MLTextMeshProUGUI
MLTextMeshProUGUI is the text component of overwirite TMPro.TextMeshProUGUI.  
You can setting word key at the inspector, MLTool will auto-refresh text content as WordDic.Init.  
You can create the componet by:
* Select menu item at GameObject->UI->ML-TextMeshPro - Text
* Right click on hierarchy, select menu item at UI->ML - TextMeshPro - Text (UI)

#### Properties
| Propertie | Description |
| :-----| :----- |
| mlKey | The key of the target text content. |
| refreshOnEnable | It will auto refresh text as component enable if setting true. This is using for the text object which instance after WordDic.Init. |


***
If this is good for you, welcom to donate me by:
* Purchase Goo's donate App(Android): https://play.google.com/store/apps/details?id=com.Goo.DonateToGoo
* Web donate: https://core.newebpay.com/EPG/GooDonateBox/7HM3Jf
