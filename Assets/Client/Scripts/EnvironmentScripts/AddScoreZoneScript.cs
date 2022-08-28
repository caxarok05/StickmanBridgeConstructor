using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Environment
{
    public class AddScoreZoneScript : MonoBehaviour
    {

        #region EVENTS

        public delegate void AddScoreZoneHandler();
        public static event AddScoreZoneHandler AddScore;

        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.transform.CompareTag("PlayerTag"))
            {
                AddScore();
            }
        }
    }
}

