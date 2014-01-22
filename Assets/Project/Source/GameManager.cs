using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GUITexture qrcodeGuiTexture;
	private bool startDownloadQrcode = false;

	void Start () {
		MuzzleyController.OnReady += StartGame;
	}

	void Update () {
		if (startDownloadQrcode) {
			StartCoroutine(waitQr());
		}
	}

	void StartGame()
	{
		Debug.Log("StartGame");
		startDownloadQrcode = true;
	}

	IEnumerator waitQr()
	{
		WWW www = new WWW(MuzzleyController.Instance.qrcodeUrl);
		startDownloadQrcode = false;

		yield return www;
		
		qrcodeGuiTexture.texture = www.texture;
	}
}
