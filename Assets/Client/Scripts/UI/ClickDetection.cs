using UnityEngine;

namespace Scripts.UI
{
    public class ClickDetection : MonoBehaviour
    {
        #region EVENTS

        public delegate void ClickDetectionHandler();

        public static event ClickDetectionHandler ClickHappened;
        public static event ClickDetectionHandler ClickEnded;

        #endregion

        private void Update()
        {

#if PLATFORM_ANDROID

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    ClickHappened();
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    ClickEnded();
                }
            }
#endif

#if UNITY_STANDALONE_WIN

            if (Input.GetMouseButtonDown(0))
            {
                ClickHappened();
            }
            if(Input.GetMouseButtonUp(0))
            {
                ClickEnded();
            }

#endif

#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
            {
                ClickHappened();
            }
            if (Input.GetMouseButtonUp(0))
            {
                ClickEnded();
            }
#endif
        }
    }
}

