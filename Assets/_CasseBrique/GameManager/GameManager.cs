using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int score;
    private int nbBricks = 276;
    private bool gameIsFinished = false;

    // Sound
    public AudioClip music;
    private AudioSource source;

    // UI
    public UIDocument progressBarDocument;
    private ProgressBar progressBar;
    public TMP_Text scoreUi;
    public GameObject winText;

    void Start()
    {
        InstantiateUI();

        resetScore();
        DontDestroyOnLoad(this);
        playMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (nbBricks - score == 0 && !gameIsFinished)
        {
            winText.SetActive(true);
            gameIsFinished = true;
        }
    }

    private void InstantiateUI()
    {
        winText.SetActive(false);
        progressBar = progressBarDocument.rootVisualElement.Q<ProgressBar>("ProgressBar");
        progressBar.value = 0f;
    }

    private void playMusic()
    {
        gameObject.AddComponent<AudioSource>();

        source = GetComponent<AudioSource>();
        source.clip = music;
        source.loop = true;
        source.pitch = 1f;
        source.volume = 0.3f;

        source.Play();

    }

    private void resetScore()
    {
        score = 0;
    }
    
    private void resetGame()
    {
        resetScore();
        winText.SetActive(false);
        gameIsFinished = false;
    }
    
    public void incrementScore()
    {
        score += 1;
        scoreUi.SetText(score.ToString());

        progressBar.value = ((float)score / (float)nbBricks) * 100f;
    }
}
