using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PuzzleGameManager : MonoBehaviour {

	private List<Button> puzzleButtons = new List<Button> ();
	private List<Animator> puzzleButtonAnims = new List<Animator>();
	[SerializeField]
	private List<Sprite> gamePuzzleSprites = new List<Sprite>();
	private int level;
	private string selectedPuzzle;
	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex;
	private string firstGuessName, secondGuessName;

	public void PickAPuzzle () {
		//Debug.Log ("The selected button is " + EventSystem.current.currentSelectedGameObject.name);
		int index = int.Parse(EventSystem.current.currentSelectedGameObject.name);

		if (!firstGuess) {
			firstGuess = true;
			firstGuessIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
			firstGuessName = gamePuzzleSprites [firstGuessIndex].name;
			StartCoroutine (TurnCardUp (puzzleButtonAnims[firstGuessIndex], puzzleButtons[firstGuessIndex], gamePuzzleSprites[firstGuessIndex]));
		} else if (!secondGuess) {
			secondGuess = true;
			secondGuessIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
			secondGuessName = gamePuzzleSprites [secondGuessIndex].name;
			StartCoroutine (TurnCardUp (puzzleButtonAnims[secondGuessIndex], puzzleButtons[secondGuessIndex], gamePuzzleSprites[secondGuessIndex]));
		}

		if (firstGuessName == secondGuessName) {

		}
	}

	public void SetUpButtonsAndAnimators (List<Button> buttons, List<Animator> animators) {
		this.puzzleButtons = buttons;
		this.puzzleButtonAnims = animators;

		AddListeners ();
	}

	public void SetGamePuzzleSprites (List<Sprite> gamePuzzleSprites) {
		this.gamePuzzleSprites = gamePuzzleSprites;
	}

	public void SetLevel (int level) {
		this.level = level;
	}

	public void SetSelectedPuzzle (string selectedPuzzle) {
		this.selectedPuzzle = selectedPuzzle;
	}

	private void AddListeners () {
		foreach (Button btn in puzzleButtons) {
			btn.onClick.RemoveAllListeners ();
			btn.onClick.AddListener (() => PickAPuzzle ());
		}
	}

	private IEnumerator TurnCardUp (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("cardTurnUp");
		yield return new WaitForSeconds (0.5f);
		Sprite cardBack = btn.image.sprite;
		btn.image.sprite = puzzleImage;
		//yield return new WaitForSeconds (1f);
		//StartCoroutine (TurnCardDown (anim, btn, cardBack));
	}

	private IEnumerator TurnCardDown (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("cardTurnDown");
		yield return new WaitForSeconds (0.5f);
		btn.image.sprite = puzzleImage;
	}
}
