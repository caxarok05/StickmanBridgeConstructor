using UnityEngine;

namespace Scripts.Environment
{
    public class CameraMovementScript : MonoBehaviour
    {
        #region CONSTANTS

        private const float Y_CAM_POSITION = 0;
        #endregion

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, Y_CAM_POSITION, transform.position.z);
        }
    }

}
