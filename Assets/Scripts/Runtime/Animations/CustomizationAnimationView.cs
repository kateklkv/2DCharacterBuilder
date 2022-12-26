using System;
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
        [SerializeField] private RectTransform rightPoint;

        private Vector3 _oldPosition;

        private void Awake() => _oldPosition = characterTransform.position;

        [Button]
        public void MoveToLeft() => characterTransform.DOMoveX(leftPoint.position.x, duration);

        [Button]
        public void MoveToOldPosition() => characterTransform.DOMoveX(_oldPosition.x, duration);

        [Button]
        public void MoveToRight() => characterTransform.DOMoveX(rightPoint.position.x, duration);
    }
}