using System;
using System.Collections.Generic;
using Runtime.AssetBundles;
using UnityEngine;

namespace Runtime.Customization
{
    public class CustomizationService : MonoBehaviour
    {
        public Dictionary<string, List<Sprite>> SpritesByTypeDictionary { get; } =
            new Dictionary<string, List<Sprite>>();

        private void Awake() => GetAllSpritesFromAssetBundles();

        private void GetAllSpritesFromAssetBundles()
        {
            foreach (CustomizationPartType type in (CustomizationPartType[]) Enum.GetValues(typeof(CustomizationPartType)))
            {
                var bundle = AssetBundlesProvider.GetAssetBundleByType(type.ToString());
                var sprites = AssetBundlesProvider.GetAssetBundleSprites(bundle);
                SpritesByTypeDictionary.Add(type.ToString(), sprites);
            }
        }

        public List<Sprite> GetSpritesByType(CustomizationPartType type) => SpritesByTypeDictionary[type.ToString()];
    }
}