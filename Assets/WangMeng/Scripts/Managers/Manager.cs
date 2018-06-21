﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris{
public class Manager : MonoBehaviour {

	private static GameManager _gameManager;
	public static GameManager Game
	{
		get { return _gameManager; }
	}
	private static Tetris.ScoreManager _scoreManager;
	public static Tetris.ScoreManager Score
	{
		get { return _scoreManager; }
	}

	private static UIManager _uiManager;
	public static UIManager UI
	{
		get { return _uiManager; }
	}

	private static AudioManager _audioManager;
	public static AudioManager Audio
	{
		get { return _audioManager; }
	}

	private static SpawnManager _spawnManager;
	public static SpawnManager Spawn{
		get{
			return _spawnManager;
		}
	}

	private static BricksManager _bricksManager;
	public static BricksManager Bricks{
		get{
			return _bricksManager;
		}
	}
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		_gameManager = GetComponent<GameManager>();
		_uiManager = GetComponent<UIManager>();
		_audioManager = GetComponent<AudioManager>();
		_scoreManager = GetComponent<ScoreManager> ();
		_spawnManager=GetComponent<SpawnManager>();
		_bricksManager=GetComponent<BricksManager>();
		DontDestroyOnLoad(gameObject);
	}
}
}