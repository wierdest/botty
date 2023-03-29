using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Mouse Input Values")]
		public bool grab, letGo;
		public Vector2 mousePosition;

		[Header("Keyboard Input Settings")]
		public bool changeView, generalAction, soundOff, isViewChanged;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = false;
		public bool cursorInputForLook = false;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnGrab(InputValue value)
		{
			GrabInput(value.isPressed);
		}

		public void OnLetGo(InputValue value)
		{
			LetGoInput(value.isPressed);
		}

		public void OnMoveMouse(InputValue value)
		{
			MoveMouseInput(value.Get<Vector2>());
		
		}

		public void OnChangeView(InputValue value)
		{
			ChangeViewInput(value.isPressed);
		}

		public void OnGeneralAction(InputValue value)
		{
			GeneralActionInput(value.isPressed);
		}

		public void OnSoundOnOff(InputValue value)
		{
			SoundOnOffInput(value.isPressed);
		}
#endif

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}
		
		public void LockCursor(bool newState)
		{
			cursorLocked = newState;
			Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
		}

		public void GrabInput(bool newClick)
		{
			grab = newClick;

		}

		public void LetGoInput(bool newClick)
		{
			letGo = newClick;
		}
		public void MoveMouseInput(Vector2 newMousePosition)
		{
			mousePosition = newMousePosition;
		}

		public void ChangeViewInput(bool newView)
		{
			changeView = newView;
			isViewChanged = !isViewChanged;
		}

		public void GeneralActionInput(bool newGeneralActionValue)
		{
			generalAction = newGeneralActionValue;
		}

		public void SoundOnOffInput(bool newSoundOnOff)
		{
			soundOff = newSoundOnOff;
		}
		
	}
	
}