using UnityEngine;

namespace BallTest.Model {
    [CreateAssetMenu(fileName = "new-PlanetsData", menuName = "BallTest/PlanetsData")]
    public class PlanetDataContainer : ScriptableObject {
        #region Serializable Data
        [SerializeField]
        private PlanetData[] _data;
        #endregion

        #region Public properties and methods
        public int Length {
            get {
                return _data.Length;
            }
        }

        public PlanetData GetByName(string name) {
            PlanetData data = System.Array.Find(_data, (x) => x.name == name);
            if (data == null)
                Debug.LogError("[PlanetDataContainer] Couldn't find any planet with name: " + name);
            return data;
        }

        public PlanetData GetByIndex(int index) {
            if (index < 0 || index >= _data.Length)
                return null;

            return _data[index];
        }
        #endregion

        [System.Serializable]
        public class PlanetData {
            public string name;
            public Color skyColor;
            public float gravity;
        }
    }
}
