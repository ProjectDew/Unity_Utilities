using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectDew
{
	public static class ExtensionMethods
	{
		public static float Quarter(this float value) => value * Math.Quarter;

		public static float Half(this float value) => value * Math.Half;

		public static float Double(this float value) => value * Math.Double;

		public static float Triple(this float value) => value * Math.Triple;

		public static float ClampMin(this float value, float minValue) => (value > minValue) ? value : minValue;

		public static float ClampMax(this float value, float maxValue) => (value < maxValue) ? value : maxValue;
		
		public static Vector3 Quarter(this Vector3 value) => value * Math.Quarter;

		public static Vector3 Half(this Vector3 value) => value * Math.Half;

		public static Vector3 Double(this Vector3 value) => value * Math.Double;

		public static Vector3 Triple(this Vector3 value) => value * Math.Triple;

		public static Vector3 GetDot(this Vector3 value, Vector3 direction)
		{
			direction.Normalize();
			return direction * Vector3.Dot(value, direction);
		}

		public static int ToInt(this LayerMask layerMask)
		{
			int binary = layerMask.value;

			if (binary == 0)
			{
				return binary;
			}

			int integer = -1;

			while(binary > 0)
			{
				binary = binary >> 1;
				integer++;
			}

			return integer;
		}

		public static Vector3 RemoveDot(this Vector3 value, Vector3 direction)
		{
            direction.Normalize();
			return value - direction * Vector3.Dot(value, direction);
		}

		public static void AssignValues<T>(this IList<T> list, Func<int, T> assignValue)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = assignValue.Invoke (i) ?? default;
			}
		}

		public static T[] GetDeepCopy<T>(this T[] array) => array.Select(e => e).ToArray();

		public static IList<T> GetDeepCopy<T>(this IList<T> list) => list.Select(e => e).ToList();

		public static IEnumerable<T> GetDeepCopy<T>(this IEnumerable<T> enumerable) => enumerable.Select(e => e);

		public static void AssignValues<T>(this IList<IList<T>> list, Func<int, IList<T>> assignRow, Func<int, int, T> assignColumn)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = assignRow.Invoke(i) ?? default;

				for (int j = 0; j < list[i].Count; j++)
				{
					list[i][j] = assignColumn.Invoke(i, j) ?? default;
				}
			}
		}

		public static void Loop<T>(this IList<T> list, Action<int, T> performAction)
		{
			for (int i = 0; i < list.Count; i++)
			{
				performAction(i, list[i]);
			}
		}

		public static void Loop<T>(this IList<IList<T>> list, Action<int, int, T> performAction)
		{
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list[i].Count; j++)
				{
					performAction(i, j, list[i][j]);
				}
			}
		}

		public static void Loop<T>(this IEnumerable<T> enumerable, Action<T> performAction)
		{
			foreach (T item in enumerable)
			{
				performAction (item);
			}
		}
	}
}
