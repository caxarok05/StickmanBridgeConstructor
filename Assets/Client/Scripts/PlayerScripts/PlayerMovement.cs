using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        #region CONST

        private readonly Vector3 _movementDirection = Vector3.right;

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
            Scripts.Bridge.StopZoneEnter.EnterStopZone += StopMovement;
        }

        private void OnDisable()
        {
            Scripts.Bridge.StopZoneEnter.EnterStopZone -= StopMovement;
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
        }

        private void ContinueRun()
        {
            _onStopZone = false;      //вьебать ивент короче после того как мост достроен 
            _playerAnimator.SetTrigger("RunTrigger");
        }
    }
}
