using UnityEngine;
using System.Collections;
using InControl;

public class BallActions : PlayerActionSet {
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerAction Jump;
	public PlayerAction Shift;
	public PlayerAction Brake;
	public PlayerOneAxisAction Move;
	public PlayerTwoAxisAction JumpDirection;

	public BallActions()
	{
		Left = CreatePlayerAction( "Move Left" );
		Right = CreatePlayerAction( "Move Right" );
		Up = CreatePlayerAction( "Move Up" );
		Down = CreatePlayerAction( "Move Down" );
		Jump = CreatePlayerAction( "Jump" );
		Shift = CreatePlayerAction ("Kinetic Shift");
		Brake = CreatePlayerAction ("Brake");
		Move = CreateOneAxisPlayerAction (Left, Right);
		JumpDirection = CreateTwoAxisPlayerAction (Left, Right, Down, Up);
	}

	public static BallActions CreateWithDefaultBindings()
	{
		var playerActions = new BallActions();

		playerActions.Jump.AddDefaultBinding( Key.Space );
		playerActions.Jump.AddDefaultBinding( InputControlType.Action1 );

		playerActions.Brake.AddDefaultBinding (Key.LeftShift);
		playerActions.Brake.AddDefaultBinding (InputControlType.Action2); 
		
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
		playerActions.Shift.AddDefaultBinding (InputControlType.Action2);

		return playerActions;
	}
}