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
        static KeyboardState kbState;
        static KeyboardState kbLastState;

        static GamePadState[] gpStates;
        static GamePadState[] gpLastStates;

        public static KeyboardState KBState
        {
            get { return kbState; }
        }

        public static KeyboardState KBLastState
        {
            get { return kbLastState; }
        }

        public static GamePadState[] GPStates
        {
            get { return gpStates; }
        }

        public static GamePadState[] GPLastStates
        {
            get { return gpLastStates; }
        }

        public InputHandler(Game game) : base(game)
        {
            kbState = Keyboard.GetState();

            gpStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                gpStates[(int)index] = GamePad.GetState(index);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            kbLastState = kbState;
            kbState = Keyboard.GetState();

            gpLastStates = (GamePadState[])gpStates.Clone();
            foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
            {
                gpStates[(int)index] = GamePad.GetState(index);
            }

            base.Update(gameTime);
        }
        public static bool KeyDown(Keys key)
        {
            return kbState.IsKeyDown(key);
        }

        public static bool KeyPressed(Keys key)
        {
            return kbState.IsKeyDown(key) && kbLastState.IsKeyUp(key);
        }

        public static bool KeyReleased(Keys key)
        {
            return kbState.IsKeyUp(key) && kbLastState.IsKeyDown(key);
        }

        public static bool ButtonDown(Buttons button, PlayerIndex player)
        {
            return gpStates[(int)player].IsButtonDown(button);
        }

        public static bool ButtonPressed(Buttons button, PlayerIndex player)
        {
            return gpStates[(int)player].IsButtonDown(button) &&
                   gpLastStates[(int)player].IsButtonUp(button);
        }

        public static bool ButtonReleased(Buttons button, PlayerIndex player)
        {
            return gpStates[(int)player].IsButtonUp(button) &&
                   gpLastStates[(int)player].IsButtonDown(button);
        }
    }
}
