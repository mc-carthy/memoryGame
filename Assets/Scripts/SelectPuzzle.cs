using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectPuzzle : MonoBehaviour {

	[SerializeField]
	private GameObject panel;
	[SerializeField]
	private Animator anim;
	private string selectedPuzzle;

	public void SelectedPuzzle () {
		selectedPuzzle = EventSystem.current.currentSelectedGameObject.name;
		Debug.Log (selectedPuzzle);
	}

}
