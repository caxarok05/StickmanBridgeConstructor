using UnityEngine;

namespace Scripts.Bridge
{
    public class BuildingBridgeScript : MonoBehaviour
    {
        #region CONST

        private const float BUILDING_SPEED = 0.02f;
        private const float MAX_HEIGHT = 4f;

        #endregion

        #region EVENTS

        public delegate void BuildingHandler();
        public static event BuildingHandler BuildingEnd;

        #endregion


        [SerializeField] private GameObject _bridgePrefab;

        private Animator _playerAnimator;
        private GameObject _currentBridge;

        private bool _allowBuilding = false;
        private bool _isSpawned = false;


        #region MONO

        private void Start()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            UI.ClickDetection.ClickHappened += StartBuild;
            UI.ClickDetection.ClickEnded += EndBuild;
        }

        private void OnDisable()
        {
            UI.ClickDetection.ClickHappened -= StartBuild;
            UI.ClickDetection.ClickEnded -= EndBuild;
        }

        #endregion

        private void Update()
        {
            if (_allowBuilding)
                RaiseBridge();          
            //else
            //    BuildingEnd();
        }

        private void StartBuild()
        {
            _playerAnimator.SetTrigger("BuildTrigger");
            if (!_isSpawned)
            {
                SpawnBridge();
                _isSpawned = true;
            }
            _allowBuilding = true;
        }

        private void EndBuild()
        {
            _allowBuilding = false;
            _playerAnimator.SetTrigger("WaitingTrigger");
        }

        private void SpawnBridge()
        {
           _currentBridge = Instantiate(_bridgePrefab, new Vector3(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }

        private void RaiseBridge()
        {
            if (_currentBridge.transform.localScale.y <= MAX_HEIGHT)
            {
                _currentBridge.transform.localScale += new Vector3(0, BUILDING_SPEED);
                _currentBridge.transform.position += new Vector3(0, BUILDING_SPEED / 2);
            }
            else
                BuildingEnd();
        }
    }

}
