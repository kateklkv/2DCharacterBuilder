using System;
using System.Collections.Generic;
using Runtime.AssetBundles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime.Customization
{
    public static class CustomizationService
    {
        public static Dictionary<string, List<Sprite>> SpritesByTypeDictionary { get; } =
            new Dictionary<string, List<Sprite>>();

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            GetAllSpritesFromAssetBundles();
        }

        private static void GetAllSpritesFromAssetBundles()
        {
            foreach (CustomizationPartType type in (CustomizationPartType[]) Enum.GetValues(typeof(CustomizationPartType)))
            {
                var bundle = AssetBundlesProvider.GetAssetBundleByType(type.ToString());
                var sprites = AssetBundlesProvider.GetAssetBundleSprites(bundle);
                SpritesByTypeDictionary.Add(type.ToString(), sprites);
            }
        }

        public static List<Sprite> GetSpritesByType(CustomizationPartType type) => SpritesByTypeDictionary[type.ToString()];

        public static Sprite GetRandomSpriteByType(CustomizationPartType type)
        {
            var sprites = GetSpritesByType(type);
            
            int randomIndex = Random.Range(0, sprites.Count);

            return sprites[randomIndex];
        }
    }
}