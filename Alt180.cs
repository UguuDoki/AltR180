using ICities;
using System;
using UnityEngine;

namespace AltR180
{
	public class Mod : IUserMod
	{
		public string Name => "AltR180";
		public string Description => "Have Alt+R reset camera to 180° instead." + Environment.NewLine + "Don't forget to reassign Alt+R in ACME to something else.";
	}

	public class Loading : LoadingExtensionBase
	{
		private GameObject _controller;

		public override void OnLevelLoaded(LoadMode mode)
		{
			_controller = new GameObject("AltR180Controller");
			_controller.AddComponent<CameraResetter>();
		}

		public override void OnLevelUnloading()
		{
			if (_controller != null)
			{
				GameObject.Destroy(_controller);
			}
		}
	}

	public class CameraResetter : MonoBehaviour
	{
		void Update()
		{
			// Alt + R
			if ((Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyDown(KeyCode.R))
			{
				CameraController controller = GameObject.FindObjectOfType<CameraController>();
				if (controller != null)
				{
					controller.m_targetAngle = new Vector2(180f, 90f);
				}
			}
		}
	}
}
