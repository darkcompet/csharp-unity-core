using UnityEngine;

namespace Tool.Compet.Core {
	public class DkViews {
		/**
		 * Destroy all child inside given GameObject.
		 */
		public static void ClearChildren(GameObject go) {
			foreach (Transform child in go.transform) {
				Object.Destroy(child.gameObject);
			}
		}
	
		/**
		 * Create new child from given params, and add that child as children to given parent.
		 *
		 * @param parent Can be null.
		 * @param originalChild Be used to clone new child. Normally, it is object from a prefab.
		 */
		public static GameObject AddChild(GameObject parent, GameObject originalChild, float scale = -1f, Transform position = null) {
			GameObject newChild;
	
			if (parent == null) {
				newChild = Object.Instantiate(originalChild);
			}
			else {
				newChild = Object.Instantiate(originalChild, parent.transform.position, parent.transform.rotation, parent.transform);
			}
	
			newChild.transform.localRotation = Quaternion.Euler(0, 0, 0);
	
			if (scale == -1f) {
				newChild.transform.localScale = originalChild.transform.localScale;
			}
			else {
				newChild.transform.localScale = new Vector3(scale, scale, scale);
			}
	
			if (position == null) {
				newChild.transform.localPosition = Vector3.zero;
			}
			else {
				newChild.transform.position = position.position;
			}
	
			return newChild;
		}
	}
}
