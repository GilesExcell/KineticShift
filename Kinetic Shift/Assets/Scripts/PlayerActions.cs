using UnityEngine;
using System.Collections;
using InControl;

public class PlayerActions : PlayerActionSet {
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Jump;
	public PlayerAction Shift;
	public PlayerOneAxisAction Move;

	public PlayerActions()
	{
		Left = CreatePlayerAction( "Move Left" );
		Right = CreatePlayerAction( "Move Right" );
		Jump = CreatePlayerAction( "Jump" );
		Shift = CreatePlayerAction ("Kinetic Shift");
		Move = CreateOneAxisPlayerAction (Left, Right);
	}

	public static PlayerActions CreateWithDefaultBindings()
	{
		var playerActions = new PlayerActions();

		playerActions.Jump.AddDefaultBinding( Key.Space );
		playerActions.Jump.AddDefaultBinding( InputControlType.Action1 );
		
		playerActions.Left.AddDefaultBinding( Key.LeftArrow );
		playerActions.Right.AddDefaultBinding( Key.RightArrow );

		playerActions.Left.AddDefaultBinding( InputControlType.LeftStickLeft );
		playerActions.Right.AddDefaultBinding( InputControlType.LeftStickRight );

		playerActions.Left.AddDefaultBinding( InputControlType.DPadLeft );
		playerActions.Right.AddDefaultBinding( InputControlType.DPadRight );

		playerActions.Shift.AddDefaultBinding (Key.Shift);
		playerActions.Shift.AddDefaultBinding (InputControlType.Action2);

		return playerActions;
	}
}