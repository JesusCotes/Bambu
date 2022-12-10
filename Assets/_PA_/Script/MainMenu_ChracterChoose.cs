﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_ChracterChoose : MonoBehaviour
{
	[Tooltip("The unique character ID")]
	public int characterID;
	public int price;
	public GameObject CharacterPrefab;
	public bool unlockDefault = false;
	public GameObject UnlockButton;

	public Image frameImage;
	public Sprite frameActive, frameDisative;

	public Text pricetxt;
	public Text state;

	public GameObject heartIcon;
	public Text meleeDamageTxt;

	bool isUnlock;

	void Start()
	{
		frameImage.sprite = frameDisative;

		if (unlockDefault)
			isUnlock = true;
		else
			isUnlock = PlayerPrefs.GetInt(GlobalValue.Character + characterID, 0) == 1 ? true : false;

		UnlockButton.SetActive(!isUnlock);

		pricetxt.text = price.ToString();

		//update the hearts of player
		for(int i=1;i<CharacterPrefab.GetComponent<Player>().maxHealth; i++)
        {
			Instantiate(heartIcon, heartIcon.transform.parent);
        }

		meleeDamageTxt.text = ": " +  CharacterPrefab.GetComponent<MeleeAttack>().meleeDamage;
	}

	void Update()
	{
		if (!isUnlock)
			return;

		if (PlayerPrefs.GetInt(GlobalValue.ChoosenCharacterID, 1) == characterID)
		{
			state.text = "Equipped";
			frameImage.sprite = frameActive;
		}
		else
		{
			state.text = "Equip";
			frameImage.sprite = frameDisative;
		}
	}

	public void Unlock()
	{
		if (GlobalValue.SavedCoins >= price)
		{
			GlobalValue.SavedCoins -= price;
			DoUnlock();
		}
	}

	void DoUnlock()
    {
		PlayerPrefs.SetInt(GlobalValue.Character + characterID, 1);
		isUnlock = true;
		UnlockButton.SetActive(false);
		SoundManager.PlaySfx(SoundManager.Instance.soundPurchased);
	}

	public void Pick()
	{
		SoundManager.Click();
		if (!isUnlock)
		{
			Unlock();
			return;
		}

		PlayerPrefs.SetInt(GlobalValue.ChoosenCharacterID, characterID);
		PlayerPrefs.SetInt(GlobalValue.ChoosenCharacterInstanceID, CharacterPrefab.GetInstanceID());
		CharacterHolder.Instance.CharacterPicked = CharacterPrefab;
	}
}
