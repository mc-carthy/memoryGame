﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectPuzzle : MonoBehaviour {

	[SerializeField]
	private PuzzleGameManager puzzleGameManager;
	[SerializeField]
	private GameObject selectPuzzlePanel, levelSelectPanel;
	[SerializeField]
	private Animator selectPuzzleAnim, levelSelectAnim;
	[SerializeField]
	private SelectLevel selectLevel;
	[SerializeField]
	private LevelLocker levelLocker;
	[SerializeField]
	private StarLocker starLocker;
	private string selectedPuzzle;

	public void SelectedPuzzle () {
		starLocker.DeactivateStars ();
		selectedPuzzle = EventSystem.current.currentSelectedGameObject.name;
		puzzleGameManager.SetSelectedPuzzle (selectedPuzzle);
		levelLocker.CheckWhichLevelsAreUnlocked (selectedPuzzle);
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
