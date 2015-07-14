using UnityEngine;
using System.Collections;

public class BumperCarActionListener : CoreGamePadListener {

//	private BumperCarController bumperCarController;
	private BumperCarMuzzley bumperCarMuzzley;

	void Awake() {
//		bumperCarController = GetComponent<BumperCarController>();
		bumperCarMuzzley = GetComponent<BumperCarMuzzley>();
	}

	public override void onJoystickPress (int angle, float radius)
	{
		Debug.Log("On Joystick Press. Angle: " + angle.ToString());
		bumperCarMuzzley.MuzzleyInputRotacao(angle);
		bumperCarMuzzley.setMuzzleyInputAcceleration(radius);
//		bumperCarController.steer(angle);
		base.onJoystickPress (angle, radius);
	}

	public override void onButonAPress ()
	{
//		Debug.Log("On ButtonA Press");
//		bumperCarController.accelerate(2);
//		bumperCarController.setAcelerating(true);
		base.onButonAPress ();
	}

	public override void onButonARelease ()
	{
//		bumperCarController.setAcelerating(false);
		base.onButonARelease ();
	}

	public override void onButonBPress ()
	{
//		Debug.Log("b");
		base.onButonBPress ();
	}

	public override void onButonBRelease ()
	{
		base.onButonBRelease ();
	}
}
