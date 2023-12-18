using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Services.Factory;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _loadingCurtain;
    private readonly IUIFactory _uiFactory;
    private readonly IStaticDataService _staticData;

    public LoadLevelState(GameStateMachine gameGameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IUIFactory uiFactory, IStaticDataService staticData)
    {
      _gameStateMachine = gameGameStateMachine;
      _sceneLoader = sceneLoader;
      _loadingCurtain = loadingCurtain;
      _uiFactory = uiFactory;
      _staticData = staticData;
    }

    public void Enter(string sceneName)
    {
      _loadingCurtain.Show();
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() =>
      _loadingCurtain.Hide();

    private void OnLoaded()
    {
      InitGameWorld();
      
      _gameStateMachine.Enter<GameLoopState>();
    }
    
    private void InitGameWorld()
    {
      LevelStaticData levelData = LevelStaticData();

      InitUIRoot();
      InitGameplayWindow();
      InitDeviceSpawners(levelData);
    }

    private LevelStaticData LevelStaticData() => 
      _staticData.ForLevel(SceneManager.GetActiveScene().name);

    private void InitUIRoot() => 
      _uiFactory.CreateUIRoot();

    private void InitGameplayWindow() => 
      _uiFactory.CreateGameplayWindow();

    private void InitDeviceSpawners(LevelStaticData levelData) => 
      _uiFactory.CreateDeviceSpawners(levelData);
  }
}