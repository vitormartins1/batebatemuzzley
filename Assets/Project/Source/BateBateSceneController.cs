using UnityEngine;
using System.Collections;
using Muzzley;
using Muzzley.Net;

public class BateBateSceneController : MonoBehaviour {

	private MuzzleyAppController muzzleyAppController;

	[SerializeField]
	private GameObject bumperCarPrefab;

	[SerializeField]
	private bool createCar = false;

	private string currentId;

	void Awake() {
		MuzzleyAppController.OnParticipantJoin += OnMuzzleyPartipantJoin;
		muzzleyAppController = GameObject.Find("MuzzleyAppController").GetComponent<MuzzleyAppController>();
	}

	void Start () {
		
	}

	void Update () {
		if (createCar) {
			GameObject bumperCar = (GameObject)Instantiate(bumperCarPrefab);	

			CoreGamePadListener gamePadListener = bumperCar.GetComponent<CoreGamePadListener>();
			gamePadListener.setMuzzleyId(currentId);
			muzzleyAppController.addParticipant(gamePadListener);
			currentId = null;
			createCar = false;
		}
	}

//	public void OnMuzzleyPartipantJoin(string currentWidget,
//	                                   string currentWidgetParams,
//	                                   string id,
//	                                   string name,
//	                                   string photoUrl,
//	                                   string profileId) {

	public void OnMuzzleyPartipantJoin(MuzzleyAppParticipant participant) {
		Debug.Log("Participant with id = " + participant.Id + " joined!");
		currentId = participant.Id;
		createCar = true;

		//GameObject bumperCar = (GameObject)Instantiate(bumperCarPrefab);
//
//		muzzleyAppController.addParticipant(bumperCar.GetComponent<CoreGamePadListener>());
	}
}
