﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    public Cannon Cannon;

    public GameObject MainCamera;
    public GameObject POVCamera;

    public GameObject TreeSpawner;
    public GameObject Ball;

    public float DistanceScored = 0.0f;
    public float FlyScore = 0.0f;

    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;

        Application.targetFrameRate = 60;
    }

    public void StartGame()
    {
        if (Cannon != null)
        {
            Cannon.GetComponent<Animator>().SetBool("AIM", true);
            Cannon.GetComponent<Animator>().SetBool("GAME_OVER", false);
        }

        DistanceScored = 0.0f;
        FlyScore = 0.0f;

        if (TreeSpawner != null)
        {
            foreach (Transform child in TreeSpawner.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        if (Ball != null)
        {
            Ball.SetActive(false);
        }

        SetActiveMainCamera();

        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void SetActiveMainCamera()
    {
        if (MainCamera != null)
            MainCamera.gameObject.SetActive(true);

        if (POVCamera != null)
            POVCamera.gameObject.SetActive(false);
    }

    public void SetActivePOVCamera()
    {
        if (MainCamera != null)
            MainCamera.gameObject.SetActive(false);

        if (POVCamera != null)
            POVCamera.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
