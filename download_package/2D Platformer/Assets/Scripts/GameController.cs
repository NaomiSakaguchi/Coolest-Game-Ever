using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

public class GameController : MonoBehaviour // script attached to the GameController object
 // este script controla todo o sistema do jogo, UI, GameOver, variáveis globais como pontuação, checkpoints, que precisam ser salvas mesmo se a sessao termina
{
    //variáveis globais (public) e permanentes (static) a serem usadas em outros scripts
    public static bool isGameOver;
    public static Vector2 lastCheckpointPos = new Vector2(-5, 0.7f);
    public static int numberOfCoins;

    [SerializeField] int lives;
    [SerializeField] TextMeshProUGUI livesText;

    //assign in Unity
    public GameObject gameOverPanel;
    public TextMeshProUGUI coinsText;
    public GameObject[] playerPrefabs; // cria um array de Players
    public CinemachineVirtualCamera VCam;
    public GameObject pauseMenuPanel;


    int characterIndex;

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 4); // verifica se há valor stored na key SelectedCharacter. se não houver vai atribuir 0
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckpointPos, Quaternion.identity); // vai instanciar o Player com o index selecionado, na posição do lastcheckPointPosition, e na rotação zero

        VCam.m_Follow = player.transform;

        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);

        isGameOver = false; //inicia com false o bool
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckpointPos;
        lives = 3;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        coinsText.text = numberOfCoins.ToString();
        

        if (isGameOver) //o GameOver fica true conforme script PlayerCollision
        {
            gameOverPanel.SetActive(true);
            PlayerPrefs.SetInt("NumberOfCoins", 0);
            GameObject.FindGameObjectWithTag("Player").SetActive(false);

        }


    }

    public void RestartLevel()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //pega a cena atual pelo index
        
    }

    public void PauseGame()
    {
        AudioManager.instance.Play("Click");
        Time.timeScale = 0; // o jogo será pausado se = 0. o default = 1 e se aumentar o jogo vai mais rapido
        pauseMenuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        AudioManager.instance.Play("Click");
        Time.timeScale = 1; // o jogo volta à velocidade normal
        pauseMenuPanel.SetActive(false); // desativa o PauseMenuPanel
    }

    public void GoToMenu()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene(1); // carrega a cena com index 0 (Menu)
        lastCheckpointPos = new Vector2(-5, 0.7f);
        //PlayerPrefs.SetInt("NumberOfCoins", 0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        lastCheckpointPos = new Vector2(-5, 0.7f);
    }

    public void ProcessPlayerDeath() // metodo a ser chamado no script do Player quando ele é atingido
    {
        if (lives > 1) // se a vida estiver > 1, vai retirar 1 
        {
            TakeLife();
            AudioManager.instance.Play("Hit");
        }
        else
        {
            TakeLife();
            AudioManager.instance.Play("Hit");
            isGameOver = true;
            AudioManager.instance.Play("GameOver");
        }
    }

    private void TakeLife()
    {
        lives--; // retira 1 vida
        livesText.text = lives.ToString(); // update o numero de vidas
    }
}
