using UnityEngine;
using System;	
using System.Collections;
using System.Collections.Generic;
using Muzzley;
using Muzzley.Net;

public class MuzzleyAppController : MonoBehaviour {

	public MuzzleyApp myMuzzleyApp;
	//public string qrcodeUrl;
	//public string activityId;
	private List<MuzzleyParticipant> participants;
	public bool showQr = true;

	public delegate void ActivityReady(MuzzleyActivity muzzleyActivity);
	public static event ActivityReady OnReady;

//	public delegate void ParticipantJoin(string currentWidget,
//	                                            string currentWidgetParams,
//	                                            string id,
//	                                            string name,
//	                                            string photoUrl,
//	                                            string profileId);

	public delegate void ParticipantJoin(MuzzleyAppParticipant muzzleyAppParticipant);
	public static event ParticipantJoin OnParticipantJoin;

	private static MuzzleyAppController instance;
	
	public static MuzzleyAppController Instance
    {
        get
        {
            return instance;
        }
    }

	void Awake()
    {
        instance = this;
    }

	void Start () {
		myMuzzleyApp = new MuzzleyApp();
		myMuzzleyApp.ConnectApp(OnActivityReady, "ddb0a998759d3469", null);
	}

	void Update () {
	}

	public void OnActivityReady(MuzzleyActivity activity)
	{
		Debug.Log(activity.QRCodeUrl);

		//qrcodeUrl = activity.QRCodeUrl;

    	activity.SetJoinHandler(OnJoin);
		activity.SetQuitHandler(OnQuit);
		activity.SetActionHandler(OnAction);

		//activityId = activity.ActivityId;

		OnReady(activity);
	}

	private void OnJoin(MuzzleyAppParticipant muzzley_participant)
	{
//		OnParticipantJoin(muzzley_participant.CurrentWidget,
//		                  muzzley_participant.CurrentWidgetParams,
//		                  muzzley_participant.Id,
//		                  muzzley_participant.Name,
//		                  muzzley_participant.PhotoUrl,
//		                  muzzley_participant.ProfileId);

		OnParticipantJoin(muzzley_participant);

		//muzzley_participant.ChangeWidget(MuzzleyConstants.Widgets.GAMEPAD, motion);
	}
	
	private void OnQuit(MuzzleyAppParticipant muzzley_participant)
	{
	}
	
	private void OnAction(MuzzleyAppAction muzzley_event)
	{	
		//muzzley_event.Participant.
//		if (muzzley_event.Data["c"].ToString() == "jl")
//				participantes[muzzley_event.Participant.Id].MuzzleyInputRotacao(muzzley_event.Data["v"].ToString(), muzzley_event.Data["e"].ToString());
//		
//		if (muzzley_event.Data["c"].ToString() == "bc")
//			participantes[muzzley_event.Participant.Id].MuzzleyInputAceleracao(muzzley_event.Data["e"].ToString());
//		
//		if (muzzley_event.Data["c"].ToString() == "bb")
//			participantes[muzzley_event.Participant.Id].MuzzleyInputRe(muzzley_event.Data["e"].ToString());
	}

	void callJoinListener() {
		//MuzzleyJoinListener m[] = GameObject.FindObjectsOfType(MuzzleyJoinListener);

		//for (int i = 0; i < m.Lenght; i++) {
		//	m[i].onMuzzleyParticipantJoin();
		//}
	}
}
