using UnityEngine;

public class MonoSingeltonGeneric<T> : MonoBehaviour where T:MonoBehaviour{

    private static T instance;
    static object m_lock = new object();    

    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
    //``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
    
    public static T getInstance(){

        lock(m_lock){                                           //lock prevents a section to be accessed simultaniously by two threads
            if(instance==null){
                instance = FindObjectOfType<T>();               //checks for the instance in hierarchy
                if(instance==null){
                    GameObject obj = new GameObject();          //creates a instance
                    obj.name = typeof(T).ToString();    
                    instance = obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                    return instance;                            //returns newly created instance
                }
            }
        }
        return instance;                                        //returns already created instance
    }
}
