using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PuzzleGameSaver : MonoBehaviour {

	public bool[] candyLevels, transportLevels, fruitLevels;
	public int[] candyLevelStars, transportLevelStars, fruitLevelStars;
	public float musicVolume;

	private GameData gameData;
	private bool isGameStartedForFirstTime;

	private void Awake () {
		InitializeGame ();
	}

	public void Save (int level, string selectedPuzzle, int stars) {
		int unlockNextLevel = -1;

		switch (selectedPuzzle) {
		case "candyLevel":
			unlockNextLevel = level + 1;
			candyLevelStars [level] = stars;
			if (unlockNextLevel < candyLevels.Length) {
				candyLevels [unlockNextLevel] = true;
			}
			break;
		case "transportLevel":
			unlockNextLevel = level + 1;
			transportLevelStars [level] = stars;
			if (unlockNextLevel < transportLevels.Length) {
				transportLevels [unlockNextLevel] = true;
			}
			break;
		case "fruitsLevel":
			unlockNextLevel = level + 1;
			fruitLevelStars [level] = stars;
			if (unlockNextLevel < fruitLevels.Length) {
				fruitLevels [unlockNextLevel] = true;
			}
			break;
		}
	}

	private void InitializeGame () {
		LoadGameData ();

		if (gameData != null) {
			isGameStartedForFirstTime = gameData.GetIsGameStartedForFirstTime ();
		} else {
			isGameStartedForFirstTime = true;
		}

		if (isGameStartedForFirstTime) {
			isGameStartedForFirstTime = false;
			musicVolume = 0;

			candyLevels = new bool[5];
			transportLevels = new bool[5];
			fruitLevels = new bool[5];

			candyLevels [0] = true;
			transportLevels [0] = true;
			fruitLevels [0] = true;

			for (int i = 1; i < candyLevels.Length; i++) {
				candyLevels [i] = false;
				transportLevels [i] = false;
				fruitLevels [i] = false;
			}

			candyLevelStars = new int[5];
			transportLevelStars = new int[5];
			fruitLevelStars = new int[5];

			for (int i = 0; i < candyLevels.Length; i++) {
				candyLevelStars [i] = 0;
				transportLevelStars [i] = 0;
				fruitLevelStars [i] = 0;
			}

			gameData = new GameData ();

			gameData.SetCandyLevels(candyLevels);
			gameData.SetTransportLevels(transportLevels);
			gameData.SetFruitLevels(fruitLevels);

			gameData.SetCandyLevelStars(candyLevelStars);
			gameData.SetTransportLevelStars(transportLevelStars);
			gameData.SetFruitLevelStars(fruitLevelStars);

			gameData.SetIsGameStartedForFirstTime(isGameStartedForFirstTime);
			gameData.SetMusicVolume(musicVolume);

			SaveGameData ();
			LoadGameData ();
		}
	}

	private void SaveGameData () {
		FileStream file = null;
		try {
			BinaryFormatter bf = new BinaryFormatter();
			file = File.Create(Application.persistentDataPath +"/GameData.dat");
			if (gameData != null) {
				gameData.SetCandyLevels(candyLevels);
				gameData.SetTransportLevels(transportLevels);
				gameData.SetFruitLevels(fruitLevels);

				gameData.SetCandyLevelStars(candyLevelStars);
				gameData.SetTransportLevelStars(transportLevelStars);
				gameData.SetFruitLevelStars(fruitLevelStars);

				gameData.SetIsGameStartedForFirstTime(isGameStartedForFirstTime);
				gameData.SetMusicVolume(musicVolume);

				bf.Serialize(file,gameData);
			}
		} catch (Exception e) {

		} finally {
			if (file != null) {
				file.Close ();
			}
		}
	}

	private void LoadGameData () {
		FileStream file = null;
		try {
			BinaryFormatter bf = new BinaryFormatter();
			file = File.Open(Application.persistentDataPath +"/GameData.dat", FileMode.Open);
			gameData = (GameData)bf.Deserialize(file);
			if (gameData != null) {
				candyLevels = gameData.GetCandyLevels();
				transportLevels = gameData.GetTransportLevels();
				fruitLevels = gameData.GetFruitLevels();

				candyLevelStars = gameData.GetCandyLevelStars();
				transportLevelStars = gameData.GetTransportLevelStars();
				fruitLevelStars = gameData.GetFruitLevelStars();

				//isGameStartedForFirstTime = gameData.GetIsGameStartedForFirstTime();
				musicVolume = gameData.GetMusicVolume();
			}
		} catch (Exception e) {

		} finally {
			if (file != null) {
				file.Close ();
			}
		}
	}
}