
namespace Assets.Code.Core {
	#region Usings
	using UnityEngine;
	#endregion
	public enum Directions {
		None,
		Left,
		Up,
		Right,
		Down
	}
	public class MapManager : MonoBehaviour {
		#region Fields
		public float iconSpeed;
		public	GameObject		playerIconPrefab;
		public	Transform		startPoint;
		public Directions[,]	moveGraph					= new Directions[,] {
			{Directions.None, Directions.Right, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.Left, Directions.None, Directions.Up, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.Down, Directions.None, Directions.Right, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.Left, Directions.None, Directions.Down, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.Up, Directions.None, Directions.Right, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Down, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.Left, Directions.None, Directions.Right, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Left, Directions.None, Directions.Down, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Up, Directions.None, Directions.Down, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Up, Directions.None, Directions.Left, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Right, Directions.None, Directions.Left, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.Up, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Right, Directions.None, Directions.Down, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Up, Directions.None, Directions.Left, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Right, Directions.None, Directions.Left, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Right, Directions.None, Directions.Down, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Up, Directions.None, Directions.Right, Directions.None, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Left, Directions.None, Directions.Up, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Down, Directions.None, Directions.Left, Directions.Right, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Right, Directions.None, Directions.None, Directions.None},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Left, Directions.None, Directions.None, Directions.Right},
			{Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.None, Directions.Left, Directions.None} }; public Transform[]		nodes;
		public int				pointCounter { get; set; }	= 0;

		public GameObject		playerIcon;
		private MapActions
			active,
			waitInput,
			moveIcon;
		#endregion
		#region Methods
		private void Start() {
#if DEBUG_FLAG_
			print("Map");
#endif
			waitInput	= new MapWaitInput(this);
			moveIcon	= new MapMoveIcon(this);
			active		= waitInput;
			playerIcon	= Instantiate(playerIconPrefab, startPoint.position, startPoint.rotation, gameObject.transform);
		}
		private void Update() => active.doUpdate();
		/// <summary> Change current state to MoveIcon</summary>
		public void ChangeToMoveIcon() =>	active = moveIcon;
		/// <summary> Change current state to WaitInput</summary>
		public void ChangeToWaitInput() =>	active = waitInput;
		#endregion
		#region Helpers

		#endregion
	}

}
