using UnityEngine;

namespace ProjectDew
{
    public static class Math
    {
        public const float Zero = 0f;
        public const float Quarter = 0.25f;
        public const float Half = 0.5f;
        public const float One = 1f;

        public const float Double = 2f;
        public const float Triple = 3f;

		public const float Hundred = 100f;

        public static float ClampMin(float value, float minValue) => (value < minValue) ? minValue : value;

        public static float ClampMax(float value, float maxValue) => (value > maxValue) ? maxValue : value;

        public static Vector3 GetDotVector(Vector3 vector, Vector3 direction)
        {
            direction.Normalize();
            return direction * Vector3.Dot(vector, direction);
        }
            
        public static Vector3 RemoveDotVector(Vector3 vector, Vector3 direction)
        {
            direction.Normalize();
            return vector - direction * Vector3.Dot(vector, direction);
        }
    }
}
