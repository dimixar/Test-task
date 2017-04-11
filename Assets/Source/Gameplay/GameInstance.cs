using UnityEngine;
using UnityEngine.Assertions;

namespace BallTest.Gameplay
{
    public class GameInstance : MonoBehaviour {
        #region Serialized fields
        [SerializeField]
        private BallController _ballController;

        [SerializeField]
        private Model.PlanetDataContainer _container;
        #endregion

        #region Private fields
        private int _jumps;
        private string _planetName;
        #endregion

        #region Monobehaviour methods
        void Awake() {
            Assert.IsNotNull(_container);
            Assert.IsNotNull(_ballController);

            _jumps = PlayerPrefs.GetInt(Constants.PlayerPrefsKeys.nrOfJumps, 0);
            _planetName = PlayerPrefs.GetString(Constants.PlayerPrefsKeys.planetName, "Earth");
            Model.PlanetDataContainer.PlanetData data = _container.GetByName(_planetName);
            Camera.main.backgroundColor = data.skyColor;

            _ballController.OnBallHit += OnBallHit_handler;
            _ballController.SetGravity(data.gravity);
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                PlayerPrefs.SetInt(Constants.PlayerPrefsKeys.nrOfJumps, _jumps);
                PlayerPrefs.Save();
                UnityEngine.SceneManagement.SceneManager.LoadScene(Constants.Scenes.menu);
            }
        }
        #endregion

        #region BallController event handlers
        private void OnBallHit_handler() {
            _jumps += 1;
        }
        #endregion
    }
}
