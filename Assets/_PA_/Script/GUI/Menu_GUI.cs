﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_GUI : MonoBehaviour {
    public static Menu_GUI Instance;
	public Text bulletText;
	public Text coinText;
    public Text liveTxt;
    public Text levelName;
    public GameObject scrollGroup;
    bool isScroll1Collected, isScroll2Colltected, isScroll3Collected;
    public GameObject[] stars;
    public Text timerText;
    private void Awake()
    {
        Instance = this;
    }

    bool firstPlay = true;

    private void Start()
    {
        if (DefaultValue.Instance)
            bulletText.enabled = !DefaultValue.Instance.defaultBulletMax;

        if (GameManager.Instance.levelType == LEVELTYPE.BossFight)
        {
            scrollGroup.SetActive(false);
        }

        firstPlay = false;

        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);

        levelName.text = GameManager.Instance.levelType == LEVELTYPE.Normal ? "Level " + GlobalValue.levelPlaying : "BOSS FIGHT";
    }

    private void OnEnable()
    {
        if (firstPlay)
            return;

        stars[0].SetActive(isScroll1Collected);
        stars[1].SetActive(isScroll2Colltected);
        stars[2].SetActive(isScroll3Collected);
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = LevelManager.Instance.currentTimer.ToString("000");
        coinText.text = GlobalValue.SavedCoins.ToString("0");
        if (GameManager.Instance.playerUnlimitedBullet)
            bulletText.text = "Unlimited";
        else
            bulletText.text = GlobalValue.Bullets + "";
        liveTxt.text = GlobalValue.SaveLives + "";
    }

    public void ScrollCollectAnim(int ID, bool noAnimation = false)
    {
        switch (ID)
        {
            case 1:
                isScroll1Collected = true;
                break;
            case 2:
                isScroll2Colltected = true;
                break;
            case 3:
                isScroll3Collected = true;
                break;
            default:
                break;
        }

        stars[0].SetActive(isScroll1Collected);
        stars[1].SetActive(isScroll2Colltected);
        stars[2].SetActive(isScroll3Collected);
    }
}
