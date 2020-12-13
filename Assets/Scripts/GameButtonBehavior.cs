using UnityEngine.UI;
using UnityEngine;
using Game;


public enum ButtonType
{
    startButton,
    restartButton
}

public class GameButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private ButtonType buttonType;
    Button buttonRef;

    void Start()
    {
        buttonRef = GetComponent<Button>();
        switch (buttonType)
        {
            case ButtonType.startButton:
                buttonRef.onClick.AddListener(GameController.GC.StartGame);
                break;
            case ButtonType.restartButton:
                buttonRef.onClick.AddListener(GameController.GC.RestartGame);
                break;
        }
    }


}
