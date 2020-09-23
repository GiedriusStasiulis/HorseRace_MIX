using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AnimateHorse : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject horseObj;
    public Animator animController;
    public string animControllerName;

    public GameObject vbBtnObj;


    // Start is called before the first frame update
    void Start()
    {
        //vbBtnObj = GameObject.Find("MoveClubsHorseBtn" + "MoveHeartsHorseBtn" + "MoveDiamondsHorseBtn" + "MoveSpadesHorseBtn");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        animController = horseObj.gameObject.GetComponent<Animator>();
        animController.runtimeAnimatorController = Resources.Load($"{animControllerName}") as RuntimeAnimatorController;        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (animController != null && animController.runtimeAnimatorController != null)
        {
            animController.SetBool("isRunning", true);    
            Debug.Log("Button pressed!");       
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (animController != null && animController.runtimeAnimatorController != null)
        {
            animController.SetBool("isRunning", false);       
            Debug.Log("Button released!");       
        }
    }
}
