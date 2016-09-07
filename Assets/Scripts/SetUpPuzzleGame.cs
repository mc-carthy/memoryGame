using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SetUpPuzzleGame : MonoBehaviour {

	[SerializeField]
	private PuzzleGameManager puzzleGameManager;
	private Sprite[] candyPuzzleSprites, transportPuzzleSprites, fruitPuzzleSprites;
	private List<Sprite> gamePuzzles = new List<Sprite>();
	private List<Button> puzzleButtons = new List<Button>();
	private List<Animator> puzzleButtonAnimators = new List<Animator>();
	private int level;
	private string selectedPuzzle;
	private int looper;

	private void Awake () {
		candyPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Candy");
		transportPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Transport");
		fruitPuzzleSprites = Resources.LoadAll<Sprite> ("Sprites/Fruits");
	}

	public void SetLevelAndPuzzle (int level, string selectedPuzzle) {
		this.level = level;
		this.selectedPuzzle = selectedPuzzle;
		PrepareGameSprites ();
		puzzleGameManager.SetGamePuzzleSprites (this.gamePuzzles);
	}

	public void SetPuzzleButtonAndAnimators (List<Button> puzzleButtons, List<Animator> puzzleButtonAnimators) {
		this.puzzleButtons = puzzleButtons;
		this.puzzleButtonAnimators = puzzleButtonAnimators;
		puzzleGameManager.SetUpButtonsAndAnimators (puzzleButtons, puzzleButtonAnimators);
	}

	private void PrepareGameSprites () {
		gamePuzzles.Clear ();
		gamePuzzles = new List<Sprite> ();
		int index = 0;

		switch (level) {
		case 0:
			looper = 6;
			break;
		case 1:
			looper = 12;
			break;
		case 2:
			looper = 18;
			break;
		case 3:
			looper = 24;
			break;
		case 4:
			looper = 30;
			break;
		}

		switch (selectedPuzzle) {
		case "candyLevel":
			for (int i = 0; i < looper; i++) {
				if (index == (looper / 2)) {
					index = 0;
				}
				gamePuzzles.Add(candyPuzzleSprites[index]);
				index++;
			}
			break;
		case "transportLevel":
			for (int i = 0; i < looper; i++) {
				if (index == (looper / 2)) {
					index = 0;
				}
				gamePuzzles.Add(transportPuzzleSprites[index]);
				index++;
			}
			break;
		case "fruitLevel":
			for (int i = 0; i < looper; i++) {
				if (index == (looper / 2)) {
					index = 0;
				}
				gamePuzzles.Add(fruitPuzzleSprites[index]);
				index++;
			}
			break;
		}
		Shuffle (gamePuzzles);
	}

	private void Shuffle (List<Sprite> list) {
		for (int i = 0; i < list.Count; i++) {
			Sprite temp = list [i];
			int random = Random.Range (0, list.Count);
			list [i] = list [random];
			list [random] = temp;
		}
	}
}
