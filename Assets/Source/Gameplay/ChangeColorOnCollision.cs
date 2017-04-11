using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallTest.Gameplay {
    public class ChangeColorOnCollision : MonoBehaviour {
        #region private fields
        private SpriteRenderer _spriteRenderer;
        #endregion

        #region Private methods
        private Color GetRandomColor() {
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }
        #endregion

        #region Monobehaviour methods
        void Awake() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            UnityEngine.Assertions.Assert.IsNotNull(_spriteRenderer);

            _spriteRenderer.color = GetRandomColor();
        }

        void OnCollisionEnter2D(Collision2D coll) {
            _spriteRenderer.color = GetRandomColor();
        }
        #endregion
    }
}
