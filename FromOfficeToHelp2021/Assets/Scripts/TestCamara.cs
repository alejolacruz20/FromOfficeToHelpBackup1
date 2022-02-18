using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamara : MonoBehaviour
{
    Transform camCuerpo;
    bool startNextRot = true;
    public bool rotRight;
    public float yaw;
    public float pitch;
    public float secondsToRot;
    public float rotSwitchTime;

    // Start is called before the first frame update
    void Start()
    {
        camCuerpo = transform.GetChild(0);
        camCuerpo.localRotation = Quaternion.AngleAxis(pitch, Vector3.right);
        SetUpStartRotation();
    }

    void Update()
    {
        if (startNextRot && rotRight)
        {
            StartCoroutine(Rotate(yaw,secondsToRot));
        }
        else if (startNextRot && !rotRight)
        {
            StartCoroutine(Rotate(-yaw, secondsToRot));
        }
    }

    // Update is called once per frame
    IEnumerator Rotate(float yaw, float duration)
    {
        startNextRot = false;

        Quaternion initialRotation = transform.rotation;

        float timer = 0;

        while (timer < duration) 
        {
            timer += Time.deltaTime;
            transform.rotation = initialRotation * Quaternion.AngleAxis(timer / duration * yaw, Vector3.up);
            yield return null;
        }

        yield return new WaitForSeconds(rotSwitchTime);

        startNextRot = true;
        rotRight = !rotRight;
    }

    void SetUpStartRotation() 
    {
        if (rotRight)
        {
            transform.localRotation = Quaternion.AngleAxis(-yaw / 2, Vector3.up);
        }
        else
        {
            transform.localRotation = Quaternion.AngleAxis(yaw / 2, Vector3.up);
        }
    }
}
