using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectPuzzle : MonoBehaviour {

	[SerializeField]
	private GameObject selectPuzzlePanel, levelSelectPanel;
	[SerializeField]
	private Animator selectPuzzleAnim, levelSelectAnim;
	[SerializeField]
	private SelectLevel selectLevel;
	private string selectedPuzzle;

	public void SelectedPuzzle () {
		selectedPuzzle = EventSystem.current.currentSelectedGameObject.name;
		selectLevel.SetSelectedPuzzle (selectedPuzzle);
		StartCoroutine(ShowLevelSelectMenu ());
	}

	private IEnumerator ShowLevelSelectMenu () {
		levelSelectPanel.SetActive (true);
		selectPuzzleAnim.Play ("selectPuzzleSlideOut");
		levelSelectAnim.Play ("levelSelectSlideIn");
		yield return new WaitForSeconds (0.6f);
		selectPuzzlePanel.SetActive (false);
	}
}
