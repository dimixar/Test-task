using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace BallTest.UI {
    public class MenuController : MonoBehaviour {
        #region Serialized Fields
        [SerializeField]
        private Text _jumpsText;

        [SerializeField]
        private Transform _buttonsGroupTransform;

        [SerializeField]
        private GameObject _buttonPrefab;

        [SerializeField]
        private Model.PlanetDataContainer _container;
        #endregion

        #region Private fields
        #endregion

        #region Monobehaviour methods
        void Awake() {
            Assert.IsNotNull(_jumpsText);
            Assert.IsNotNull(_buttonPrefab);
            Assert.IsNotNull(_buttonsGroupTransform);
            Assert.IsNotNull(_container);

            int jumps = PlayerPrefs.GetInt(Constants.PlayerPrefsKeys.nrOfJumps, 0);
            _jumpsText.text = "Jumps: " + jumps;

            for (int i = 0; i < _container.Length; i++) {
                GameObject inst = GameObject.Instantiate(_buttonPrefab, _buttonsGroupTransform);
                var selector = inst.GetComponent<PlanetSelector>();
                string planetName = _container.GetByIndex(i).name;
                selector.SetButton(planetName);
                inst.name = planetName + "-button";
            }
        }
        #endregion
    }
}
