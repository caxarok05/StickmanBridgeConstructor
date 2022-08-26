using UnityEngine;

namespace Scripts.Bridge
{
    public class BridgeFallingScript : MonoBehaviour
    {
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
            BuildingBridgeScript.BuildingEnd += EnableFalling;
        }

        private void OnDisable()
        {
            BuildingBridgeScript.BuildingEnd -= EnableFalling;
        }
        #endregion

        private void Update()
        {
            if (_canFall)
            {
                BridgeFalling();
                _canFall = false;
            }
            
        }

        private void EnableFalling()
        {
            _canFall = true;
        }

        private void BridgeFalling()
        {
            _bridgeTransform.RotateAround(_rotationDot, Vector3.back, 90);
        }

        private void FindDot()
        {
            _rotationDot = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (gameObject.transform.localScale.y / 2), gameObject.transform.position.z);
        }
    }
}

