using UnityEngine;

namespace Scripts.Environment
{
    public class BGMovement : MonoBehaviour
    {
        [SerializeField] private int _countOfObjects;

        private Transform _spriteTransform;
        private float _spriteSize;


        #region MONO

        private void Start()
        {
            _spriteTransform = GetComponent<Transform>();
            _spriteSize = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        #endregion

        private void Update()
        {
            MoveNextSprite();
        }

        private void MoveNextSprite()
        {
            Vector3 offset = Vector3.zero;

            if (Camera.main.transform.position.x >= _spriteTransform.position.x + _spriteSize)
                offset = new Vector3(_spriteSize * _countOfObjects, 0, 0);

            _spriteTransform.position += offset;
        }
    }
}

