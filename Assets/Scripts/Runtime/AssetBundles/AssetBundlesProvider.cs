using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static List<Sprite> GetAssetBundleSprites(AssetBundle bundle)
        {
            var sprites = bundle.LoadAllAssets<Sprite>();
            
            if (sprites == null) 
                Debug.LogError("This Asset Bundle does not contain sprites");

            return sprites.ToList();
        }
    }
}