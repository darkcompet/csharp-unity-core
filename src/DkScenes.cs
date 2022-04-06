namespace Tool.Compet.Core {
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class DkScenes {
		/// Load scene from given scene name.
		public static void LoadScene(string sceneName) {
			SceneManager.LoadScene(sceneName);
		}

		/// Async load scene from given scene name.
		/// Caller should use returned-value to check completion event with `AsyncOperation.isDone`.
		public AsyncOperation LoadSceneAsync(string sceneName) {
			return SceneManager.LoadSceneAsync(sceneName);
		}

		/// @return Current active scene.
		public static Scene GetActiveScene() {
			return SceneManager.GetActiveScene();
		}
	}
}
