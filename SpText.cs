using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpText : MonoBehaviour
{

    private float intervalTime = 0.0f;
    private int printCount = 0;
    private float updateTime = 0.25f;
    private float maxX;
    private float maxY;
    private float maxZ;
    private float minX;
    private float minY;
    private float minZ;
    private string state = "";
    public Text spText;

    // Use this for initialization
    void Start()
    {
        spText = this.GetComponent<Text>();
        this.SetSpeed("");
        ResetMinMax();
    }

    // Update is called once per frame
    void Update()
    {
        intervalTime += Time.deltaTime;
        if (intervalTime >= updateTime)
        {
            // 加速度センサの値を取得
            Vector3 val = Input.acceleration;
            Debug.Log("kasokuuuuuuuuuuuuu" + val);
            //string kasoku = val.ToString();

            if(val.x > maxX)
            {
                maxX = val.x;
            }
            else if(val.x < minX)
            {
                minX = val.x;
            }

            if (val.y > maxY)
            {
                maxY = val.y;
            }
            else if (val.y < minY)
            {
                minY = val.y;
            }

            if (val.z > maxZ)
            {
                maxZ = val.z;
            }
            else if (val.z < minZ)
            {
                minZ = val.z;
            }

            printCount++;

            if(printCount >= 4)
            {
                if (maxZ >= 0.1 && maxZ < 1.0)
                {
                    state = "歩き";
                }
                else if (maxZ >= 1.0)
                {
                    if(maxY - minY >= 1.0)
                    {
                        state = "走り";
                    }
                    else
                    {
                        state = "車移動";
                    }
                }
                else
                {
                    state = "止まっている？";
                }
                this.SetSpeed(state);
                ResetMinMax();
                printCount = 0;
            }

            intervalTime = 0.0f;
        }
        
    }

    public void SetSpeed(string speed)
    {
        spText.text = speed;
    }

    private void ResetMinMax()
    {
        maxX = 0.0f;
        maxY = -1.0f;
        maxZ = 0.0f;
        minX = 0.0f;
        minY = -1.0f;
        minZ = 0.0f;
    }
}
