using UnityEngine;
using System.Collections;

public abstract class CoreGamePadListener : MonoBehaviour {

	private string muzzleyId;

	protected void initialize(string id) {
		muzzleyId = id;
	}

	public virtual void onJoystickPress(float angle, float radius) {}

	public virtual void onJoystickRelease(float angle, float radius) {}

	public virtual void onJoystickPress(int angle) {}
	
	public virtual void onJoystickRelease(int angle) {}

	public virtual void onButonAPress() {}

	public virtual void onButonARelease() {}

	public virtual void onButonBPress() {}

	public virtual void onButonBRelease() {}

	public virtual void onButonCPress() {}

	public virtual void onButonCRelease() {}

	public virtual void onButonDPress() {}

	public virtual void onButonDRelease() {}

	public string getMuzzleyID() {
		return muzzleyId;
	}

	public void setMuzzleyId(string id) {
		muzzleyId = id;
	}
}