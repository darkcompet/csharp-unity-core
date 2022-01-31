namespace Tool.Compet.Core {
	using UnityEngine;
	using System.Collections;

	public static class MonoBehaviourExt {
		/// Start coroutine to wait given seconds.
		public static void PostDelayDk(this MonoBehaviour me, float delaySeconds, System.Action onComplete = null, bool runWithTimeScale = true) {
			IEnumerator MyRoutine() {
				if (runWithTimeScale) {
					yield return new WaitForSeconds(delaySeconds);
				}
				else {
					// Below code is explanation for unscaled time `WaitForSecondsRealtime`
					// var start = Time.realtimeSinceStartup;
					// while (Time.realtimeSinceStartup - start < time) {
					// 	yield return null;
					// }
					// Or we can use below code for shorter
					yield return new WaitForSecondsRealtime(delaySeconds);
				}

				onComplete?.Invoke();
			};

			me.StartCoroutine(MyRoutine());
		}

		/// Repeat invoke a function (note that, function name should be get via `nameof(XXX)`).
		public static void InvokeRepeatingDk(this MonoBehaviour me, string methodName, float repeatRate, float delaySeconds = 0.1f) {
			me.InvokeRepeating(methodName, delaySeconds, repeatRate);
		}

		/// Cancel invoke a function (note that, function name should be get via `nameof(XXX)`).
		public static void CancelInvokeDk(this MonoBehaviour me, string methodName) {
			me.CancelInvoke(methodName);
		}

		/// Checks if a GameObject has been destroyed.
		/// @param `gameObject` GameObject reference to check for destructedness.
		/// @returns If the game object has been marked as destroyed by UnityEngine.
		public static bool IsDestroyedDk(this GameObject me) {
			// UnityEngine overloads the == opeator for the GameObject type
			// and returns null when the object has been destroyed, but
			// actually the object is still there but has not been cleaned up yet
			// if we test both we can determine if the object has been destroyed.
			return me == null && !ReferenceEquals(me, null);
		}
	}
}
