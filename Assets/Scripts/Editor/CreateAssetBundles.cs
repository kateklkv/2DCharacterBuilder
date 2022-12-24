using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class CreateAssetBundles : MonoBehaviour
{
    private const string AssetBundlesPath = "Assets/Resources/AssetBundles";
    
    [MenuItem("Assets/Build AssetBundles")]
    private static void BuildAllAssetBundles()
    {
        if (!Directory.Exists(AssetBundlesPath))
            Directory.CreateDirectory(AssetBundlesPath);

        BuildPipeline.BuildAssetBundles(
            AssetBundlesPath, 
            BuildAssetBundleOptions.None,
            EditorUserBuildSettings.activeBuildTarget);
    }
}
