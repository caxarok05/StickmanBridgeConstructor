using UnityEngine;

namespace Scripts.Bridge
{
    public class BridgeFallingScript : MonoBehaviour
    {
        #region CONSTANTS

        private const float MAX_ANGLE = -0.707f;
        private const float ROTATION_SPEED = 60;

        #endregion

        #region EVENTS

        public delegate void FallingHandler();
        public static event FallingHandler BridgeFell;

        #endregion

        private Transform _bridgeTransform;
        private Vector3 _rotationDot;
        private bool _canFall = false;

        #region MONO

        private void Start()
        {
            _bridgeTransform = GetComponent<Transform>();
            FindDot();
        }

        private void OnEnable()
        {
            BuildingBridgeScript.RaisingEnd += EnableFalling;
        }

        private void OnDisable()
        {
            BuildingBridgeScript.RaisingEnd -= EnableFalling;
        }
        #endregion

        private void Update()
        {
            if (_canFall)
            {
                BridgeFalling();
            }
            
        }

        private void EnableFalling()
        {
            _canFall = true;
        }

        private void BridgeFalling()
        {
            if (_bridgeTransform.rotation.z >= MAX_ANGLE)
            {
                _bridgeTransform.RotateAround(_rotationDot, Vector3.back, ROTATION_SPEED * Time.deltaTime);
            }        
            else
            {
                _canFall = false;
                BridgeFell();
            }
              
        }

        private void FindDot()
        {
            _rotationDot = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (gameObject.transform.localScale.y / 2), gameObject.transform.position.z);
        }
    }
}

