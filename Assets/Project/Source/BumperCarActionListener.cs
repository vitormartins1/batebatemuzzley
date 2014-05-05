using UnityEngine;
using System.Collections;

public class BumperCarActionListener : CoreGamePadListener {

	private BumperCarController bumperCarController;

	void Awake() {
		bumperCarController = GetComponent<BumperCarController>();
	}

	public override void onJoystickPress (int angle)
	{
		Debug.Log("On Joystick Press");
		bumperCarController.steer(angle);
		base.onJoystickPress (angle);
	}

	public override void onButonAPress ()
	{
		Debug.Log("On ButtonA Press");
		bumperCarController.accelerate(1);
		bumperCarController.setAcelerating(true);
		base.onButonAPress ();
	}

	public override void onButonARelease ()
	{
		bumperCarController.setAcelerating(false);
		base.onButonARelease ();
	}
}
