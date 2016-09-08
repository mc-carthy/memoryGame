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

	public void Save (int level, string selectedPuzzle, int stars);

	private void InitializeGame () {

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