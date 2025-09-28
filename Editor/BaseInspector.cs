using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ProjectDew.CharacterController
{
	public abstract class BaseInspector : Editor
    {
		[SerializeField]
		private VisualTreeAsset treeAsset;

		public override VisualElement CreateInspectorGUI()
		{
			if (treeAsset == null)
			{
				return base.CreateInspectorGUI();
			}

			VisualElement root = new();

			treeAsset.CloneTree(root);

			return root;
		}
    }
}
