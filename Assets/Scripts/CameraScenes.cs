using UnityEngine;

public class CameraScenes : MonoBehaviour
{

    [SerializeField] Transform[] shots;
    [SerializeField] float driftingSpeed = 1f;
    [SerializeField] float driftingDuration = 6f;
    

    int current;
    float timer;

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

        if (timer >= driftingDuration)
        {
            timer = 0;

            int next;
            do { next = Random.Range(0, shots.Length); } while (next == current);

            current = next;
            transform.position = shots[current].position;
            transform.rotation = shots[current].rotation;
        }
    }
}