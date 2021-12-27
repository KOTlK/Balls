using UnityEngine;
using Extensions;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private Transform _ballsParent;
    [SerializeField] private Transform _particlesParent;
    [SerializeField] private ParticleSystem _particlesPrefab;
    [SerializeField] private Settings _settings;
    [Space]
    [Header("UI")]
    [SerializeField] private Canvas _pauseMenuCanvas;
    [SerializeField] private Canvas _inGameMenuCanvas;
    [SerializeField] private Canvas _loseScreenCanvas;

    private ObjectsPool _objectsPool;
    private IDifficulty _difficulty;
    private GameTick _gameTime;
    private BallsSpawner _ballSpawner;
    private Camera _mainCamera;
    private GamePause _gamePause;
    private Particles _particles;
    private Player _player;
    private UI _ui;
    private BallHandler _ballHandler;
    private UIHandler _uiHandler;
    private Localization _localization;

    private float SpawnOffsetX => _settings.SpawnOffsetX;
    private float SpawnOffsetY => _settings.SpawnOffsetY;

    private void Awake()
    {
        _objectsPool = new ObjectsPool();
        _gamePause = new GamePause();
        _localization = new Localization(Languages.English);

        _particles = new Particles(_settings.MaxBallsAmount, _particlesPrefab, _particlesParent, _gamePause);
        _particles.Init();

        _gameTime = new GameTick();
        _ballHandler = new BallHandler();
        _player = new Player(_ballHandler);
        _difficulty = new IncreaseDifficultyByTime(_settings.TimeBeforeDifficultyIncrease, _gameTime);

         var ballData = new BallInitialData() { Difficulty = _difficulty, 
                                            Pool = _objectsPool, 
                                            Particles = _particles, 
                                            BallHandler = _ballHandler, 
                                            GamePause = _gamePause,
        };

        _mainCamera = Camera.main;

         var spawnerData = new SpawnerData() { InitialData = ballData,
                                           MaxBallsOnScreen = _settings.MaxBallsOnScreen, 
                                           MaxXSpawnPositon = _mainCamera.GetMinBounds().x + SpawnOffsetX,
                                           MinXSpawnPositon = _mainCamera.GetMaxBounds().x - SpawnOffsetX,
                                           YPosition = _mainCamera.GetMaxBounds().y + SpawnOffsetY,
                                           Parent = _ballsParent,
                                           Prefab = _ballPrefab,
                                           MaxBallsAmount = _settings.MaxBallsAmount,
                                           BallHandler = _ballHandler
        };
        _ballSpawner = new BallsSpawner(spawnerData);

        var screenData = new OnScreenData() { HP = _player.Hp, Score = _player.Score };
        var inGameUIInitialData = new InGameUIInitialData() { Canvas = _inGameMenuCanvas, GamePause = _gamePause, ScreenData = screenData, Localization = _localization };
        var loseScreenInitData = new LoseScreenInitialData() { Canvas = _loseScreenCanvas, Score = _player.Score, Hp = _player.Hp, Localization = _localization };
        _ui = new UI(_pauseMenuCanvas, inGameUIInitialData, loseScreenInitData);
        _ui.Init();
        _uiHandler = new UIHandler(_ui, _gamePause, _player.Hp);
        _uiHandler.Init();
    }


    private void Update()
    {
        _gameTime.Update();
        _difficulty.Update();
        _ballSpawner.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _localization.ChangeLanguage(Languages.Russian);
        }
    }

}
