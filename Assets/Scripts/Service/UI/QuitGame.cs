using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class QuitGame : MonoBehaviour
    {
        public void Quit()
        {
            //If we are running in the editor
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;

            //If we are running in a standalone build of the game
        #elif UNITY_STANDALONE || UNITY_WEBGL
            //Quit the application
            Application.Quit();

        #else

            Application.Quit();

        #endif
        }
    }
}
