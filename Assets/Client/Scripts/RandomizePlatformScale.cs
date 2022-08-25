using UnityEngine;

namespace Scripts
{
    public class RandomizePlatformScale : MonoBehaviour
    {

        #region CONSTANTS

        private const float MAX_WIDTH = 4;

        #endregion

        #region EVENTS

        public delegate void IncreasingPrefab(Vector3 pos, float width);
        public static event IncreasingPrefab IncreaseOver;


        #endregion


        private Transform _currentPlatformTransform;
        private float IncreasingSize;

        #region MONO

        private void Awake()
        {
            IncreasingSize = Random.Range(0, MAX_WIDTH);
            _currentPlatformTransform = GetComponent<Transform>();

            IncreasePrefabScale();
            FixPosition();
            IncreaseOver(_currentPlatformTransform.position, _currentPlatformTransform.localScale.x);
        }

        #endregion

        private void IncreasePrefabScale()
        {
            _currentPlatformTransform.localScale = new Vector3(_currentPlatformTransform.localScale.x + IncreasingSize, _currentPlatformTransform.localScale.y, _currentPlatformTransform.localScale.z);
        }
        
        private void FixPosition()
        {
            _currentPlatformTransform.position = new Vector3(_currentPlatformTransform.position.x + (IncreasingSize / 2), _currentPlatformTransform.position.y, _currentPlatformTransform.position.z);   
        }
    }
}
