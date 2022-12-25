using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Customization
{
    public class CustomizationPartView : MonoBehaviour
    {
        [SerializeField] private Image image;

        [SerializeField] private CustomizationPartType type;
        public CustomizationPartType Type => type;
        
        public void UpdateImage(Sprite sprite) => image.sprite = sprite;
    }
}