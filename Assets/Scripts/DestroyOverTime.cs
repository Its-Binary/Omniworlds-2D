using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float timerToDestroy;

    // Update is called once per frame
    private void Update ()
    {
        timerToDestroy -= Time.deltaTime;

        if(timerToDestroy <= 0)
        {
            Destroy (gameObject);
        }
    }
}