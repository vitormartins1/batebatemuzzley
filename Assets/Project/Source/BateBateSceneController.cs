using UnityEngine;
using System.Collections;
using Muzzley;
using Muzzley.Net;

public class BateBateSceneController : MonoBehaviour {

	private MuzzleyAppController muzzleyAppController;

	[SerializeField]
	private GameObject bumperCarPrefab;

	void Awake() {
		MuzzleyAppController.OnParticipantJoin += OnMuzzleyPartipantJoin;
	}

	void Start () {
		
	}

	void Update () {
	
	}

//	public void OnMuzzleyPartipantJoin(string currentWidget,
//	                                   string currentWidgetParams,
//	                                   string id,
//	                                   string name,
//	                                   string photoUrl,
//	                                   string profileId) {

	public void OnMuzzleyPartipantJoin(MuzzleyAppParticipant participant) {
		Debug.Log("participant join!");

		//GameObject bumperCar = (GameObject)Instantiate(bumperCarPrefab);
//
//		muzzleyAppController.addParticipant(bumperCar.GetComponent<CoreGamePadListener>());
	}
}
