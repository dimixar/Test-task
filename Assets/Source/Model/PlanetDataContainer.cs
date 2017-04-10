using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallTest {
    [CreateAssetMenu(fileName = "new-PlanetsData", menuName = "BallTest/PlanetsData")]
    public class PlanetDataContainer : ScriptableObject {
        #region Serializable Data
        [SerializeField]
        private PlanetData[] _data;
        #endregion

        #region Private fields
        #endregion

        #region Public properties and methods
        #endregion

        [System.Serializable]
        public class PlanetData {
            public string name;
            public Color skyColor;
            public float gravity;
        }
    }
}
