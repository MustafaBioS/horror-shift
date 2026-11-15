using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraScenes : MonoBehaviour
{

    [SerializeField] Transform[] shots;
    [SerializeField] float driftingSpeed = 1f;
    [SerializeField] float driftingDuration = 6f;
    [SerializeField] float fadeTime = 1f;
    [SerializeField] Animator fade;

    int current;
    float timer;
    bool fading;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current = Random.Range(0, shots.Length);
        transform.position = shots[current].position;
        transform.rotation = shots[current].rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * driftingSpeed * Time.deltaTime;
        timer += Time.deltaTime;

        if (!fading && timer >= driftingDuration - fadeTime)
        {
            fading = true;
            fade.Play("FadeOut");
        }

        if (timer >= driftingDuration)
        {
            timer = 0;
            fading = false;

            int next;
            do { next = Random.Range(0, shots.Length); } while (next == current);

            current = next;
            transform.position = shots[current].position;
            transform.rotation = shots[current].rotation;

            fade.Play("FadeIn");
        }
    }
}