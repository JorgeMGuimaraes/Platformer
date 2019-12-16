using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Core {
	/// <summary>
	/// Manages all core game actions. Loads and unloads scenes, FSMs.
	/// </summary>
	class GameManager : MonoBehaviour {
		#region Fields
		public string[] scenes;
		private int counter = 0;
		#endregion
		#region Methods
		private void Start() {
				StartCoroutine(StartGame());			
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartCoroutine(LoadYourAsyncScene());
			}
		}

		IEnumerator LoadYourAsyncScene() {
			// The Application loads the Scene in the background as the current Scene runs.
			// This is particularly good for creating loading screens.
			// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has a sceneBuildIndex of 1 as shown in Build Settings.
			var aUnload	= SceneManager.UnloadSceneAsync(scenes[counter]);
			while (!aUnload.isDone) { yield return null; }
			counter		= (counter + 1) % scenes.Length;
			var aLoad	= SceneManager.LoadSceneAsync(scenes[counter], LoadSceneMode.Additive);
			// Wait until the asynchronous scene fully loads
			while (!aLoad.isDone) { yield return null; }

		}

		IEnumerator StartGame() {
			var aLoad = SceneManager.LoadSceneAsync(scenes[counter], LoadSceneMode.Additive);
			while (!aLoad.isDone) { yield return null; }
		}
		#endregion
		#region Helpers

		#endregion
	}
}
