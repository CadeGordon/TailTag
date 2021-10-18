using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private Vector2 _velocity;
        private float _speed;
        public Player _player;

        

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Enemy(char icon, float x, float y, float speed, Player player, Color color, string name = "Actor")
            : base(icon, x, y, color, name)
        {
            _player = player;
            _speed = speed;
        }

        public override void Update(float deltaTime)
        {

            float xDirection = _player.Postion.X - Postion.X;
            float yDirection = _player.Postion.Y - Postion.Y;

            //Create a vector that stores the move input
            Vector2 moveDirection = new Vector2(xDirection, yDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Postion += Velocity;

            base.Update(deltaTime);

        }

        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Collisoin occured");
        }
    }
}
