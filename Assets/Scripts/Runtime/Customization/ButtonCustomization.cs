using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Customization
{
    public class ButtonCustomization : MonoBehaviour
    {
        [SerializeField] private Button button;
        public Button Button => button;
        
        [SerializeField] private CustomizationPartType type;
        public CustomizationPartType Type => type;
    }
}