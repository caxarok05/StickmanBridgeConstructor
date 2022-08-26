using UnityEngine;

namespace Scripts.Bridge
{
    public class StopZoneEnter : MonoBehaviour
    {
        #region EVENTS

        public delegate void StopZoneHandler();
        public static event StopZoneHandler EnterStopZone;

        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.transform.CompareTag("PlayerTag"))
            {
                EnterStopZone();
            }
        }
    }
}
