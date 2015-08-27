using UnityEngine;
using System.Collections;
using InControl;

public class BallActions : PlayerActionSet {
	public PlayerAction RollLeft;
	public PlayerAction RollRight;
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerAction Jump;
	public PlayerAction Shift;
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
		RollLeft = CreatePlayerAction ("Roll Left");
		RollRight = CreatePlayerAction ("Roll Right");
		Move = CreateOneAxisPlayerAction (Left, Right);
		JumpDirection = CreateTwoAxisPlayerAction (Left, Right, Down, Up);

	}

	public static BallActions CreateWithDefaultBindings()
	{
		var playerActions = new BallActions();

		playerActions.Jump.AddDefaultBinding( Key.Space );
		playerActions.Jump.AddDefaultBinding( InputControlType.Action1 );

		playerActions.RollLeft.AddDefaultBinding (InputControlType.LeftTrigger);
		playerActions.RollRight.AddDefaultBinding (InputControlType.RightTrigger);
		
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