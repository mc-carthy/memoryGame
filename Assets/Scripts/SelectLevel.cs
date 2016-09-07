using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectLevel : MonoBehaviour {

	[SerializeField]
	private PuzzleGameManager puzzleGameManager;
	[SerializeField]
	private GameObject selectPuzzlePanel, levelSelectPanel;
	[SerializeField]
	private Animator selectPuzzleAnim, levelSelectAnim;
	[SerializeField]
	private LoadPuzzleGame loadPuzzleGame;
	private string selectedPuzzle;

	public void BackToPuzzleSelectMenu () {
		StartCoroutine (ShowPuzzleSelectMenu ());
	}

	public void SelectPuzzleLevel() {
		int level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
		puzzleGameManager.SetLevel (level);
		loadPuzzleGame.LoadPuzzle (level, selectedPuzzle);
	}

	public void SetSelectedPuzzle (string selectedPuzzle) {
		this.selectedPuzzle = selectedPuzzle;
	}

	private IEnumerator ShowPuzzleSelectMenu () {
		selectPuzzlePanel.SetActive (true);
		levelSelectAnim.Play ("levelSelectSlideOut");
		selectPuzzleAnim.Play ("selectPuzzleSlideIn");
		yield return new WaitForSeconds (0.6f);
		levelSelectPanel.SetActive (false);
	}
}
