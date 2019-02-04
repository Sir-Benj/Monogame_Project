using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Onwards.Components;


namespace Onwards
{
    public class Camera
    {
        #region Fields

        protected Viewport viewport;
        protected Matrix transform;
        protected Matrix inverseTransform;
        protected Vector2 position;
        protected float zoom;
        protected float rotation;

        #endregion

        #region Properties

        public Matrix Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        public Matrix InverseTransform
        {
            get { return inverseTransform; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        #endregion

        #region Constructor

        public Camera(Viewport gameViewport)
        {
            viewport = gameViewport;
            position = Vector2.Zero;
            zoom = 1.0f;
            rotation = 0.0f;
        }

        #endregion

        #region Methods

        public void Update()
        {
            Input();
            transform = Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                        Matrix.CreateTranslation(position.X, position.Y, 0);
            inverseTransform = Matrix.Invert(transform);
        }

        protected virtual void Input()
        {
            if (InputHandler.KeyDown(Keys.A));
            {
                position.X += 5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X -= 5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y += 5f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y -= 5f;
            }
        }

        #endregion
    }
}
