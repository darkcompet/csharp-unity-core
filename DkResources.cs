using UnityEngine;

namespace Tool.Compet.Core {
	public class DkResources {
		/// Load a resouce as text asset, then decode it to Json object.
		/// <param>path Relative path from `App/Resouces` directory, for eg,. "Countries", "Data/GameInfo".
		public static T LoadAsJsonObj<T>(string path) where T : class {
			return JsonUtility.FromJson<T>(Resources.Load<TextAsset>(path).text);
		}

		/// Load a resouce as game object.
		/// <param>path For eg,. `prefab_player_body`
		public static GameObject LoadAsGameObj(string path) {
			return Resources.Load<GameObject>(path);
		}

		public static GameObject InstantiatePrefab(string filePath, Transform targetGameObject, bool addAsChild = true) {
			Object prefabModel = Resources.Load(filePath);
			GameObject prefabGameObject = Object.Instantiate(prefabModel) as GameObject;
			if (addAsChild) {
				prefabGameObject.transform.parent = targetGameObject;
			}
			return prefabGameObject;
		}
	}
}
