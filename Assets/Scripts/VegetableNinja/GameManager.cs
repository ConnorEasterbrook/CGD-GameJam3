using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;
using TMPro;
using Connoreaster;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multText;
    private int multiplier = 1;
    public Image fadeImage;

    [SerializeField] private CamDragSlicer blade;
    private Spawner spawner;

    public int score;

    public GameObject winScreen;
    public GameObject loseScreen;

    public AudioSource audioSource;
    public AudioClip[] increaseScoreSounds;
    public GameObject spawnerFrenzy1;
    public GameObject spawnerFrenzy2;

    private bool[] soundPlayed = new bool[4];

    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        Time.timeScale = 1f;

        ClearScene();

        /*blade.enabled = true;*/
        spawner.enabled = true;

        score = 0;
        multiplier = 1;
        multText.text = "Lame";
        scoreText.text = score.ToString();
    }

    private void ClearScene()
    {
        Vegetable[] vegetables = FindObjectsOfType<Vegetable>();

        foreach (Vegetable vegetable in vegetables)
        {
            Destroy(vegetable.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore(int points)
    {
        multiplier++;
        score += points * multiplier;
        scoreText.text = score.ToString();
        if(multiplier<10)
        {
            multText.text = "Lame";
            UnFrenzy();
        }
        else if (multiplier < 20 && multiplier > 10)
        {
            multText.text = "Boring";
        }
        else if(multiplier < 30 && multiplier > 20 && !soundPlayed[0])
        {
            audioSource.PlayOneShot(increaseScoreSounds[0]);
            multText.text = "Mediocre";
            soundPlayed[0] = true;
        }
        else if(multiplier < 40 && multiplier > 30 && !soundPlayed[1])
        {
            audioSource.PlayOneShot(increaseScoreSounds[1]);
            multText.text = "Good!";
            soundPlayed[1] = true;
        }
        else if(multiplier < 50 && multiplier > 40 && !soundPlayed[2])
        {
            audioSource.PlayOneShot(increaseScoreSounds[2]);
            multText.text = "Great!";
            soundPlayed[2] = true;
        }
        else if(multiplier < 60 && multiplier > 50 && !soundPlayed[3])
        {
            audioSource.PlayOneShot(increaseScoreSounds[3]);
            multText.text = "Perfect!";
            soundPlayed[3] = true;
        }
        else if(multiplier < 70 && multiplier > 60 && !soundPlayed[4])
        {
            audioSource.PlayOneShot(increaseScoreSounds[4]);
            multText.text = "INCREDIBLE!";
            soundPlayed[4] = true;
        }
        else if(multiplier > 70)
        {
            multText.text = "Frenzy!";
            Frenzy();
        }
    }

    public void Frenzy()
    {
        spawnerFrenzy1.SetActive(true);
        spawnerFrenzy2.SetActive(true);
    }

    public void UnFrenzy()
    {
        for (int i = 0; i < soundPlayed.Length; i++)
        {
            soundPlayed[i] = false;
        }
        spawnerFrenzy1.SetActive(false);
        spawnerFrenzy2.SetActive(false);
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;

        // Fade to white
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);

        NewGame();

        elapsed = 0f;

        // Fade back in
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }

        blade.enabled = true;
    }
    public void gameEnd()
    {
        if(score > 5000)
        {
            winScreen.SetActive(true);
        }
        else
        {
            loseScreen.SetActive(true);
        }
    }

}