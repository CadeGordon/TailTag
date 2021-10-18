﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    struct Icon
    {
        public char Symbol;
        public Color Color;
    }

    class Actor
    {
        private Icon _icon;
        private string _name;
        private Vector2 _position;
        private bool _started;

        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started
        {
            get { return _started; }
        }

        public Vector2 Postion
        {
            get { return _position; }
            set { _position = value; }
        }

        public Actor(char icon, float x, float y, Color color, string name = "Actor" ) :
            this(icon, new Vector2 { X = x, Y = y }, color, name)
        { 
        
        }

        public Icon Icon
        {
            get { return _icon; }
        }
        

        public Actor(char icon, Vector2 position,Color color, string name = "Actor" )

        {
            _icon = new Icon { Symbol = icon, Color = color };
            _position = position;
            _name = name;
        }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            Console.WriteLine(_name + ": " + Postion.X + ", " + Postion.Y);

        }

        public virtual void Draw()
        {
            Raylib.DrawText(Icon.Symbol.ToString(), (int)Postion.X, (int)Postion.Y, 50, Icon.Color);
        }

        public void End()
        {

        }

        public virtual void OnCollision(Actor actor)
        {

        }
    }
}
