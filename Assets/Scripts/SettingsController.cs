using UnityEngine;
using System.Collections;

public class SettingsController : MonoBehaviour {

	[SerializeField]
	private GameObject panel;
	[SerializeField]
	private Animator anim;

	public void OpenSettings () {
		panel.SetActive (true);
		anim.Play ("settingsPanelSlideIn");
	}

	public void CloseSettings () {
		StartCoroutine (CloseSettingsPanel ());
	}

	private IEnumerator CloseSettingsPanel () {
		anim.Play ("settingsPanelSlideOut");
		yield return new WaitForSeconds (0.6f);
		panel.SetActive(false);
	}
}
