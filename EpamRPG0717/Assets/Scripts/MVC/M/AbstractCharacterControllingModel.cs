using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCharacterControllingModel : MonoBehaviour {


    // Setters ///////////////////////////////////

    public abstract void MoveForward();

    public abstract void MoveBackward();

    public abstract void MoveRight();

    public abstract void MoveLeft();


    public abstract void StopMoveForward();

    public abstract void StopMoveBackward();

    public abstract void StopMoveRight();

    public abstract void StopMoveLeft();


    public abstract void Jump();

    public abstract void SpecialAttack();

    public abstract void TurnHorizontal(float shift);

    public abstract void TurnVertical(float shift);







    /// Getters /////////////////////////////////////////////



    public abstract bool IsGrounded { get; }

    public abstract float GetJumpForce();

    public abstract bool IsTargeting{ get; }

    public abstract bool IsSpecialAttacking { get; }

    public abstract float GetForwardVelocity();

    public abstract float GetSidewardVelocity();

    public abstract float GetHorizontalRotation();

    public abstract float GetVerticalRotation();



}
