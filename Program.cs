using Raylib_cs;
using System.Numerics;

namespace ks;

public class Program
{
    const int screenWidth = 1280;
    const int screenHeight = 720;

    public static void Main()
    {
        LayerManager layerManager = new LayerManager(1);
        float currentTime = 0;
        int frameNumber = 0;
        MovementObject mo1 = new MovementObject(
            position: new Vector2(screenWidth / 2, screenHeight / 2),
            mass: 1,
            radius: 5,
            manager: layerManager,
            layer: 0
        );
        MovementObject mo2 = new MovementObject(
            position: new Vector2(screenWidth / 3, screenHeight / 3),
            mass: 1,
            radius: 5,
            manager: layerManager,
            layer: 0
        );

        mo1.AddForce(-10, 10);
        mo2.AddForce(10, -10);

        Raylib.InitWindow(screenWidth, screenHeight, "Playing around");
        Raylib.SetTargetFPS(120);

        while (!Raylib.WindowShouldClose())
        {
            frameNumber++;
            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(255, 242, 164));

            float deltaTime = Raylib.GetFrameTime();
            currentTime += deltaTime;

            layerManager.UpdateLayer(0, deltaTime);

            if (currentTime >= 5) {
                mo1.ClearForces();
                mo2.ClearForces();
            }
            
            layerManager.DrawLayer(0);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}