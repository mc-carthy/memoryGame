using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SetUpPuzzleGame : MonoBehaviour {

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

	}

	public void SetPuzzleButtonAndAnimators (List<Button> puzzleButtons, List<Animator> puzzleButtonAnimators) {

	}

	private void PrepareGameSprites () {

	}

	private void Shuffle (List<Sprite> list) {

	}
}
