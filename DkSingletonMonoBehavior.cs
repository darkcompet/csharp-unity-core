namespace Tool.Compet.Core {
	using UnityEngine;

	/// Make singleton monobehavior which supports co-routine.
	public class DkSingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour {
		/// Indicate singleton object should be retained across scenes or not
		protected static bool retainsAcrossScenes = true;

		private static T defaultInstance;

		private static bool applicationIsQuitting = false;

		/// Lock for sync create singleton
		private static readonly object sharedLock = new();

		// [NonNull]
		public static T instance {
			get {
				var type = typeof(T);

				// Don't create singleton object while app is quiting
				if (applicationIsQuitting) {
					Debug.LogWarning($"(DkSingleton<{type}>) Should not call this since the application is quitting.");
					// return null;
				}

				lock (sharedLock) {
					if (defaultInstance == null) {
						defaultInstance = (T)FindObjectOfType(type); // Find first active object

						if (DkBuildConfig.DEBUG) {
							if (FindObjectsOfType(type).Length > 1) { // Find all objects
								Debug.LogWarning($"(DkSingleton<{type}>) Oops, should never be more than 1 singleton! Reopen the scene might fix it.");
								return defaultInstance;
							}
						}

						if (defaultInstance == null) {
							var newIns = defaultInstance = new GameObject($"(DkSingleton) {type.ToString()}").AddComponent<T>();
							if (retainsAcrossScenes) {
								Object.DontDestroyOnLoad(newIns);
							}
							if (DkBuildConfig.DEBUG) {
								Debug.Log($"singleton<{type}>-monobehavior~ created defaultInstance: {defaultInstance?.name}");
							}
						}
					}

					return defaultInstance;
				}
			}
		}

		/// <summary>
		/// When Unity quits, it destroys objects in a random order.
		/// In principle, a Singleton is only destroyed when application quits.
		/// If any script calls Instance after it have been destroyed,
		///   it will create a buggy ghost object that will stay on the Editor scene
		///   even after stopping playing the Application. Really bad!
		/// So, this was made to be sure we're not creating that buggy ghost object.
		/// </summary>
		public void OnDestroy() {
			this.CancelInvoke();
			this.StopAllCoroutines();

			applicationIsQuitting = true;
		}
	}
}
