using Raylib_cs;
using System.Numerics;

namespace ks;

public class Program
{
    const int screenWidth = 1280;
    const int screenHeight = 720;

    LayerManager layerManager;

    public static void Main()
    {
        float currentTime = 0;
        int frameNumber = 0;
        MovementObject mo1 = new MovementObject()
        {
            Radius = 5,
            Position = new Vector2(screenWidth / 3, screenHeight / 2),
            Mass = 0.3f
        };
        MovementObject mo2 = new MovementObject()
        {
            Radius = 5,
            Position = new Vector2(screenWidth / 2, screenHeight / 3),
            Mass = 0.3f
        };
        MovementObject mo3 = new MovementObject()
        {
            Radius = 5,
            Position = new Vector2(screenWidth / 2, screenHeight / 2),
            Mass = 0.3f
        };

        mo1.AddForce(-10, 10);
        mo2.AddForce(10, -10);
        mo3.AddForce(10, 10);

        Raylib.InitWindow(screenWidth, screenHeight, "Playing around");
        Raylib.SetTargetFPS(200);

        while (!Raylib.WindowShouldClose())
        {
            frameNumber++;
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(255, 242, 164));

            float deltaTime = Raylib.GetFrameTime();
            currentTime += deltaTime;

            mo1.Update(deltaTime);
            mo2.Update(deltaTime);
            mo3.Update(deltaTime);

            if (currentTime >= 5) {
                mo1.ClearForces();
                mo2.ClearForces();
                mo3.ClearForces();
            }
            
            mo1.Draw();
            mo2.Draw();
            mo3.Draw();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}