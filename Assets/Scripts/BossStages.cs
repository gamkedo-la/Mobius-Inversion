using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStages : MonoBehaviour
{

    public GameObject TopArm;
    public GameObject BottomArm;
    public GameObject Body;
    public GameObject Core;

    public int Stage = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (TopArm == null && BottomArm == null)
        {
            Stage = 2;
        }
        if (Stage == 2 && Body == null)
        {
            Stage = 3;
        }
        if (Stage == 3 && Core == null)
        {
            Stage = 4;
        }



        //additional behaviors go here, stage one movement is currently handled in BossSimpleMovement 
        //Attack patterns are planned to be handled in additional scripts

        if (Stage == 1)
        {

          //behavior for stage one


        }

        if (Stage == 2)
        {

            //behavior for stage 2, both arms are destroyed and it is only the main body


        }
        if (Stage == 3)
        {


            //behavior for stage 3, the outer body is destroyed and only the core remains

        }

        if (Stage == 4)
        {

            //the boss is dead, any on death triggers go here


        }


    }
}
