using UnityEngine;
using System;	
using System.Collections;
using System.Collections.Generic;
using Muzzley;
using Muzzley.Net;

public class MuzzleyController : MonoBehaviour {

	public MuzzleyApp myMuzzleyApp;
	public string qrcodeUrl;
	public string activityId;

	public bool showQr = true;

	public delegate void ActivityReady();
	public static event ActivityReady OnReady;

	private static MuzzleyController instance;
	
	public static MuzzleyController Instance
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

		qrcodeUrl = activity.QRCodeUrl;

    	activity.SetJoinHandler(OnJoin);
		activity.SetQuitHandler(OnQuit);
		activity.SetActionHandler(OnAction);

		activityId = activity.ActivityId;

		OnReady();
	}

	private void OnJoin(MuzzleyAppParticipant muzzley_participant)
	{
		//muzzley_participant.ChangeWidget(MuzzleyConstants.Widgets.GAMEPAD, motion);
	}
	
	private void OnQuit(MuzzleyAppParticipant muzzley_participant)
	{
	}
	
	private void OnAction(MuzzleyAppAction muzzley_event)
	{
//		if (muzzley_event.Data["c"].ToString() == "jl")
//				participantes[muzzley_event.Participant.Id].MuzzleyInputRotacao(muzzley_event.Data["v"].ToString(), muzzley_event.Data["e"].ToString());
//		
//		if (muzzley_event.Data["c"].ToString() == "bc")
//			participantes[muzzley_event.Participant.Id].MuzzleyInputAceleracao(muzzley_event.Data["e"].ToString());
//		
//		if (muzzley_event.Data["c"].ToString() == "bb")
//			participantes[muzzley_event.Participant.Id].MuzzleyInputRe(muzzley_event.Data["e"].ToString());
	}
}
