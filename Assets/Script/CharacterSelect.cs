using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characterss;
    public Button unlockButton;
    public TextMeshProUGUI coinsText;
    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject obj in skins)
            obj.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        foreach(Character c in characterss)
        {
            if(c.price == 0)
                c.isUnlocked =true;
            else
            {
/*                if (PlayerPrefs.GetInt(c.name, 0) == 0) //doan nay tom gon thanh 1 dong code
                {
                    c.isUnlocked = false;
                }
                else
                {
                    c.isUnlocked= true; 
                }*/
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }
    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;
        skins[selectedCharacter].SetActive(true);
        if (characterss[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    } 
    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length -1;
        skins[selectedCharacter].SetActive(true);
        if (characterss[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI() ;
    }
    public void UpdateUI()
    {
        coinsText.text = "Price: " + PlayerPrefs.GetInt("NumberOfCoins", 0);
        if (characterss[selectedCharacter].isUnlocked == true)
        {
            unlockButton.gameObject.SetActive(false);
        }
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characterss[selectedCharacter].price;
            if(PlayerPrefs.GetInt("NumberOfCoins", 0) < characterss[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true) ;
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }
    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = characterss[selectedCharacter].price;
        PlayerPrefs.SetInt("NumberOfCoins", coins - price);
        PlayerPrefs.SetInt(characterss[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characterss[selectedCharacter].isUnlocked = true;
        UpdateUI() ;
    }
}
