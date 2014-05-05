using UnityEngine;
using System.Collections;

public class BumperCarController : AbstractBumperCarController {
	
	void Awake () {
		initialize();
	}

	void Start () {

	}

	void FixedUpdate() {

//		if (isAcelerating()) {
//			wheelRearLeft.motorTorque = getBumperCar().getMaxTorque() * getMotorTorque();
//			wheelRearRight.motorTorque = getBumperCar().getMaxTorque() * getMotorTorque();
//		} else if (getMotorTorque() > 0) {
//			setMotorTorque(getMotorTorque() - getDesacelerationValue());
//		}


		wheelRearLeft.motorTorque = getBumperCar().getMaxTorque() * getMotorTorque();
		wheelRearRight.motorTorque = getBumperCar().getMaxTorque() * getMotorTorque();

		if (!isAcelerating()) {
			if (getMotorTorque() - getDesacelerationValue() <= 0) {
				setMotorTorque(0);
			} else {
				setMotorTorque(getMotorTorque() - getDesacelerationValue());
			}
		}
	}

	void Update () {
		if (Input.GetKey(KeyCode.Y)) {
			wheelFront.steerAngle -= 0.5f;
		}

		if (Input.GetKey(KeyCode.U)) {
			wheelFront.steerAngle += 0.5f;
		}
	}
}
