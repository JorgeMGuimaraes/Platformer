namespace Assets.Code.Core {
	using UnityEngine;
	public interface MapActions {
		/// <summary> State update.</summary>
		void doUpdate();
	}
	public class MapWaitInput : MapActions {
		#region Fields
		public MapManager map;
		#endregion
		#region Methods
	/// <summary>Waits for player input.</summary>
		public MapWaitInput(MapManager map) {
			this.map = map;
		}
		public void doUpdate() => ChangeToMoveState();
		#endregion
		#region Helpers
		/// <summary>Checks if player gave a valid direction to move player icon.</summary>
		/// <returns>A <see cref="Directions"/> direction. </returns>
		private Directions GetDirection() {
			if		(Input.GetAxis("Horizontal") * 10 > 0)	{ return Directions.Right; }
			else if (Input.GetAxis("Horizontal") * 10 < 0)	{ return Directions.Left; }
			else if (Input.GetAxis("Vertical") * 10 > 0)	{ return Directions.Up; }
			else if (Input.GetAxis("Vertical") * 10 < 0)	{ return Directions.Down; }
			return Directions.None;
		}
		/// <summary> Change to MoveIcon state if proper command is sent.</summary>
		private void ChangeToMoveState() {
			var dir = GetDirection();
			if (dir != Directions.None) {
				for (int i = 0; i < 20; i++) {
					if (map.moveGraph[map.pointCounter, i] == dir) {
						map.pointCounter = i;
#if DEBUG_FLAG_
						MonoBehaviour.print("Node " + map.pointCounter + " | " + dir);
#endif
						map.ChangeToMoveIcon();
						return;
					}
				}
			}
		}
		#endregion
	}

	public class MapMoveIcon : MapActions {
		#region Fields
		public MapManager map;
		#endregion
		/// <summary>Move player icon around map nodes.</summary>
		public MapMoveIcon(MapManager map) {
			this.map = map;
		}
		public void doUpdate() {		
			iTween.MoveTo(map.playerIcon, iTween.Hash("position", map.nodes[map.pointCounter].position, "speed", map.iconSpeed, "easetype", "linear", "oncomplete", "ChangeToWaitInput", "oncompletetarget", map.gameObject));
		}
	}
}
