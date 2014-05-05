using UnityEngine;
using System;	
using System.Collections;
using System.Collections.Generic;
using Muzzley;
using Muzzley.Net;

public class MuzzleyAppController : MonoBehaviour {

	static string INTENSITY_STEPS = "intensitySteps";
	static string SECTOR = "sector";

	private Dictionary<string, object> motion;
	private Dictionary<string, object> motionParams;

	public MuzzleyApp myMuzzleyApp;
	private List<CoreGamePadListener> participants;

	[SerializeField]
	private Dictionary<string, CoreGamePadListener> gamePadListeners;

	public delegate void ActivityReady(MuzzleyActivity muzzleyActivity);
	public static event ActivityReady OnReady;

//	public delegate void ParticipantJoin(string currentWidget,
//		                                    string currentWidgetParams,
//		                                    string id,
//		                                    string name,
//		                                    string photoUrl,
//		                                    string profileId);

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

		participants = new List<CoreGamePadListener>();
		gamePadListeners = new Dictionary<string, CoreGamePadListener>();

		motion = new Dictionary<string, object>();
		motionParams = new Dictionary<string, object>();

		motion.Add("c", "deviceMotion");
		
		motionParams.Add("step", 5);
		motionParams.Add("pitch", true);
		
		motion.Add("p", motionParams);
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
//		muzzley_participant.ChangeWidget(MuzzleyConstants.Widgets.GAMEPAD, motion);

		muzzley_participant.ChangeWidget(MuzzleyConstants.Widgets.GAMEPAD, new Dictionary<string, object>() {
			{SECTOR, 45},
			{INTENSITY_STEPS, 10},
			{MuzzleyConstants.Widgets.Params.NUMBUTTONS, 4}
		});

//		OnParticipantJoin(muzzley_participant.CurrentWidget.ToString(),
//		                  muzzley_participant.CurrentWidgetParams.ToString(),
//		                  muzzley_participant.Id.ToString(),
//		                  muzzley_participant.Name.ToString(),
//		                  muzzley_participant.PhotoUrl.ToString(),
//		                  muzzley_participant.ProfileId.ToString());

		OnParticipantJoin(muzzley_participant);

		//muzzley_participant.ChangeWidget(MuzzleyConstants.Widgets.GAMEPAD, motion);
	}
	
	private void OnQuit(MuzzleyAppParticipant muzzley_participant)
	{
	}
	
	private void OnAction(MuzzleyAppAction muzzley_event)
	{
		//int id = int.Parse(muzzley_event.Participant.Id.ToString());
		string id = muzzley_event.Participant.Id;

		if (muzzley_event.Data[MuzzleyConstants.Data.COMPONENT].ToString() == MuzzleyConstants.Data.Component.JOYSTICK) {
			// 1
//			Dictionary<string, object> intensitySteps = new Dictionary<string, object>();
//
//			muzzley_event.Data.TryGetValue("v", out intensitySteps);
//
//			float angle = intensitySteps["a"];
//			float intensity = intensitySteps["i"];

			// 2
			float angle = float.Parse(muzzley_event.Data[MuzzleyConstants.ACTION].ToString());
			float intensity = float.Parse(muzzley_event.Data["i"].ToString());

			if (muzzley_event.Data[MuzzleyConstants.Data.EVENT].ToString() == MuzzleyConstants.Data.Events.PRESS) {
				gamePadListeners[id].onJoystickPress(angle, intensity);
			} else {
				gamePadListeners[id].onJoystickRelease(angle, intensity);
			}
		} else if (muzzley_event.Data[MuzzleyConstants.Data.COMPONENT].ToString() == MuzzleyConstants.Data.Component.BUTTON_A) {
			if (muzzley_event.Data[MuzzleyConstants.Data.EVENT].ToString() == MuzzleyConstants.Data.Events.PRESS) {
				gamePadListeners[id].onButonAPress();
			} else {
				gamePadListeners[id].onButonARelease();
			}
		} else if (muzzley_event.Data[MuzzleyConstants.Data.COMPONENT].ToString() == MuzzleyConstants.Data.Component.BUTTON_B) {
			if (muzzley_event.Data[MuzzleyConstants.Data.EVENT].ToString() == MuzzleyConstants.Data.Events.PRESS) {
				gamePadListeners[id].onButonBPress();
			} else {
				gamePadListeners[id].onButonBRelease();
			}
		} else if (muzzley_event.Data[MuzzleyConstants.Data.COMPONENT].ToString() == MuzzleyConstants.Data.Component.BUTTON_C) {
			if (muzzley_event.Data[MuzzleyConstants.Data.EVENT].ToString() == MuzzleyConstants.Data.Events.PRESS) {
				gamePadListeners[id].onButonCPress();
			} else {
				gamePadListeners[id].onButonCRelease();
			}
		} else if (muzzley_event.Data[MuzzleyConstants.Data.COMPONENT].ToString() == MuzzleyConstants.Data.Component.BUTTON_D) {
			if (muzzley_event.Data[MuzzleyConstants.Data.EVENT].ToString() == MuzzleyConstants.Data.Events.PRESS) {
				gamePadListeners[id].onButonDPress();
			} else {
				gamePadListeners[id].onButonDRelease();
			}
		}

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

	public void addParticipant(CoreGamePadListener muzzleyParticipantListener) {
		//participants.Add(muzzleyParticipantListener);
		gamePadListeners.Add(muzzleyParticipantListener.getMuzzleyID(), muzzleyParticipantListener);
	}
}
