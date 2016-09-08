using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsController : MonoBehaviour {

	[SerializeField]
	private GameObject panel;
	[SerializeField]
	private Animator anim;
	[SerializeField]
	private MusicController musicController;
	[SerializeField]
	private Slider slider;


	public void OpenSettings () {
		slider.value = musicController.GetMusicVolume ();
		panel.SetActive (true);
		anim.Play ("settingsPanelSlideIn");
	}

	public void CloseSettings () {
		StartCoroutine (CloseSettingsPanel ());
	}

	public void GetVolume (float volume) {
		musicController.SetMusicVolume (volume);
	}

	private IEnumerator CloseSettingsPanel () {
		anim.Play ("settingsPanelSlideOut");
		yield return new WaitForSeconds (0.6f);
		panel.SetActive(false);
	}
}
