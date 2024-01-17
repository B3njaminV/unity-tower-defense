
public class GameSaver
{

    private IDataSaver _dataSaver;

    public GameSaver(IDataSaver dataSaver)
    {
        _dataSaver = dataSaver;
    }

    public void UpdateCurrentLevelSave(int level)
    {
        if (level > GetSavedLevel())
        {
            _dataSaver.SaveInt("level", level);
        }
    }

    public int GetSavedLevel()
    {
        return _dataSaver.LoadInt("Level") ?? 0;
    }

}
