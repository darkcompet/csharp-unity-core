namespace Tool.Compet.Core {
	using UnityEngine;

	public static class GameObjectExt {
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
