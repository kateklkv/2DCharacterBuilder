using DG.Tweening;
using EasyButtons;
using UnityEngine;

namespace Runtime.Animations
{
    public class CustomizationAnimationView : MonoBehaviour
    {
        public float duration;

        [SerializeField] private Transform characterTransform;
        [SerializeField] private RectTransform leftPoint;

        private Vector3 _oldPosition;

        private void Awake() => _oldPosition = characterTransform.position;

        [Button]
        public Tween MoveToLeft() => characterTransform.DOMoveX(leftPoint.position.x, duration);

        [Button]
        public Tween MoveToOldPosition() => characterTransform.DOMoveX(_oldPosition.x, duration);
    }
}