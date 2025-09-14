using UnityEngine;

namespace ProjectDew
{
    public class ManagedGroup : ManagedBehaviour
    {
        [SerializeField]
        private ManagedBehaviour[] managedBehaviours;

		public override void ManagedAwake ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedAwake ();
		}
	
		public override void ManagedOnEnable ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedOnEnable ();
		}
	
		public override void ManagedStart ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedStart ();
		}
	
		public override void ManagedUpdate ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedUpdate ();
		}
	
		public override void ManagedFixedUpdate ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedFixedUpdate ();
		}
	
		public override void ManagedLateUpdate ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedLateUpdate ();
		}
	
		public override void ManagedOnDisable ()
		{
			for (int i = 0; i < managedBehaviours.Length; i++)
				managedBehaviours[i].ManagedOnDisable ();
		}
    }
}
