using UnityEngine;
using System.Collections;

public abstract class MuzzleyParticipant : MonoBehaviour {

	private string muzzleyId;

	protected void initialize(string id) {
		muzzleyId = id;
	}

	protected void onJoystickPress(float angle, float radius) {

	}

	protected void onJoystickRelease(float angle, float radius) {
		
	}

	protected void onButonAPress() {
		
	}

	protected void onButonARelease() {
		
	}

	protected void onButonBPress() {
		
	}

	protected void onButonBRelease() {
		
	}

	protected void onButonCPress() {
		
	}

	protected void onButonCRelease() {
		
	}

	protected void onButonDPress() {
		
	}

	protected void onButonDRelease() {
		
	}

	public string getMuzzleyID() {
		return muzzleyId;
	}

	void Start () {
	
	}

	void Update () {
	
	}
}