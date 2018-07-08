using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tetris{
/// <summary>
/// 同过Manager这个类提供的静态变量来调用各个管理器
/// </summary>
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
	private static EventManager _eventManager;
	public static EventManager Event
	{
		get{
			return _eventManager;
		}
	}
	private static DataBaseManager _dataBaseManager;
	public static DataBaseManager DB
	{
		get{
			return _dataBaseManager;
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
		_eventManager=GetComponent<EventManager>();
		_dataBaseManager=GetComponent<DataBaseManager>();
		DontDestroyOnLoad(gameObject);

		Manager.Event.OnActivate();
       
		Manager.Game.OnActivate();
		
	}

	 /// <summary>
	 /// Callback sent to all game objects before the application is quit.
	 /// </summary>
	 void OnApplicationQuit()
	 {
		 
	 }
}
}