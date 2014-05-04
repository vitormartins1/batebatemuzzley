using UnityEngine;
using System.Collections;

public class BumperCarActionListener : CoreGamePadListener {

	private BumperCarController bumperCarController;

	void Awake() {
		bumperCarController = GetComponent<BumperCarController>();
	}

	public override void onJoystickPress (int angle)
	{
		bumperCarController.steer(angle);
		base.onJoystickPress (angle);
	}

	public override void onButonAPress ()
	{
		bumperCarController.accelerate(10);
		base.onButonAPress ();
	}
}
