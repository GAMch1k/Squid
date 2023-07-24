using UnityEngine;

public class TimeManager : MonoBehaviour {
    private int _currentRun;
    private int _currentTick;

    public int levelTimeSeconds = 20;
    public int maxTimeCycles = 3;
    private int _levelTimeTicks;
    
    public delegate void OnNewTimeCycle();
    public delegate void OnGameOver();

    public static OnNewTimeCycle NewTimeCycleEvent;
    public static OnGameOver GameOverEvent;
    
    private void Start()
    {
        _levelTimeTicks = levelTimeSeconds * 50;
        _currentRun = -1;
    }
    
    private void FixedUpdate()
    {
        if (_currentRun > maxTimeCycles)
        {
            return;
        }
        _currentTick++;
        if (_currentRun == -1 && _currentTick > 0)
        {
            _NewTimeCycle();
            return;
        }
        if (_currentTick >= _levelTimeTicks)
        {
            _NewTimeCycle();
        }
    }

    void Update()
    {
        if (_currentTick < 25)
        {
            return;
        }

        if (Input.GetButton("Fire1") && _currentRun <= maxTimeCycles)
        {
            _NewTimeCycle();
        }
    }

    private void _NewTimeCycle()
    {
        _currentRun++;
        _currentTick = 0;
        
        if (_currentRun > maxTimeCycles)
        {
            GameOverEvent?.Invoke();
            return;
        }

        NewTimeCycleEvent?.Invoke();
    }

    public int GetCurrentTick()
    {
        return _currentTick;
    }
    
    public int GetCurrentRun()
    {
        return _currentRun;
    }

    public int GetMaxTimeCycles()
    {
        return maxTimeCycles;
    }

    public int GetSecondsRemaining()
    {
        return (int)((_levelTimeTicks - _currentTick) / 50.0);
    }
}
