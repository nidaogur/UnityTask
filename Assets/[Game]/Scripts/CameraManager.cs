using System.Collections;
using _Game_.Scripts.Utilities;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace _Game_.Scripts
{
    public class CameraManager : MonoSingleton<CameraManager>
    {
	    [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private Camera mainCamera;
        
        public Camera MainCamera
        {
            get
            {
                if (mainCamera == null) mainCamera = Camera.main;
                return mainCamera;
            }
        }
        
        private CinemachineBasicMultiChannelPerlin perlin;

		private float startingIntensity;
		private float shakeTimer;
		private float shakeTimerTotal;


		private Coroutine shakeCoroutine;

		public void Awake()
		{
			perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
			perlin.m_AmplitudeGain = 0;
		}

		public void OnDisable()
		{
			shakeTimer = 0;
			perlin.m_AmplitudeGain = 0;
			if (shakeCoroutine != null)
				StopCoroutine(shakeCoroutine);
		}
		
		public void Shake(float intensity, float duration, bool isSmooth = true)
		{
			perlin.m_AmplitudeGain = intensity;

			startingIntensity = intensity;
			shakeTimer = duration;
			shakeTimerTotal = duration;

			if (shakeCoroutine != null)
				StopCoroutine(shakeCoroutine);
			shakeCoroutine = StartCoroutine(ShakeCoroutine(isSmooth));
		}
		
		public void Shake(float intensity, float frequency, float duration, bool isSmooth = true)
		{
			perlin.m_FrequencyGain = frequency;

			Shake(intensity, duration, isSmooth);
		}

		private IEnumerator ShakeCoroutine(bool isSmooth)
		{
			while (shakeTimer > 0)
			{
				shakeTimer -= Time.deltaTime;

				if (isSmooth)
					perlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0, 1 - (shakeTimer / shakeTimerTotal));
				else
				{
					if (shakeTimer <= 0)
						perlin.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0, 1 - (shakeTimer / shakeTimerTotal));
				}

				yield return null;
			}

			perlin.m_AmplitudeGain = 0;
			perlin.m_FrequencyGain = 1;
		}
    }
}