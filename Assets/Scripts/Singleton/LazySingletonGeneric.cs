
public class LazySingletonGenric
{
    private static LazySingletonGenric instance;

    private LazySingletonGenric() { }

    public static LazySingletonGenric Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new LazySingletonGenric();
            }
            return instance;
        }
    }
}
