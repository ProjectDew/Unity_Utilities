using UnityEngine;

namespace ProjectDew
{
    [CreateAssetMenu (fileName = EditorConstants.TimerName, menuName = EditorConstants.TimerPath, order = EditorConstants.TimerOrder)]
    public class TimerData : ScriptableObject
    {
        [SerializeField]
        private float offsetTime;

        [SerializeField]
        private float duration;

        public float OffsetTime => offsetTime;

        public float Duration => duration;

		public override string ToString() => $"Timer Data {{ Offset: {offsetTime:F2} | Duration: {duration:F2} }}";
    }
}
