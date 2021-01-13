/// <summary>
/// Global Game State.
/// </summary>
public static class GameState
{
    private static EGameState _currentState;

    public static void SetState(EGameState state) { _currentState = state; }
    public static EGameState GetState() => _currentState;
}


public enum EGameState { Gameplay, Building, Menu }
