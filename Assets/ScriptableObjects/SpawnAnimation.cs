using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Scale")]
class SpawnAnimation : Animator<Transform>
{
        [Header("Parameters")]
        [SerializeField] private Vector3 _startScale;
        [SerializeField] private Vector3 _targetScale = Vector3.one;
        [SerializeField] private float _duration;

        public override void Animate(Transform target)
        {
            target.localScale = _startScale;
            target.DOScale(_targetScale, _duration);
        }
    
}
