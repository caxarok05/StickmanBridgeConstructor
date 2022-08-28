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

        private bool _isAllowed = false;

        #region MONO

        private void OnEnable()
        {
            Bridge.StopZoneEnter.EnterStopZone += AllowClicks;
        }
        private void OnDisable()
        {
            Bridge.StopZoneEnter.EnterStopZone -= AllowClicks;
        }

        #endregion

        private void Update()
        {
            if (_isAllowed)
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
                        _isAllowed = false;
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
                _isAllowed = false;
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
                    _isAllowed = false;
                }
#endif
            }

        }

        private void AllowClicks()
        {
            _isAllowed = true;
        }
    }

    
}

