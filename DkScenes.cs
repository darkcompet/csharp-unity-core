namespace Tool.Compet.Core {
	public class DkScenes {
		public static void LoadScene(string sceneName) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
		}
	
		public async void LoadSceneAsync(string sceneName) {
			await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
		}
	
		public static string GetActiveScene() {
			return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; // "Menu"
		}
	}
}
