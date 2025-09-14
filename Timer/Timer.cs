using System;
using UnityEngine;

namespace ProjectDew
{
	public class Timer
	{
		public enum State
		{
			Starting,
			Running,
			Paused,
			Stopped
		}
		
		public event Action<float, int> OnStart;
		public event Action<float, int> OnPause;
		public event Action<float, int> OnResume;
		public event Action<float, int> OnStop;

		private State currentState;

		private float currentOffsetTime;
		private float nextStopPoint;
	
		public float OffsetTime { get; }

		public float CurrentTime { get; private set; }

		public float TimeLimit { get; private set; }

		public float TimeLeft => TimeLimit - CurrentTime;

		public int Iterations { get; private set; }

		public bool IsRunning => currentState == State.Running;

		public bool IsPaused => currentState == State.Paused;

		public bool IsStopped => currentState == State.Stopped;

		public Timer(TimerData timerData) : this(timerData.OffsetTime, timerData.Duration) { }
	
		public Timer(float duration) : this(0, duration) { }
	
		public Timer(float offsetTime, float duration)
		{
			OffsetTime = offsetTime;

			TimeLimit = duration;

			Reset();
		}

		public override string ToString() => $"Timer {{ Current time: {CurrentTime:F2} | Time limit: {TimeLimit:F2} | Iterations: {Iterations} }}";

		public bool Play() => Play(null, TimerMode.Timer);

		public bool Play(TimerMode timerMode) => Play(null, timerMode);

		public bool Play(Action action) => Play(action, TimerMode.Timer);

		public bool Play(Action action, TimerMode timerMode)
		{
			if (currentState == State.Paused || currentState == State.Stopped)
			{
				return false;
			}

			if (currentOffsetTime < OffsetTime)
			{
				currentOffsetTime += Time.deltaTime;
				return false;
			}

			if (currentState == State.Starting)
			{
				Reset();

				OnStart?.Invoke(CurrentTime, Iterations);

				currentState = State.Running;
			}

			CurrentTime += Time.deltaTime;

			if (CurrentTime >= nextStopPoint)
			{
				Iterations++;
				
				action?.Invoke();
				
				switch (timerMode)
				{
					case TimerMode.Timer:
						Stop();
						break;

					case TimerMode.Stopwatch:
						nextStopPoint = TimeLimit + TimeLimit * Iterations;
						break;
						
					case TimerMode.StopwatchReset:
						CurrentTime = 0;
						break;
				}
				
				return true;
			}

			return false;
		}

		public void Pause()
		{
			currentState = State.Paused;
			OnPause?.Invoke(CurrentTime, Iterations);
		}

		public void Resume()
		{
			currentState = State.Running;
			OnResume?.Invoke(CurrentTime, Iterations);
		}

		public void Stop()
		{
			currentState = State.Stopped;
			OnStop?.Invoke(CurrentTime, Iterations);
		}

		public void Reset(bool stopTimer = false)
		{
			currentOffsetTime = 0;
			nextStopPoint = TimeLimit;

			CurrentTime = 0;
			Iterations = 0;
			
			if (stopTimer)
			{
				Stop();
			}
			else
			{
				currentState = State.Starting;
			}
		}
	}
}
