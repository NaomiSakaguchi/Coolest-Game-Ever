using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // para acessar o objeto UnlockButton
using TMPro; // namespace para acessar o objeto CoinsText

public class CharacterSelect : MonoBehaviour // script attached to the Character object and displayed in the ShopMenu
{ 

    public GameObject[] skins; // cria um array chamado skins de GameObjects da hierarquia da Unity, arrastar os Players para dentro deles
    public int selectedCharacter; // vari�vel que armazena o �ndice da array skins e characters

    public Character[] characters; // cria um array chamado characters de objetos da classe Character, que s�o as caracteristicas de cada skin a serem informadas na Unity

    public Button unlockButton; // assign o UnlockBotton na Unity

    public TextMeshProUGUI coinsText; // assign o CoinsText na Unity

    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 4);

        foreach (GameObject player in skins)
        {
            player.SetActive(false);
        }

        skins[selectedCharacter].SetActive(true);

        foreach (Character c in characters)
        {
            if (c.price == 0)
            {
                c.isUnlocked = true;
            }
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }

            /*esse else equivale a: 
             else 
            {
                if(PlayerPrefas.GetInt(c.name, 0) == 0)
                {
                    c.isUnlocked = false;
                }
                else
                {
                    c.isUnlocked = true;
                }
            }
             */

            UpdateUI(); // chama o metodo que atualiza o numero de moedas e ativa/desativa UnlockButton
        }
    }

    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        AudioManager.instance.Play("Click");

        if (selectedCharacter == skins.Length)
        {
            selectedCharacter = 0;
        }

        skins[selectedCharacter].SetActive(true);

        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI(); // chama o metodo que atualiza o numero de moedas e ativa/desativa UnlockButton
    }

    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        AudioManager.instance.Play("Click");
        selectedCharacter--;
        if (selectedCharacter == -1)
        {
            selectedCharacter = skins.Length - 1;
        }

        skins[selectedCharacter].SetActive(true);

        if(characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI(); // chama o metodo que atualiza o numero de moedas e ativa/desativa UnlockButton 
    }

    public void UpdateUI()
    {
        coinsText.text = "Coins: " + PlayerPrefs.GetInt("NumberOfCoins", 0); // will display/update number of coins

        // display o price correto no UnlockButton das skins
        unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price: " + characters[selectedCharacter].price;

        // se o character estiver unlocked (price=0) ent�o o bot�o de PRICE estar� desabilitado, pois ele j� foi adquirido
        if (characters[selectedCharacter].isUnlocked == true)
         {
            unlockButton.gameObject.SetActive(false)
;        }
        else // se ele n�o estiver unlocked
        {
            // se o nr de moedas for inferior ao price, o bot�o de price estar� habilitado, mas n�o poder� ter intera��es
            if(PlayerPrefs.GetInt("NumberOfCoins", 0) < characters[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else // mas se o numero de moedas for maior que o pre�o, o bt de price estar� habilitado, e poder� ter intera��es
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock() //m�todo que ap�s a compra, subtrai a quantidade de moedas e habilita a jogar com o Player escolhido
    {
        int coins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        int price = characters[selectedCharacter].price;
        PlayerPrefs.SetInt("NumberOfCoins", coins - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked = true;
        UpdateUI();
    }
    
}
