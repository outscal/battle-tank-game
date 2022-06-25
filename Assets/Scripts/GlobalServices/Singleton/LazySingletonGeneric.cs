
namespace GlobalServices
{
    public class LazySingleton
    {
        private static LazySingleton instance;

        private LazySingleton() { }

        public static LazySingleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new LazySingleton();
                }
                return instance;
            }
        }

    }
}
