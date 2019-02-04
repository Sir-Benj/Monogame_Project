using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Onwards.Components
{
    public class InputHandler : GameComponent
    {
        #region Fields

        private static KeyboardState currKBState;
        private static KeyboardState prevKBState;

        private static GamePadState[] currGPStates;
        private static GamePadState[] prevGPStates;

        #endregion

        #region Properties

        public static KeyboardState CurrentKeyboardState
        {
            get { return currKBState; }
        }

        public static KeyboardState PreviousKeyboardState
        {
            get { return prevKBState; }
        }

        public static GamePadState[] CurrentGamePadStates
        {
            get { return currGPStates; }
        }

        public static GamePadState[] PreviousGamePadStates
        {
            get { return prevGPStates; }
        }

        #endregion

        #region Constructor

        public InputHandler(Game game)
            : base(game)
        {
            currKBState = Keyboard.GetState();
            prevKBState = Keyboard.GetState();


            currGPStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                currGPStates[(int)index] = GamePad.GetState(index);
            }
            prevGPStates = (GamePadState[])currGPStates.Clone();
        }

        #endregion

        #region XNA Methods

        public override void Update(GameTime gameTime)
        {
            InputHandler.prevKBState = InputHandler.currKBState;
            InputHandler.currKBState = Keyboard.GetState();

            InputHandler.prevGPStates = (GamePadState[])InputHandler.currGPStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                InputHandler.currGPStates[(int)index] = GamePad.GetState(index);
            }

            base.Update(gameTime);
        }

        #endregion

        #region Keyboard Methods
        public static void FlushInput()
        {
            currKBState = prevKBState;
            currGPStates = (GamePadState[])prevGPStates.Clone();
        }

        public static bool KeyPressed(Keys key)
        {
            return currKBState.IsKeyDown(key) && prevKBState.IsKeyUp(key);
        }

        public static bool KeyReleased(Keys key)
        {
            return currKBState.IsKeyUp(key) && prevKBState.IsKeyDown(key);
        }

        public static bool KeyDown(Keys key)
        {
            return currKBState.IsKeyDown(key);
        }

        #endregion

        #region GamePad Methods

        public static bool ButtonPressed(Buttons button, PlayerIndex index)
        {
            return currGPStates[(int)index].IsButtonDown(button) &&
                   prevGPStates[(int)index].IsButtonUp(button);
        }

        public static bool ButtonReleased(Buttons button, PlayerIndex index)
        {
            return currGPStates[(int)index].IsButtonUp(button) &&
                   prevGPStates[(int)index].IsButtonDown(button);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex index)
        {
            return currGPStates[(int)index].IsButtonDown(button);
        }
        #endregion
    }
}
