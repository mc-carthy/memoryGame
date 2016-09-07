using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LayoutPuzzleButtons : MonoBehaviour {

	public List<Button> level0Buttons, level1Buttons, level2Buttons, level3Buttons, level4Buttons;
	public List<Animator> level0Anims, level1Anims, level2Anims, level3Anims, level4Anims;

	[SerializeField]
	private SetUpPuzzleGame setUpPuzzleGame;
	[SerializeField]
	private Transform puzzleLevel0, puzzleLevel1, puzzleLevel2, puzzleLevel3, puzzleLevel4;
	[SerializeField]
	private Sprite[] puzzleCardBacks;
	private int puzzleLevel;
	private string selectedPuzzle;

	public void LayoutButtons (int level, string puzzle) {
		this.puzzleLevel = level;
		this.selectedPuzzle = puzzle;
		setUpPuzzleGame.SetLevelAndPuzzle (puzzleLevel, selectedPuzzle);
		LayoutPuzzle ();
	}

	private void LayoutPuzzle () {
		switch (puzzleLevel) {
		case 0:
			foreach (Button btn in level0Buttons) {
				if (!btn.gameObject.activeInHierarchy) {
					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel0, false);

					if (selectedPuzzle == "candyLevel") {
						btn.image.sprite = puzzleCardBacks [0];
					} else if (selectedPuzzle == "transportLevel") {
						btn.image.sprite = puzzleCardBacks [1];
					} else if (selectedPuzzle == "fruitLevel") {
						btn.image.sprite = puzzleCardBacks [2];
					}
				}
			}
			setUpPuzzleGame.SetPuzzleButtonAndAnimators (level0Buttons, level0Anims);
			break;
		case 1:
			foreach (Button btn in level1Buttons) {
				if (!btn.gameObject.activeInHierarchy) {
					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel1, false);

					if (selectedPuzzle == "candyLevel") {
						btn.image.sprite = puzzleCardBacks [0];
					} else if (selectedPuzzle == "transportLevel") {
						btn.image.sprite = puzzleCardBacks [1];
					} else if (selectedPuzzle == "fruitLevel") {
						btn.image.sprite = puzzleCardBacks [2];
					}
				}
			}
			setUpPuzzleGame.SetPuzzleButtonAndAnimators (level1Buttons, level1Anims);
			break;
		case 2:
			foreach (Button btn in level2Buttons) {
				if (!btn.gameObject.activeInHierarchy) {
					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel2, false);

					if (selectedPuzzle == "candyLevel") {
						btn.image.sprite = puzzleCardBacks [0];
					} else if (selectedPuzzle == "transportLevel") {
						btn.image.sprite = puzzleCardBacks [1];
					} else if (selectedPuzzle == "fruitLevel") {
						btn.image.sprite = puzzleCardBacks [2];
					}
				}
			}
			setUpPuzzleGame.SetPuzzleButtonAndAnimators (level2Buttons, level2Anims);
			break;
		case 3:
			foreach (Button btn in level3Buttons) {
				if (!btn.gameObject.activeInHierarchy) {
					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel3, false);

					if (selectedPuzzle == "candyLevel") {
						btn.image.sprite = puzzleCardBacks [0];
					} else if (selectedPuzzle == "transportLevel") {
						btn.image.sprite = puzzleCardBacks [1];
					} else if (selectedPuzzle == "fruitLevel") {
						btn.image.sprite = puzzleCardBacks [2];
					}
				}
			}
			setUpPuzzleGame.SetPuzzleButtonAndAnimators (level3Buttons, level3Anims);
			break;
		case 4:
			foreach (Button btn in level4Buttons) {
				if (!btn.gameObject.activeInHierarchy) {
					btn.gameObject.SetActive (true);
					btn.gameObject.transform.SetParent (puzzleLevel4, false);

					if (selectedPuzzle == "candyLevel") {
						btn.image.sprite = puzzleCardBacks [0];
					} else if (selectedPuzzle == "transportLevel") {
						btn.image.sprite = puzzleCardBacks [1];
					} else if (selectedPuzzle == "fruitLevel") {
						btn.image.sprite = puzzleCardBacks [2];
					}
				}
			}
			setUpPuzzleGame.SetPuzzleButtonAndAnimators (level4Buttons, level4Anims);
			break;
		}
	}
}
