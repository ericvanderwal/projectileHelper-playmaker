// Custom Action by DumbGameDev
// www.dumbgamedev.com
// Eric Vander Wal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Projectile Helper")]
    [Tooltip ("Update a projectile's current position and velocity, given the gravity and delta time")]
    public class UpdateProjectile : FsmStateAction
    {

		public FsmVector3 currentPosition;
	    public FsmVector3 currentVelocity;
	    public FsmFloat gravityNegative;
	    public FsmFloat deltaTimeElapsed;
	    
	    private Vector3 _currentPosition;
	    private Vector3 _currentVelocity;

	    public FsmBool everyFrame;
	       
	    public override void Reset()
	    {
		    
		    deltaTimeElapsed = null;
		    currentPosition =  null;
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
		    _currentPosition = currentPosition.Value;
		    _currentVelocity = currentVelocity.Value;
		    ProjectileHelper.UpdateProjectile(ref _currentPosition, ref _currentVelocity, gravityNegative.Value, deltaTimeElapsed.Value);
		    currentPosition.Value = _currentPosition;
		    currentVelocity = _currentVelocity;
		    
        }

    }
}
