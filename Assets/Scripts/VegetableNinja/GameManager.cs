using System.Collections;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multText;
    private int multiplier = 1;
    public Image fadeImage;

    private Blade blade;
    private Spawner spawner;

    private int score;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
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

        blade.enabled = true;
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
        }
        if (multiplier < 20 && multiplier > 10)
        {
            multText.text = "Boring";
        }
        if (multiplier < 30 && multiplier > 20)
        {
            multText.text = "Mediocre";
        }
        if (multiplier < 40 && multiplier > 30)
        {
            multText.text = "Good!";
        }
        if (multiplier < 50 && multiplier > 40)
        {
            multText.text = "Great!";
        }
        if (multiplier < 60 && multiplier > 50)
        {
            multText.text = "Perfect!";
        }
        if (multiplier > 60)
        {
            multText.text = "INCREDIBLE!";
        }
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
    }

}