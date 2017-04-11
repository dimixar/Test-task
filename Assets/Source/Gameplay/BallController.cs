using UnityEngine;

namespace BallTest.Gameplay {
    public class BallController : MonoBehaviour {
        #region public events
        public System.Action OnBallHit;
        #endregion

        #region Serialized fields
        [SerializeField]
        private float _acceleration;
        #endregion

        #region Private fields
        private Rigidbody2D _rigidBody;
        private Vector2 _force;
        #endregion

        #region Public methods and properties
        public void SetGravity(float gravity) {
            _rigidBody.gravityScale = gravity * -1;
        }
        #endregion

        #region Private methods
        private bool IsTouching() {
            return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary;
        }
        #endregion

        #region Monobehaviour methods
        void Awake() {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate() {
            if (IsTouching()) {
                Touch touch = Input.GetTouch(0);
                Vector2 pos = touch.position;
                Vector2 dir = ((Vector2)Camera.main.WorldToScreenPoint(transform.localPosition) - pos) * -1;

                _force = (dir.normalized * _acceleration) + _force;
                _rigidBody.AddForce(_force);
            }
            else {
                _force = Vector2.zero;
            }
        }

        void OnCollisionEnter2D(Collision2D coll) {
            if (OnBallHit != null)
                OnBallHit();
        }
        #endregion
    }
}
