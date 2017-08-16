using UnityEditor;
using UnityEngine;

public class CreatePrototypesAsset {

    [MenuItem("Assets/Create/PrototypesList")]
    public static ScriptablePrototypesDictionaries Create() {
        ScriptablePrototypesDictionaries asset = ScriptableObject.CreateInstance<ScriptablePrototypesDictionaries>();
        AssetDatabase.CreateAsset(asset, "Assets/PrototypesList.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
