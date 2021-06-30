﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public int m_NumRoundsToWin = 5;
	public float m_StartDelay = 3f;
	public float m_EndDelay = 3f;
	public CameraControler m_CameraControl;
	public Text m_MessageText;
	public TankThinker m_TankPrefab;
	public Transform[] SpawnPoints;

	private WaitForSeconds m_StartWait;
	private WaitForSeconds m_EndWait;
	private List<TankThinker> m_Tanks;

	private void Start()
	{
		// Create the delays so they only have to be made once.
		m_StartWait = new WaitForSeconds(m_StartDelay);
		m_EndWait = new WaitForSeconds(m_EndDelay);

		SpawnAllTanks(); // Spawn tanks and corresponding scripts
		SetCameraTargets();

		// Once the tanks have been created and the camera is using them as targets, start the game.
		StartCoroutine(GameLoop());
	}


	/// <summary>
	/// Method to spawn tanks and relative scripts for tanks
	/// </summary>
	private void SpawnAllTanks()
	{
		var points = new List<Transform>(SpawnPoints); // creates a new instance of the transform list to hold spawn points

		m_Tanks = new List<TankThinker>(); // list of tanks 
		Debug.Log(GameState.Instance.players);

		foreach (GameState.PlayerState state in GameState.Instance.players)
		{
			Debug.Log("Spawn Player");
			var spawnPointIndex = Random.Range(0, points.Count); // chooses a random spawn point for each player (tank)

			// ... create them, set their player number and references needed for control.
			var tank = Instantiate(m_TankPrefab); // instantiates player with player prefab
			tank.Setup(state, points[spawnPointIndex]); // Setup player and corresponding spawn point

			points.RemoveAt(spawnPointIndex); // removes used spawn point

			m_Tanks.Add(tank); // adds tank to tanks list
		}
	}


	private void SetCameraTargets()
	{
		// Create a collection of transforms the same size as the number of tanks.
		m_CameraControl.m_Targets = new Transform[m_Tanks.Count];

		// For each of these transforms...
		for (int i = 0; i < m_Tanks.Count; i++)
		{
			// ... set it to the appropriate tank transform.
			m_CameraControl.m_Targets[i] = m_Tanks[i].transform;
		}
	}


	// This is called from start and will run each phase of the game one after another.
	private IEnumerator GameLoop()
	{
		GameSettings.Instance.OnBeginRound();

		// Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
		yield return StartCoroutine(RoundStarting());

		// Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
		yield return StartCoroutine(RoundPlaying());

		// Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
		yield return StartCoroutine(RoundEnding());

		// This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
		if (GameSettings.Instance.ShouldFinishGame())
		{
			SceneManager.LoadScene(2);
		}
		else
		{
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		}
	}


	private IEnumerator RoundStarting()
	{
		// As soon as the round starts reset the tanks and make sure they can't move.
		DisableTankControl();

		// Snap the camera's zoom and position to something appropriate for the reset tanks.
		m_CameraControl.SetStartPositionAndSize();

		// Increment the round number and display text showing the players what round it is.
		m_MessageText.text = "ROUND " + GameState.Instance.RoundNumber;

		// Wait for the specified length of time until yielding control back to the game loop.
		yield return m_StartWait;
	}


	private IEnumerator RoundPlaying()
	{
		// As soon as the round begins playing let the players control the tanks.
		EnableTankControl();

		// Clear the text from the screen.
		m_MessageText.text = string.Empty;

		// While there is not one tank left...
		while (!GameSettings.Instance.ShouldFinishRound())
		{
			// ... return on the next frame.
			yield return null;
		}
	}


	private IEnumerator RoundEnding()
	{
		// Stop tanks from moving.
		DisableTankControl();

		var winner = GameSettings.Instance.OnEndRound();

		// Get a message based on the scores and whether or not there is a game winner and display it.
		string message = EndMessage(winner);
		m_MessageText.text = message;

		// Wait for the specified length of time until yielding control back to the game loop.
		yield return m_EndWait;
	}

	// Returns a string message to display at the end of each round.
	private string EndMessage(TankThinker winner)
	{
		return winner != null ? winner.player.PlayerInfo.GetColoredName() + " WINS THE ROUND!" : "DRAW!";
	}

	private void EnableTankControl()
	{
		for (int i = 0; i < m_Tanks.Count; i++)
		{
			if (m_Tanks[i])
				m_Tanks[i].enabled = true;
		}
	}


	private void DisableTankControl()
	{
		for (int i = 0; i < m_Tanks.Count; i++)
		{
			if (m_Tanks[i])
				m_Tanks[i].enabled = false;
		}
	}
}