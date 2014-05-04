using UnityEngine;
using System.Collections;

public abstract class AbstractBumperCarController : MonoBehaviour {

	private BumperCarComponent bumperCar;

	[SerializeField]
	private WheelCollider wheelRearRight;
	[SerializeField]
	private WheelCollider wheelRearLeft;
	[SerializeField]
	private WheelCollider wheelFront;

	protected void initialize () {
		bumperCar = GetComponent<BumperCarComponent>();

		Transform wheelColliders = transform.FindChild("WheelColliders");
		wheelRearRight = wheelColliders.FindChild("WheelRearRight").GetComponent<WheelCollider>();
		wheelRearLeft = wheelColliders.FindChild("WheelRearLeft").GetComponent<WheelCollider>();
		wheelFront = wheelColliders.FindChild("WheelFront").GetComponent<WheelCollider>();
	}

	public virtual void accelerate(float motorTorque) {
		wheelRearLeft.motorTorque = getBumperCar().getMaxTorque() * motorTorque;
		wheelRearRight.motorTorque = getBumperCar().getMaxTorque() * motorTorque;
	}

	public virtual void decelerate(float motorTorque) {
	}

	public virtual void steer(int steerAngle) {
	}

	public BumperCarComponent getBumperCar() {
		return bumperCar;
	}

	public GameObject getGameObject() {
		return getBumperCar().gameObject;
	}
}
