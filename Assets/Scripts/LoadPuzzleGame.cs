using UnityEngine;
using System.Collections;

public class LoadPuzzleGame : MonoBehaviour {

	[SerializeField]
	private GameObject puzzleLevelSelectPanel;
	[SerializeField]
	private Animator puzzleLevelSelectAnim;
	[SerializeField]
	private GameObject puzzleGamePanel0, puzzleGamePanel1, puzzleGamePanel2, puzzleGamePanel3, puzzleGamePanel4;
	[SerializeField]
	private Animator puzzleGameAnim0, puzzleGameAnim1, puzzleGameAnim2, puzzleGameAnim3, puzzleGameAnim4;
	private int puzzleLevel;
	private string selectedPuzzle;

	public void LoadPuzzle (int level, string puzzle) {
		this.puzzleLevel = level;
		this.selectedPuzzle = puzzle;

		switch (puzzleLevel) {
		case 0:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel0, puzzleGameAnim0));
			break;
		case 1:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel1, puzzleGameAnim1));
			break;
		case 2:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel2, puzzleGameAnim2));
			break;
		case 3:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel3, puzzleGameAnim3));
			break;
		case 4:
			StartCoroutine(LoadPuzzleGamePanel(puzzleGamePanel4, puzzleGameAnim4));
			break;
		}
	}

	public void BackToPuzzleLevelSelectMenu () {
		switch (puzzleLevel) {
		case 0:
			StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel0, puzzleGameAnim0));
			break;
		case 1:
			StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel1, puzzleGameAnim1));
			break;
		case 2:
			StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel2, puzzleGameAnim2));
			break;
		case 3:
			StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel3, puzzleGameAnim3));
			break;
		case 4:
			StartCoroutine(LoadPuzzleLevelSelectMenu(puzzleGamePanel4, puzzleGameAnim4));
			break;
		}
	}

	private IEnumerator LoadPuzzleLevelSelectMenu (GameObject puzzleGamePanel, Animator puzzleGameAnim) {
		puzzleLevelSelectPanel.SetActive (true);
		puzzleLevelSelectAnim.Play ("levelSelectSlideIn");
		puzzleGameAnim.Play ("puzzleGamePanelSlideOut");
		yield return new WaitForSeconds (1f);
		puzzleGamePanel.SetActive (false);	}


	private IEnumerator LoadPuzzleGamePanel (GameObject puzzleGamePanel, Animator puzzleGameAnim) {
		puzzleGamePanel.SetActive (true);
		puzzleGameAnim.Play ("puzzleGamePanelSlideIn");
		puzzleLevelSelectAnim.Play ("levelSelectSlideOut");
		yield return new WaitForSeconds (1f);
		puzzleLevelSelectPanel.SetActive (false);
	}
}
