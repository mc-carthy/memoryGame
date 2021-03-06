﻿using UnityEngine;
using System.Collections;

public class LevelLocker : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;
	[SerializeField]
	private GameObject[] levelStarsHolders, levelPadlocks;
	[SerializeField]
	private StarLocker starsLocker;

	private bool[] candyLevels, transportLevels, fruitPuzzleLevels;

	private void Awake () {
		DeactivatePadlocksandStarHolders ();
	}

	private void Start () {
		GetLevels ();
	}

	public void CheckWhichLevelsAreUnlocked (string selectedPuzzle) {
		DeactivatePadlocksandStarHolders ();
		GetLevels ();

		switch (selectedPuzzle) {
		case "candyLevel":
			for (int i = 0; i < candyLevels.Length; i++) {
				if (candyLevels [i]) {
					levelStarsHolders [i].SetActive(true);
					starsLocker.ActivateStars (i, selectedPuzzle);
				} else {
					levelPadlocks [i].SetActive(true);
				}
			}
			break;
		case "transportLevel":
			for (int i = 0; i < transportLevels.Length; i++) {
				if (transportLevels [i]) {
					levelStarsHolders [i].SetActive(true);
					starsLocker.ActivateStars (i, selectedPuzzle);
				} else {
					levelPadlocks [i].SetActive(true);
				}
			}			
			break;
		case "fruitLevel":
			for (int i = 0; i < fruitPuzzleLevels.Length; i++) {
				if (fruitPuzzleLevels [i]) {
					levelStarsHolders [i].SetActive(true);
					starsLocker.ActivateStars (i, selectedPuzzle);
				} else {
					levelPadlocks [i].SetActive(true);
				}
			}			
			break;
		}
	}

	public bool[] GetPuzzleLevels (string selectedPuzzle) {
		switch (selectedPuzzle) {
		case "candyLevel":
			return this.candyLevels;
			break;
		case "transportLevel":
			return this.transportLevels;
			break;
		case "fruitLevel":
			return this.fruitPuzzleLevels;
			break;
		default:
			return null;
			break;
		}
	}

	private void DeactivatePadlocksandStarHolders () {
		for (int i = 0; i < levelStarsHolders.Length; i++) {
			levelStarsHolders [i].SetActive(false);
			levelPadlocks [i].SetActive(false);
		}
	}

	private void GetLevels () {
		candyLevels = puzzleGameSaver.candyLevels;
		transportLevels = puzzleGameSaver.transportLevels;
		fruitPuzzleLevels = puzzleGameSaver.fruitLevels;
	}
}
