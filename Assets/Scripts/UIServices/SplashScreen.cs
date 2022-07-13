using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIServices
{ 
    // To handle custom splash screen behaviour.
    public class SplashScreen : MonoBehaviour
    {
        // Splash screen image.
        public Image image;

        async void Start()
        {
            // To add certain amount of delay.
            await new WaitForSeconds(3f);

            float newAlpha = 1;
            Color panelColor = image.color;

            // Fades out image in particular amount of time.
            while (newAlpha > 0)
            {
                newAlpha -= Time.deltaTime;
                newAlpha = Mathf.Max(newAlpha, 0f);

                panelColor.a = newAlpha;
                image.color = panelColor;

                await new WaitForSeconds(0.001f);
            }

            // Loads next scene after completion of splash screen.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
