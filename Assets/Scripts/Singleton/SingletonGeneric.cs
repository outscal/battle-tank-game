

public class SingletonGeneric<T> where T: class, new()
{
    private static T instance = null;
    public static T Instance { get 
        {
            instance ??= new();
            return instance;
        }
    }
    
}
