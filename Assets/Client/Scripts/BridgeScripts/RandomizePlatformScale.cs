using UnityEngine;

namespace Scripts.Bridge
{
    public class RandomizePlatformScale : MonoBehaviour
    {

        #region CONSTANTS

        private const float MIN_WIDTH = 0.3f;
        private const float MAX_WIDTH = 3;

        #endregion

        #region EVENTS

        public delegate void IncreasingPrefabHandler(Vector3 pos, float width);
        public event IncreasingPrefabHandler IncreaseOver;


        #endregion


        private Transform _currentPlatformTransform;
        private float IncreasingSize;

        #region MONO

        private void Start()
        {
            IncreasingSize = Random.Range(MIN_WIDTH, MAX_WIDTH);
            _currentPlatformTransform = GetComponent<Transform>();

            IncreasePrefabScale();
            FixPosition();
            IncreaseOver(_currentPlatformTransform.position, _currentPlatformTransform.localScale.x);
        }

        #endregion

        private void IncreasePrefabScale()
        {
            _currentPlatformTransform.localScale = new Vector3(IncreasingSize, _currentPlatformTransform.localScale.y, _currentPlatformTransform.localScale.z);
        }
        
        private void FixPosition()
        {
            _currentPlatformTransform.position = new Vector3(_currentPlatformTransform.position.x + (IncreasingSize / 2), _currentPlatformTransform.position.y, _currentPlatformTransform.position.z);   
        }
    }
}
 