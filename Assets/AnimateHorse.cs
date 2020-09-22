using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateHorse : MonoBehaviour
{
    public float pos;
    public float newPos;
    public double posRounded;
    public double newPosRounded;

    public GameObject horseObj;
    public Animator animController;
    public string animControllerName;

    public bool playAnim = false;

    // Start is called before the first frame update
    void Start()
    {
        animController = horseObj.gameObject.GetComponent<Animator>();
        animController.runtimeAnimatorController = Resources.Load($"{animControllerName}") as RuntimeAnimatorController;

        pos = transform.position.z;
        posRounded = System.Math.Round(pos,3);
    }

    // Update is called once per frame
    void Update()
    {
        newPos = transform.position.z;
        newPosRounded = System.Math.Round(newPos,3);

        if (animController != null && animController.runtimeAnimatorController != null)
            {
                animController.SetBool("isRunning", false);               
            }

        if(newPosRounded != posRounded)
        {
            Debug.Log("Moving! Old position Z: " + posRounded + ", New position Z: " + newPosRounded);

            posRounded = newPosRounded;

            if (animController != null && animController.runtimeAnimatorController != null)
            {
                animController.SetBool("isRunning", true);               
            }
        }   
    }
}
