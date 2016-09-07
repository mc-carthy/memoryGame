using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreatePuzzleButtonsAndAnimators : MonoBehaviour {

	[SerializeField]
	private Button puzzleButton;

	private int puzzleGame0 = 6;
	private int puzzleGame1 = 12;
	private int puzzleGame2 = 18;
	private int puzzleGame3 = 24;
	private int puzzleGame4 = 30;

	private List<Button> level0Buttons = new List<Button>();
	private List<Button> level1Buttons = new List<Button>();
	private List<Button> level2Buttons = new List<Button>();
	private List<Button> level3Buttons = new List<Button>();
	private List<Button> level4Buttons = new List<Button>();

	private List<Animator> level0Anims = new List<Animator>();
	private List<Animator> level1Anims = new List<Animator>();
	private List<Animator> level2Anims = new List<Animator>();
	private List<Animator> level3Anims = new List<Animator>();
	private List<Animator> level4Anims = new List<Animator>();

	private void Awake () {
		CreateButtons ();
		GetAnimators ();
	}


	private void CreateButtons () {
		for (int i = 0; i < puzzleGame0; i++) {
			Button btn = Instantiate (puzzleButton);
			btn.gameObject.name = i.ToString ();
			level0Buttons.Add (btn);
		}

		for (int i = 0; i < puzzleGame1; i++) {
			Button btn = Instantiate (puzzleButton);
			btn.gameObject.name = i.ToString ();
			level1Buttons.Add (btn);
		}

		for (int i = 0; i < puzzleGame2; i++) {
			Button btn = Instantiate (puzzleButton);
			btn.gameObject.name = i.ToString ();
			level2Buttons.Add (btn);
		}

		for (int i = 0; i < puzzleGame3; i++) {
			Button btn = Instantiate (puzzleButton);
			btn.gameObject.name = i.ToString ();
			level3Buttons.Add (btn);
		}

		for (int i = 0; i < puzzleGame4; i++) {
			Button btn = Instantiate (puzzleButton);
			btn.gameObject.name = i.ToString ();
			level4Buttons.Add (btn);
		}
	}

	private void GetAnimators () {
		for (int i = 0; i < level0Buttons.Count; i++) {
			level0Anims.Add (level0Buttons [i].gameObject.GetComponent<Animator> ());
			level0Buttons [i].gameObject.SetActive (false);
		}

		for (int i = 0; i < level1Buttons.Count; i++) {
			level1Anims.Add (level1Buttons [i].gameObject.GetComponent<Animator> ());
			level1Buttons [i].gameObject.SetActive (false);
		}

		for (int i = 0; i < level2Buttons.Count; i++) {
			level2Anims.Add (level1Buttons [i].gameObject.GetComponent<Animator> ());
			level2Buttons [i].gameObject.SetActive (false);
		}

		for (int i = 0; i < level3Buttons.Count; i++) {
			level3Anims.Add (level0Buttons [i].gameObject.GetComponent<Animator> ());
			level3Buttons [i].gameObject.SetActive (false);
		}

		for (int i = 0; i < level4Buttons.Count; i++) {
			level4Anims.Add (level0Buttons [i].gameObject.GetComponent<Animator> ());
			level4Buttons [i].gameObject.SetActive (false);
		}
	}
}
