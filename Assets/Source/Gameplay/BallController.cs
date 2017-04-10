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
        #endregion

        #region Public methods and properties
        public void SetGravity(float gravity) {
            _rigidBody.gravityScale = gravity * -1;
        }
        #endregion

        #region Monobehaviour methods
        void Awake() {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D coll) {
            if (OnBallHit != null)
                OnBallHit();

            Vector2 force = Vector2.zero;
            force.y = _acceleration * _rigidBody.mass;

            _rigidBody.AddRelativeForce(force);
        }
        #endregion
    }
}
