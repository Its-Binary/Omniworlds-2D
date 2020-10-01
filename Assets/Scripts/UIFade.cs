using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack;
    public bool shouldFadeFromBlack;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            //Move the alpha value between 0 and 1 (in rgb, 1 is 255) at a fade speed amount
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
                                        Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
                                            Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        shouldFadeFromBlack = false;
        shouldFadeToBlack = true;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
