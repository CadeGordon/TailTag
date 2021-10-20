using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSeneIndex;
        private Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();
        


        /// <summary>
        /// Called to beging the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //loop until the application is told to close
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {
                //Get How much time has passed since the application started
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set delta time to be the difference in time from the last time recorded to the current time
                deltaTime = currentTime - lastTime;

                //Update the application
                Update(deltaTime);
                //Draw all items
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currentTime;
            }

            //Call end for entire application
            End();
        }


        /// <summary>
        /// Calls when the application starts
        /// </summary>
        private void Start()
        {
            _stopwatch.Start();

            //Create a window using raylib
            Raylib.InitWindow(800, 450, "Math For Games");
            Raylib.SetTargetFPS(0);


            Scene scene = new Scene();

            Player player = new Player('@', 4, 1, 100,Color.PURPLE, "Player");
            player.CollisionRadius = 20;
            Enemy enemy = new Enemy('Y', 300, 300, 100, 50, player, Color.BLUE, "Enemy");
            enemy.CollisionRadius = 20;
            
           
            UIText text = new UIText(10, 10, "TestBox", Color.LIME, 70, 70, 15, "This is the test text \n it is not to be taken seriously");

            scene.AddActor(player);
            scene.AddActor(enemy);
            

            _currentSeneIndex = AddScene(scene);

            _scenes[_currentSeneIndex].Start();

            Console.CursorVisible = false;
        }

        /// <summary>
        ///Called everytime the game loops 
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSeneIndex].Update(deltaTime);

            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.PINK);

            //Adds all actor icons to buffer
            _scenes[_currentSeneIndex].Draw();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Called when the application exits
        /// </summary>
        private void End()
        {
            _scenes[_currentSeneIndex].End();
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Adds a scene to the engines scene array
        /// </summary>
        /// <param name="scene">The scene that will be added to the scene array</param>
        /// <returns>The index that new scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Create a new temp array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //copy all values from the old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //set the last index to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //retunr the last index
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetNextKey()
        {   //If there is no key being pressed...
            if (!Console.KeyAvailable)
                //...return
                return 0;
            
            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }


        /// <summary>
        /// Ends the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true; 
        }
    }
}
