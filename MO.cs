using Raylib_cs;
using System.Numerics;

namespace ks;

public class MovementObject : PhysicsObject {
    public required Vector2 Position;
    public Vector2 Velocity = Vector2.Zero;
    public required float Mass;
    public required int Radius;
    public Color ObjectColor = Color.Red;

    private List<Vector2> forces = [];

    public void AddForce(Vector2 force) {
        forces.Add(force);
    }

    public void AddForce(float x, float y) {
        forces.Add(new Vector2(x, y));
    }

    public void RemoveForce(Vector2 force){
        forces.Remove(force);
    }

    public void ClearForces(){
        forces.Clear();
    }

    public void Update(float deltaTime) {
        Vector2 aceleration = CalculateNetForce() / Mass;
        Velocity += aceleration * deltaTime;
        Position += Velocity * deltaTime;
    }

    public void Draw() {
        Raylib.DrawCircleV(Position, Radius, ObjectColor);
    }

    public Vector2 CalculateNetForce() {
        Vector2 sum = Vector2.Zero;
        foreach(Vector2 force in forces){
            sum += force;
        }
        return sum;
    }
}
