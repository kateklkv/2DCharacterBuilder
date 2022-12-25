using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Customization
{
    public class CustomizationView : MonoBehaviour
    {
        [SerializeField] private CustomizationService customizationService;
        [SerializeField] private List<ButtonCustomization> buttons;
        [SerializeField] private List<CustomizationPartView> parts;

        private void Start()
        {
            SubcribeEvents();
        }

        private void SubcribeEvents() 
            => buttons.ForEach(b => b.Button.onClick.AddListener(() => SetImageInPart(b)));

        private void SetImageInPart(ButtonCustomization button)
        {
            var sprites = customizationService.GetSpritesByType(button.Type);
            int randomIndex = Random.Range(0, sprites.Count);
            
            parts.ForEach(p =>
            {
                if (button.Type == p.Type)
                    p.UpdateImage(sprites[randomIndex]);
            });
        }
    }
}