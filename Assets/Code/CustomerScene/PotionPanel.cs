using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPanel : MonoBehaviour
{
    public GameObject potionPrefab;

    public float xOffset = 2f;
    public float yOffset = 2f;
    public Vector2 startPos = new Vector2(0f, 0f);

    void Start()
    {
        int i = 0;
        foreach (Potion potion in OrderSession.instance.completedPotions) {
            GameObject obj = Instantiate(potionPrefab);
            int column = i % 2;
            int row = i / 2;

            Vector3 position = new Vector3(
                startPos.x + (column * xOffset),
                startPos.y - (row * yOffset),
                -1f
            );

            obj.transform.localPosition = position;
            ++i;
        }
    }
}
