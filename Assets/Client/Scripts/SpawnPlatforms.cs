using UnityEngine;

namespace Scripts
{
    public class SpawnPlatforms : MonoBehaviour
    {

        #region CONSTANTS

        private const float SPAWN_DISTANCE = 40;
        private const float MAX_DISTANCE = 4;

        #endregion


        [SerializeField] private GameObject _platformPrefab;

        private Vector3 _spawnPlace;


        #region MONO

        private void OnEnable()
        {
            Scripts.RandomizePlatformScale.IncreaseOver += AddSpace;
        }

        private void OnDisable()
        {
            Scripts.RandomizePlatformScale.IncreaseOver -= AddSpace;
        }


        #endregion


        private void Update()
        {
            if (Camera.main.transform.position.x - SPAWN_DISTANCE >= gameObject.GetComponent<Transform>().position.x )
            {
                SpawnNextPlatform();
            }
        }

        private void AddSpace(Vector3 currentPos, float width)
        {
            _spawnPlace = new Vector3(currentPos.x + (width / 2) + Random.Range(0, MAX_DISTANCE), currentPos.y, currentPos.z);
            
        }

        private void SpawnNextPlatform()
        {
            Instantiate(_platformPrefab, _spawnPlace, Quaternion.identity);
        }
    }
}
