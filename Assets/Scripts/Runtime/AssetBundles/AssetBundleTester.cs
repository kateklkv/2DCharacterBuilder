using EasyButtons;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.AssetBundles
{
    public class AssetBundleTester : MonoBehaviour
    {
        [SerializeField] private Text textAssetBundleName;
        [SerializeField] private string nameAssetBundle;
        
        [Button]
        public void SetNameAssetBundle()
        {
            var bundle = AssetBundlesProvider.GetAssetBundleByType(nameAssetBundle);
            
            if (bundle == null) return;
            
            textAssetBundleName.text = bundle.name;
        }
    }
}