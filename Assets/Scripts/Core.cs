using UnityEngine;
using Extensions;

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

    private ObjectsPool _objectsPool;
    private IDifficulty _difficulty;
    private GameTick _gameTime;
    private BallsSpawner _ballSpawner;
    private Camera _mainCamera;
    private GamePause _gamePause;
    private Particles _particles;
    private BallInitialData _ballData;
    private SpawnerData _spawnerData;
    private Player _player;
    private UI _ui;
    private OnScreenData _screenData;
    private BallHandler _ballHandler;

    private float SpawnOffsetX => _settings.SpawnOffsetX;
    private float SpawnOffsetY => _settings.SpawnOffsetY;

    private void Awake()
    {
        _objectsPool = new ObjectsPool();
        _gamePause = new GamePause();

        _particles = new Particles(_settings.MaxBallsAmount, _particlesPrefab, _particlesParent, _gamePause);
        _particles.Init();

        _gameTime = new GameTick();
        _ballHandler = new BallHandler();
        _player = new Player(_ballHandler);
        _difficulty = new IncreaseDifficultyByTime(_settings.TimeBeforeDifficultyIncrease, _gameTime);

        _ballData = new BallInitialData() { Difficulty = _difficulty, 
                                            Pool = _objectsPool, 
                                            Particles = _particles, 
                                            BallHandler = _ballHandler, 
                                            GamePause = _gamePause,
        };

        _mainCamera = Camera.main;

        _spawnerData = new SpawnerData() { InitialData = _ballData,
                                           MaxBallsOnScreen = _settings.MaxBallsOnScreen, 
                                           MaxXSpawnPositon = _mainCamera.GetMinBounds().x + SpawnOffsetX,
                                           MinXSpawnPositon = _mainCamera.GetMaxBounds().x - SpawnOffsetX,
                                           YPosition = _mainCamera.GetMaxBounds().y + SpawnOffsetY,
                                           Parent = _ballsParent,
                                           Prefab = _ballPrefab,
                                           MaxBallsAmount = _settings.MaxBallsAmount,
                                           BallHandler = _ballHandler
        };
        _ballSpawner = new BallsSpawner(_spawnerData);

        _screenData = new OnScreenData() { HP = _player.Hp, Score = _player.Score };
        _ui = new UI(_pauseMenuCanvas, _inGameMenuCanvas, _screenData);
        _ui.Init();
    }


    private void Update()
    {
        _gameTime.Update();
        _difficulty.Update();
        _ballSpawner.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gamePause.Pause();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _gamePause.Unpause();
        }
    }
}
