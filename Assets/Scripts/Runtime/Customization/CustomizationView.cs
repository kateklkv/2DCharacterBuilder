using System.Collections.Generic;
using DG.Tweening;
using Runtime.Animations;
using UnityEngine;

namespace Runtime.Customization
{
    public class CustomizationView : MonoBehaviour
    {
        [SerializeField] private CustomizationAnimationView animationView;
        [SerializeField] private List<ButtonCustomization> buttons;
        [SerializeField] private List<CustomizationPartView> parts;
        
        private Tween _tween;
        private Sequence _sequence;
        
        private Tween _tweenMoveToOldPosition;
        private Sequence _sequenceMoveToOldPosition;
        
        private Tween _tweenMoveToRight;
        private Sequence _sequenceMoveToRight;

        private void Start()
        {
            SubcribeEvents();
        }

        private void SubcribeEvents() 
            => buttons.ForEach(b => b.Button.onClick.AddListener(() => StartImageChange(b)));
        
        private void StartImageChange(ButtonCustomization button)
        {
            if (_sequence != null) _sequence.Kill();
            
            _tween?.Kill();
            _tween = DOVirtual.DelayedCall(0, () => CreateMoveToLeft(button));
        }

        private void CreateMoveToLeft(ButtonCustomization button)
        {
            _sequence = DOTween.Sequence();
            
            _sequence.Append(animationView.MoveToLeft());
            
            _sequence.Append(animationView.MoveToLeft().OnComplete(() => SetImageInPart(button)));
            
            _sequence.Append(animationView.MoveToOldPosition());
        }
        
        private void SetImageInPart(ButtonCustomization button)
        {
            var sprite = CustomizationService.GetRandomSpriteByType(button.Type);
            
            parts.ForEach(p =>
            {
                if (button.Type == p.Type)
                    p.UpdateImage(sprite);
            });
        }
    }
}