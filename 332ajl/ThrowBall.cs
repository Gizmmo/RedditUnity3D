using System;

public class ThrowBall : MonoBehaviour {
    public float increaseRate;
    public GameObject AimAssist;

    private PickUpBallScript pickUpBallScript;
    private bool holding;
    private float strength;
    private RigidBody aaRb;
    private GameObject createdAimAssist;  //A created object from the AimAssist prefab

    void Start() {
        //I am assuming this script is attached to this game object
        //if not you need to have a refrence to the game object 
        //that PickUpBall is actually on
        pickUpBallScript = GetComponent<PickUpBall>();

        //Instantiated here so as to help performance
        createdAimAssist = Instantiate(AimAssist);

        //The Rigidbody was referencing a prefabs rigid body
        //it should instead refrenece the created game objects
        //RigidBody
        aaRb = createdAimAssist.GetComponent<RigidBody>();
    }

    void FixedUpdate() {
        //Can just use the straight reference to the script rather
        //then update a bool every frame
        //Also switched to Fire1 in case user is using a controller
        if (pickUpBallScript.holding && Input.GetKey("Fire1")) {
            strength += increaseRate;
            aaRb.AddForce(strength, 0, 0);
            //Removed the instantiate as that is quite heavy on the
            //engine and will quickly cause performance issues
        }
    }
}
