using UnityEngine;

namespace Scripts.Bridge
{
    public class BuildingBridgeScript : MonoBehaviour
    {
        #region CONSTANTS

        private const float BUILDING_SPEED = 0.015f;
        private const float MAX_HEIGHT = 3f;
        private const float PLAYER_SPAWN_DISTANCE = 0.3f;

        #endregion

        #region EVENTS

        public delegate void RaisingHandler();
        public static event RaisingHandler RaisingEnd;

        #endregion

        [SerializeField] private GameObject _bridgePrefab;
        [SerializeField] private AudioSource _buildingSound;

        private Animator _playerAnimator;
        private GameObject _currentBridge;

        private bool _allowRaising = false;
        private bool _isSpawned = false;
        private bool _allowBuilding = false;
       
        #region MONO

        private void Start()
        {
            _playerAnimator = GetComponent<Animator>();
            
        }

        private void OnEnable()
        {
            UI.ClickDetection.ClickHappened += StartBuild;
            UI.ClickDetection.ClickEnded += EndBuild;
            Player.PlayerMovement.AbleToBuild += AllowBuilding;
        }

        private void OnDisable()
        {
            UI.ClickDetection.ClickHappened -= StartBuild;
            UI.ClickDetection.ClickEnded -= EndBuild;
            Player.PlayerMovement.AbleToBuild -= AllowBuilding;
        }

        #endregion

        private void Update()
        {
            if (_allowRaising)
                RaiseBridge();
        }

        private void StartBuild()
        {
            if (_allowBuilding)
            {
                _buildingSound.Play();
                _playerAnimator.SetTrigger("BuildTrigger");
                if (!_isSpawned)
                {
                    SpawnBridge();
                    _isSpawned = true;
                }
                _allowRaising = true;
            }
           
        }

        private void EndBuild()
        {
            _allowRaising = false;
            _isSpawned = false;
            _playerAnimator.SetTrigger("WaitingTrigger");
            if (RaisingEnd != null)
                RaisingEnd();
            
        }

        private void SpawnBridge()
        {

           _currentBridge = Instantiate(_bridgePrefab, new Vector3(gameObject.transform.position.x + PLAYER_SPAWN_DISTANCE, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }

        private void RaiseBridge()
        {
            
            if (_currentBridge.transform.localScale.y <= MAX_HEIGHT)
            {
                _currentBridge.transform.localScale += new Vector3(0, BUILDING_SPEED);
                _currentBridge.transform.position += new Vector3(0, BUILDING_SPEED / 2);
            }
            else
                RaisingEnd();
        }

        private void AllowBuilding()
        {
            _allowBuilding = true;
        }
    }

}
