using UnityEngine;

[CreateAssetMenu(fileName = "ShellScriptableObject", menuName = "ScriptableObjects/NewShellScriptableObjects")]
public class ShellScriptableObject : ScriptableObject
{
    public ShellTypes type;
    public float speed;
    public float damage;
    public ShellView shellView;
}
