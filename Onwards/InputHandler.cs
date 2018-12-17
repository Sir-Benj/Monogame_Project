using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Onwards
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        #region Fields

        static KeyboardState kbState;
        static KeyboardState kbLastState;

        static GamePadCapabilities gpCapabilities;

        static GamePadState gpState;
        static GamePadState gpLastState;

        #endregion

        #region Properties
        public static KeyboardState KeyboardState
        {
            get { return kbState; }
        }

        public static KeyboardState KeyboardLastState
        {
            get { return kbLastState; }
        }

        public static GamePadCapabilities GamePadCapabilities
        {
            get { return gpCapabilities; }
        }

        public static GamePadState GamepadState
        {
            get { return gpState; }
        }

        public static GamePadState GamepadLastState
        {
            get { return gpLastState; }
        }
        #endregion

        #region Constructor
        public InputHandler(Game game) : base(game)
        {
            kbState = Keyboard.GetState();

            gpCapabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (gpCapabilities.IsConnected)
                gpState = GamePad.GetState(PlayerIndex.One);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            kbLastState = kbState;
            kbState = Keyboard.GetState();

            gpLastState = gpState;
            gpState = GamePad.GetState(PlayerIndex.One);

            base.Update(gameTime);
        }
        #endregion

        #region General Methods
        public static void ResetState()
        {
            kbLastState = KeyboardState;

            gpState = gpLastState;
        }
        #endregion

        #region Keyboard Methods
        public static bool KeyReleased(Keys key)
        {
            return kbState.IsKeyUp(key) && kbLastState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return kbState.IsKeyDown(key) && kbLastState.IsKeyUp(key);
        }

        public static bool KeyDown(Keys key)
        {
            return kbState.IsKeyDown(key);
        }
        #endregion

        #region Gamepad Methods
        public static bool ButtonReleased(Buttons btn)
        {
            return gpState.IsButtonUp(btn) && gpLastState.IsButtonDown(btn);
        }

        public static bool ButtonPressed(Buttons btn)
        {
            return gpState.IsButtonDown(btn) && gpLastState.IsButtonUp(btn);
        }

        public static bool ButtonDown(Buttons btn)
        {
            return gpLastState.IsButtonDown(btn);
        }

        public static bool LeftStickLeft()
        {
            if (gpCapabilities.HasLeftXThumbStick)
                return gpState.ThumbSticks.Left.X < -0.2f;
            else
                return false;
        }
        
        public static bool LeftStickRight()
        {
            if (gpCapabilities.HasLeftXThumbStick)
                return gpState.ThumbSticks.Left.X > 0.2f;
            else
                return false;
        }

        public static bool LeftStickUp()
        {
            if (gpCapabilities.HasLeftXThumbStick)
                return gpState.ThumbSticks.Left.Y > 0.2f;
            else
                return false;
        }

        public static bool LeftStickDown()
        {
            if (gpCapabilities.HasLeftXThumbStick)
                return gpState.ThumbSticks.Left.Y < -0.2f;
            else
                return false;
        }
        #endregion
    }
}
