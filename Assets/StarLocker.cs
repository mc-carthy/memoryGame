using UnityEngine;
using System.Collections;

public class StarLocker : MonoBehaviour {

	public int[] candyPuzzleStars, transportPuzzleStars, fruitPuzzleStars;

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;
	[SerializeField]
	private GameObject[] level0Stars, level1Stars, level2Stars, level3Stars, level4Stars;

	private void Awake () {

	}

	private void Start () {

	}

	public void ActivateStars (int level, string selectedPuzzle) {
		GetStars ();

		int stars;

		switch (selectedPuzzle) {
		case "candyLevel":
			stars = candyPuzzleStars [level];
			ActivateLevelStars (level, stars);
			break;
		case "transportLevel":
			stars = transportPuzzleStars [level];
			ActivateLevelStars (level, stars);
			break;
		case "fruitLevel":
			stars = fruitPuzzleStars [level];
			ActivateLevelStars (level, stars);
			break;
		}
	}

	public void DeactivateStars () {
		for (int i = 0; i < level0Stars.Length; i++) {
			level0Stars [i].SetActive (false);
		}
		for (int i = 0; i < level1Stars.Length; i++) {
			level0Stars [i].SetActive (false);
		}
		for (int i = 0; i < level2Stars.Length; i++) {
			level0Stars [i].SetActive (false);
		}
		for (int i = 0; i < level3Stars.Length; i++) {
			level0Stars [i].SetActive (false);
		}
		for (int i = 0; i < level4Stars.Length; i++) {
			level0Stars [i].SetActive (false);
		}
	}

	private void ActivateLevelStars (int level, int looper) {
		switch (level) {
		case 0:
			if (looper != 0) {
				for (int i = 0; i < looper; i++) {
					level0Stars [i].SetActive (true);
				}
			}
			break;
		case 1:
			if (looper != 0) {
				for (int i = 0; i < looper; i++) {
					level1Stars [i].SetActive (true);
				}
			}
			break;
		case 2:
			if (looper != 0) {
				for (int i = 0; i < looper; i++) {
					level2Stars [i].SetActive (true);
				}
			}
			break;
		case 3:
			if (looper != 0) {
				for (int i = 0; i < looper; i++) {
					level3Stars [i].SetActive (true);
				}
			}
			break;
		case 4:
			if (looper != 0) {
				for (int i = 0; i < looper; i++) {
					level4Stars [i].SetActive (true);
				}
			}
			break;
		}
	}

	private void GetStars () {
		candyPuzzleStars = puzzleGameSaver.candyLevelStars;
		transportPuzzleStars = puzzleGameSaver.transportLevelStars;
		fruitPuzzleStars = puzzleGameSaver.fruitLevelStars;
	}
}
