using UnityEngine;

[RequireComponent(typeof(ObjectSceneCleaner))]
public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private DeathZoneAnimationController _deathzone;

    private ObjectSceneCleaner _objectCleaner;

    private void Awake()
    {
        _objectCleaner = GetComponent<ObjectSceneCleaner>();
    }
    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endScreen.ResetButtonClicked += OnResetButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endScreen.ResetButtonClicked -= OnResetButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        
        StartGame();
    }

    private void OnResetButtonClick()
    {
        _endScreen.Close();

        StartGame();
    }

    private void StartGame()
    {
        _objectCleaner.Clean();

        _deathzone.SetAnimationState(true);

        _enemyGenerator.Begin();

        Time.timeScale = 1.0f;

        _player.gameObject.SetActive(true);
        _player.Reset();
    }

    private void OnGameOver()
    {
        _player.gameObject.SetActive(false);
        _enemyGenerator.Stop();

        _deathzone.SetAnimationState(false);

        Time.timeScale = 0;

        _endScreen.Open();
    }
}
