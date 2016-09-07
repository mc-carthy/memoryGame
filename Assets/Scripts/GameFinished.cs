using UnityEngine;
using System.Collections;

public class GameFinished : MonoBehaviour {

	[SerializeField]
	private GameObject gameFinishedPanel;
	[SerializeField]
	private Animator gameFinishedAnim, star0Anim, star1Anim, star2Anim, textAnim;

	public void ShowGameFinishedPanel (int stars) {
		StartCoroutine (ShowPanel (stars));
	}

	public void HideGameFinishedPanel () {
		if (gameFinishedPanel.activeInHierarchy) {
			StartCoroutine (HidePanel ());
		}
	}

	private IEnumerator ShowPanel (int stars) {
		gameFinishedPanel.SetActive (true);
		gameFinishedAnim.Play ("fadeIn");
		yield return new WaitForSeconds (1.7f);

		switch (stars) {
		case 1:
			star0Anim.Play ("starFadeIn");
			yield return new WaitForSeconds (0.1f);
			textAnim.Play ("textFadeIn");
			break;
		case 2:
			star0Anim.Play ("starFadeIn");
			yield return new WaitForSeconds (0.25f);
			star1Anim.Play ("starFadeIn");
			yield return new WaitForSeconds (0.1f);
			textAnim.Play ("textFadeIn");
			break;
		case 3:
			star0Anim.Play ("starFadeIn");
			yield return new WaitForSeconds (0.25f);
			star1Anim.Play ("starFadeIn");
			yield return new WaitForSeconds (0.25f);
			star2Anim.Play ("starFadeIn");
			yield return new WaitForSeconds (0.1f);
			textAnim.Play ("textFadeIn");
			break;
		}
	}

	private IEnumerator HidePanel () {
		gameFinishedAnim.Play ("fadeOut");
		star0Anim.Play ("starFadeOut");
		star1Anim.Play ("starFadeOut");
		star2Anim.Play ("starFadeOut");
		textAnim.Play ("textFadeOut");
		yield return new WaitForSeconds (1.5f);
		gameFinishedPanel.SetActive (false);
	}
}
