using UnityEngine;
using System.Collections;
using InControl;

public class SpringActions : PlayerActionSet {
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerAction Shift;

	public SpringActions()
	{
		Left = CreatePlayerAction( "Left" );
		Right = CreatePlayerAction( "Right" );
		Up = CreatePlayerAction( "Up" );
		Down = CreatePlayerAction ("Down");
		Shift = CreatePlayerAction ("Kinetic Shift");
	}
	
	public static SpringActions CreateWithDefaultBindings()
	{
		var playerActions = new SpringActions();
		
		playerActions.Left.AddDefaultBinding( Key.LeftArrow );
		playerActions.Right.AddDefaultBinding( Key.RightArrow );
		playerActions.Up.AddDefaultBinding( Key.UpArrow );
		playerActions.Down.AddDefaultBinding( Key.DownArrow );

		playerActions.Left.AddDefaultBinding( InputControlType.LeftStickLeft );
		playerActions.Right.AddDefaultBinding( InputControlType.LeftStickRight );
		playerActions.Up.AddDefaultBinding( InputControlType.LeftStickUp );
		playerActions.Down.AddDefaultBinding( InputControlType.LeftStickDown );

		playerActions.Left.AddDefaultBinding( InputControlType.DPadLeft );
		playerActions.Right.AddDefaultBinding( InputControlType.DPadRight );
		playerActions.Up.AddDefaultBinding( InputControlType.DPadUp );
		playerActions.Down.AddDefaultBinding( InputControlType.DPadDown );

		playerActions.Shift.AddDefaultBinding (Key.Shift);
		playerActions.Shift.AddDefaultBinding (InputControlType.Action1);


		return playerActions;
	}
}
