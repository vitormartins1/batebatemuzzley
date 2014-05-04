using UnityEngine;
using System;	
using System.Collections;
using System.Collections.Generic;
using Muzzley;
using Muzzley.Net;

public class QrCodeController : MonoBehaviour {

	[SerializeField]
	private UITexture qrcode;

	[SerializeField]
	private bool startDownloadQrcode = false;

	[SerializeField]
	private string qrcodeUrl;

	[SerializeField]
	private float smoothFactor = 3f;

	private WWW www;

	UISprite loadingbar;

	void Start () {
		MuzzleyAppController.OnReady += OnMuzzleyAppReady;
		loadingbar = GameObject.Find("foreground").GetComponent<UISprite>();
		loadingbar.transform.localScale = new Vector3(0, loadingbar.transform.localScale.y, loadingbar.transform.localScale.z);
	
		qrcode = GameObject.Find("QrCode").GetComponent<UITexture>();
		qrcode.enabled = false;
	}

	void Update () {
		if (startDownloadQrcode) {
			StartCoroutine(downloadQrCode());
		}

		if (www != null) {
			//Debug.Log("progress: " + www.progress + " error: " + www.error + " is done? " + www.isDone);
			Vector3 scale = new Vector3(www.progress, loadingbar.transform.localScale.y, loadingbar.transform.localScale.z);
			scale = Vector3.Lerp(loadingbar.transform.localScale, scale, Time.deltaTime * smoothFactor);
			loadingbar.transform.localScale = scale;

			if (loadingbar.transform.localScale.x >= 0.98f && www.isDone) {
				if (qrcode.mainTexture != www.texture) {
					qrcode.mainTexture = www.texture;
					qrcode.enabled = true;
				}
			}
		}
	}

	protected virtual void OnMuzzleyAppReady(MuzzleyActivity activity)
	{
		qrcodeUrl = activity.QRCodeUrl;
		startDownloadQrcode = true;
	}

	IEnumerator downloadQrCode()
	{
		www = new WWW(qrcodeUrl);
		startDownloadQrcode = false;
		yield return www;

	}
}
