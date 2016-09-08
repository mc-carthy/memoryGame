using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	[SerializeField]
	private PuzzleGameSaver puzzleGameSaver;
	private AudioSource bgMusicClip;
	private float musicVolume;

	private void Awake () {
		GetAudioSource ();
	}

	private void Start () {
		musicVolume = puzzleGameSaver.musicVolume;
		PlayOrTurnOffMusic (musicVolume);
	}

	public void SetMusicVolume (float volume) {
		PlayOrTurnOffMusic(volume);
	}

	public float GetMusicVolume () {
		return musicVolume;
	}

	private void GetAudioSource () {
		bgMusicClip = GetComponent<AudioSource> ();
	}

	private void PlayOrTurnOffMusic (float volume) {
		musicVolume = volume;
		bgMusicClip.volume = musicVolume;

		if (musicVolume > 0) {
			if (!bgMusicClip.isPlaying) {
				bgMusicClip.Play ();
			}
		} else {
			if (bgMusicClip.isPlaying) {
				bgMusicClip.Stop ();
			}
		}
		puzzleGameSaver.musicVolume = musicVolume;
		puzzleGameSaver.SaveGameData ();
	}
}
