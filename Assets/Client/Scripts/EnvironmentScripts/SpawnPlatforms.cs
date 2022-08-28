using UnityEngine;

namespace Scripts.Environment
{
    public class SpawnPlatforms : MonoBehaviour
    {

        #region CONSTANTS

        private const float SPAWN_DISTANCE = 40;
        private const float MIN_DISTANCE = 0.5f;
        private const float MAX_DISTANCE = 3;
        
        #endregion

        [SerializeField] private GameObject _platformPrefab;

        private Vector3 _spawnPlace;
        private bool IsSpawned = false;

        #region MONO

        private void OnEnable()
        {
           GetComponent<Scripts.Environment.RandomizePlatformScale>().IncreaseOver += AddSpace;
        }

        private void OnDisable()
        {
            GetComponent<Scripts.Environment.RandomizePlatformScale>().IncreaseOver -= AddSpace;
        }

        #endregion

        private void Update()
        {
            if (Camera.main.transform.position.x + SPAWN_DISTANCE >= gameObject.transform.position.x && IsSpawned == false)
            {
                SpawnNextPlatform();
                IsSpawned = true;
            }
        }

        private void AddSpace(Vector3 currentPos, float width)
        {
            _spawnPlace = new Vector3(currentPos.x + (width / 2) + Random.Range(MIN_DISTANCE, MAX_DISTANCE), currentPos.y, currentPos.z);        
        }

        private void SpawnNextPlatform()
        {
            Instantiate(_platformPrefab, _spawnPlace, Quaternion.identity);
        }
    }
}
