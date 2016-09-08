using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class GameData {

	private bool[] candyLevels, transportLevels, fruitLevels;
	private int[] candyLevelStars, transportLevelStars, fruitLevelStars;
	private bool isGameStartedForFirstTime;
	private float musicVolume;

	public void SetCandyLevels (bool[] candyLevels) {
		this.candyLevels = candyLevels;
	}

	public bool[] GetCandyLevels () {
		return candyLevels;
	}

	public void SetTransportLevels (bool[] transportLevels) {
		this.transportLevels = transportLevels;
	}

	public bool[] GetTransportLevels () {
		return transportLevels;
	}

	public void SetFruitLevels (bool[] fruitLevels) {
		this.fruitLevels = fruitLevels;
	}

	public bool[] GetFruitLevels () {
		return fruitLevels;
	}

	public void SetCandyLevelStars (bool[] candyLevelStars) {
		this.candyLevelStars = candyLevelStars;
	}

	public int[] GetCandyLevelStars () {
		return candyLevelStars;
	}

	public void SetTransportLevelStars (bool[] transportLevelStars) {
		this.transportLevelStars = transportLevelStars;
	}

	public int[] GetTransportLevelStars () {
		return transportLevelStars;
	}

	public void SetFruitLevelStars (bool[] fruitLevelStars) {
		this.fruitLevelStars = fruitLevelStars;
	}

	public int[] GetFruitLevelStars () {
		return fruitLevelStars;
	}

	public void SetIsGameStartedForFirstTime (bool isGameStartedForFirstTime) {
		this.isGameStartedForFirstTime = isGameStartedForFirstTime;
	}

	public bool GetIsGameStartedForFirstTime () {
		return isGameStartedForFirstTime;
	}

	public void SetMusicVolume (float musicVolume) {
		this.musicVolume = musicVolume;
	}

	public float GetMusicVolume () {
		return musicVolume;
	}
}
