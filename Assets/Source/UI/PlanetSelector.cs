using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace BallTest.UI {
    public class PlanetSelector : MonoBehaviour {
        #region private fields
        private Button _button;
        private string _name;
        #endregion

        #region Public methods and properties
        public void SetButton(string name) {
            _button.GetComponentInChildren<Text>().text = name;
            _name = name;
        }
        #endregion

        #region private methods
        private void LoadPlanet() {
            PlayerPrefs.SetString(Constants.PlayerPrefsKeys.planetName, _name);
            UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.Scenes.gameplay);
        }
        #endregion

        #region Monobehaviour
        void Awake() {
            _button = GetComponent<Button>();
            Assert.IsNotNull(_button, "[PlanetSelector] Cannot get Button component!!!");
            _button.onClick.AddListener(() => { LoadPlanet(); });
        }
        #endregion
    }
}
