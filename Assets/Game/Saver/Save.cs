public class Save
{
    public int CompletedLevel { get; set; }

    public static Save DefaultSave => new(0);

    public Save(int completedLevel)
    {
        CompletedLevel = completedLevel;
    }
}
