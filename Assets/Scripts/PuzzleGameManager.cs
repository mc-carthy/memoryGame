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
	[SerializeField]
	private GameFinished gameFinished;
	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;
	private int level;
	private string selectedPuzzle;
	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex;
	private string firstGuessName, secondGuessName;
	private Sprite cardBack;
	private int countGuesses;
	private int correctGuesses;
	private int gameGuesses;

	public void PickAPuzzle () {
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
			StartCoroutine (CheckIfCardsMatch (cardBack));
			countGuesses++;
		}
	}

	public void SetUpButtonsAndAnimators (List<Button> buttons, List<Animator> animators) {
		this.puzzleButtons = buttons;
		this.puzzleButtonAnims = animators;
		gameGuesses = puzzleButtons.Count / 2;
		cardBack = puzzleButtons [0].image.sprite;
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

	public List<Animator> ResetGamePlay () {
		firstGuess = secondGuess = false;
		countGuesses = 0;
		correctGuesses = 0;
		gameFinished.HideGameFinishedPanel ();
		return puzzleButtonAnims;
	}

	private void AddListeners () {
		foreach (Button btn in puzzleButtons) {
			btn.onClick.RemoveAllListeners ();
			btn.onClick.AddListener (() => PickAPuzzle ());
		}
	}

	private void CheckIfGameIsFinished () {
		correctGuesses++;
		if (correctGuesses == gameGuesses) {
			CheckHowManyGuesses ();
		}
	}

	private void CheckHowManyGuesses () {
		int howManyGuesses = 0;

		switch (level) {
		case 0:
			howManyGuesses = 5;
			break;
		case 1:
			howManyGuesses = 10;
			break;
		case 2:
			howManyGuesses = 15;
			break;
		case 3:
			howManyGuesses = 20;
			break;
		case 4:
			howManyGuesses = 25;
			break;
		}

		if (countGuesses < howManyGuesses) {
			gameFinished.ShowGameFinishedPanel (3);
			puzzleGameSaver.Save (level, selectedPuzzle, 3);
		} else if (countGuesses < (howManyGuesses + 5)) {
			gameFinished.ShowGameFinishedPanel (2);
			puzzleGameSaver.Save (level, selectedPuzzle, 2);
		} else {
			gameFinished.ShowGameFinishedPanel (1);
			puzzleGameSaver.Save (level, selectedPuzzle, 1);
		}
	}

	private IEnumerator TurnCardUp (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("cardTurnUp");
		yield return new WaitForSeconds (0.5f);
		btn.image.sprite = puzzleImage;
	}

	private IEnumerator TurnCardDown (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("cardTurnDown");
		yield return new WaitForSeconds (0.5f);
		btn.image.sprite = puzzleImage;
	}

	private IEnumerator CheckIfCardsMatch (Sprite cardBack) {
		yield return new WaitForSeconds (1.7f);
		if (firstGuessName == secondGuessName) {
			puzzleButtonAnims [firstGuessIndex].Play ("cardFade");
			puzzleButtonAnims [secondGuessIndex].Play ("cardFade");
			CheckIfGameIsFinished ();
		} else {
			StartCoroutine (TurnCardDown (puzzleButtonAnims[firstGuessIndex], puzzleButtons[firstGuessIndex], cardBack));
			StartCoroutine (TurnCardDown (puzzleButtonAnims[secondGuessIndex], puzzleButtons[secondGuessIndex], cardBack));
		}

		yield return new WaitForSeconds (0.7f);
		firstGuess = secondGuess = false;
	}
}
