using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int index = 0;
    public float currentTime;
    public float songTime;
    public float[] timeStamps, direction, speed;
    public GameObject[] obstacles;

    void Update() {
        if (currentTime < songTime) {
            currentTime += Time.deltaTime;
        } else {
            Debug.Log("You Win");
        }
        if (currentTime > timeStamps[index]) {
            obstacles[index].SetActive(true);
            if (direction[index] == 0) {
                // from left
                obstacles[index].GetComponent<Rigidbody2D>().velocity = new Vector2(speed[index], 0);
            } else if (direction[index] == 1) {
                // from right
                obstacles[index].GetComponent<Rigidbody2D>().velocity = new Vector2(speed[index] * -1, 0);
            } else if (direction[index] == 2) {
                // from up
                obstacles[index].GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed[index] * -1);
            }
            index += 1;
        }
    }
}
