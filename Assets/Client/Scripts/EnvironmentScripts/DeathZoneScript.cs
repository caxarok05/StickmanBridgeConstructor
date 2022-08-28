using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Environment
{
    public class DeathZoneScript : MonoBehaviour
    {
        #region EVENTS

        public delegate void DeathHandler();
        public static event DeathHandler PlayerDies;

        #endregion

        [SerializeField] private AudioSource _screamSound;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform.CompareTag("PlayerTag"))
            {
                PlayerDies();
                _screamSound.Play();
                collider.gameObject.GetComponent<Player.PlayerMovement>().enabled = false;
            }
        }
    }
}

