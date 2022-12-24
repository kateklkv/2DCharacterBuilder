using System.IO;
using UnityEngine;

namespace Runtime.AssetBundles
{
    public static class AssetBundlesProvider
    {
        public static AssetBundle GetAssetBundleByType(string bundleName)
        {
            var bundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, bundleName));
            
            if (bundle == null) 
                Debug.LogError("Asset Bundle with this name does not exist");
            
            return bundle;
        }
    }
}