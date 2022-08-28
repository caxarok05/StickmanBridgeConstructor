using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        #region CONSTANTS

        private readonly Vector3 _movementDirection = Vector3.right;

        #endregion

        #region EVENTS

        public delegate void BuildingHandler();
        public static event BuildingHandler AbleToBuild;

        #endregion

        [SerializeField] private float speed;

        private Transform _playerTransform;
        private bool _onStopZone = false;
        private Animator _playerAnimator;

        #region MONO

        private void Start()
        {
            _playerTransform = GetComponent<Transform>();
            _playerAnimator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Bridge.StopZoneEnter.EnterStopZone += StopMovement;
            Bridge.BridgeFallingScript.BridgeFell += ContinueRun;
        }

        private void OnDisable()
        {
            Bridge.StopZoneEnter.EnterStopZone -= StopMovement;
            Bridge.BridgeFallingScript.BridgeFell -= ContinueRun;
        }

        #endregion

        private void Update()
        {
            if (!_onStopZone)
                _playerTransform.Translate(_movementDirection * speed * Time.deltaTime);

        }

        private void StopMovement()
        {
            _onStopZone = true;
            _playerAnimator.SetTrigger("IdleTrigger");
            AbleToBuild();
        }

        private void ContinueRun()
        {
            _onStopZone = false;      
            _playerAnimator.SetTrigger("RunTrigger");
        }
    }
}
