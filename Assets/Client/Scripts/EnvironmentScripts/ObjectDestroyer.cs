using UnityEngine;

namespace Scripts.Environment
{
    public class ObjectDestroyer : MonoBehaviour
    {
        #region CONSTANTS

        private const float DESTROY_DISTANCE = 30;

        #endregion

        private void Update()
        {
            if (Camera.main.transform.position.x >= gameObject.transform.position.x + DESTROY_DISTANCE)
            {
                Destroy(gameObject);
            }
        }
    }
}

