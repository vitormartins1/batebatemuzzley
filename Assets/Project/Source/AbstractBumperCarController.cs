using UnityEngine;
using System.Collections;

public abstract class AbstractBumperCarController : MonoBehaviour {

	private BumperCarComponent bumperCar;

	[SerializeField]
	private float motorTorque;
	[SerializeField]
	private float maxSteerAngle;
	[SerializeField]
	private float desacelerationValue;

	[SerializeField]
	private bool accelerating = false;

	[SerializeField]
	protected WheelCollider wheelRearRight;
	[SerializeField]
	protected WheelCollider wheelRearLeft;
	[SerializeField]
	protected WheelCollider wheelFront;

	protected void initialize () {
		bumperCar = GetComponent<BumperCarComponent>();

		Transform wheelColliders = transform.FindChild("WheelColliders");
		wheelRearRight = wheelColliders.FindChild("WheelRearRight").GetComponent<WheelCollider>();
		wheelRearLeft = wheelColliders.FindChild("WheelRearLeft").GetComponent<WheelCollider>();
		wheelFront = wheelColliders.FindChild("WheelFront").GetComponent<WheelCollider>();
	}

	public virtual void accelerate(float motorTorque) {
		this.motorTorque = motorTorque;
		accelerating = true;

	}

	public virtual void decelerate(float motorTorque) {
	}

	public virtual void steer(int steerAngle) {


		//wheelFront.steerAngle = 
	}

	public BumperCarComponent getBumperCar() {
		return bumperCar;
	}

	protected void setMotorTorque(float value) {
		motorTorque = value;
	}

	public float getMotorTorque() {
		return motorTorque;
	}

	public float getDesacelerationValue() {
		return desacelerationValue;
	}

	public bool isAcelerating() {
		return accelerating;
	}

	public void setAcelerating(bool value) {
		accelerating = value;
	}

	public GameObject getGameObject() {
		return getBumperCar().gameObject;
	}
}
