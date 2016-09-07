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

	public void PickAPuzzle () {
		//Debug.Log ("The selected button is " + EventSystem.current.currentSelectedGameObject.name);
		int index = int.Parse(EventSystem.current.currentSelectedGameObject.name);
		StartCoroutine (TurnCardUp (puzzleButtonAnims[index], puzzleButtons[index], gamePuzzleSprites[index]));
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
		yield return new WaitForSeconds (0.4f);
		btn.image.sprite = puzzleImage;
		yield return new WaitForSeconds (1f);
		StartCoroutine (TurnCardDown (anim, btn, puzzleImage));
	}

	private IEnumerator TurnCardDown (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("cardTurnDown");
		yield return new WaitForSeconds (0.4f);
		btn.image.sprite = puzzleImage;
	}
}
