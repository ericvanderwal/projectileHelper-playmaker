// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Determine the velocity of a projectile after a certain time, given its current position and velocity.")]
    public class ComputeVelocityAtTimeAhead : FsmStateAction
    {

	    [UIHint(UIHint.Description)]
	    public string tweenIdDescription = "Use case: you want to fire a catapult projectile to land at a specific position, giving the player exactly 4 seconds of warning time to escape";
	    
	    
	    public FsmVector3 currentPosition;
	    public FsmVector3 currentVelocity;
	    public FsmFloat gravityNegative;
	    public FsmFloat timeAhead;
	    
	    [UIHint(UIHint.Variable)]
	    public FsmVector3 futureVelocity;
	    
	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {
		    
		    currentPosition =  null;
		    timeAhead = null;
		    futureVelocity = null;
		    currentVelocity = null;
		    gravityNegative = null;
			everyFrame = false;

	    }


	    public override void OnEnter()
	    {

		    if (!everyFrame.Value)
		    {
			    doCalculations();
			    Finish();
		    }
		    
	    }
	    
	    
	    public override void OnUpdate()
	    {
		    if (everyFrame.Value)
		    {
			    doCalculations();
		    }
	    }
	    
	   
	    void doCalculations()
	    
	    {
		    futureVelocity.Value = ProjectileHelper.ComputeVelocityAtTimeAhead(currentPosition.Value, currentVelocity.Value, gravityNegative.Value, timeAhead.Value);
		    
        }

    }
}
