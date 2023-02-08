using Godot;

public partial class ShakeableCamera3D : Camera3D
{
    private float _shake;
    private float _shakeReductionRate = 1.0f;
    private float _maxX = 10f;
    private float _maxY = 10f;
    private float _maxZ = 5f;
    private Vector3 _initialRotation;
    private FastNoiseLite _noise = new();
    private float _noiseSpeed = 50f;
    private float _time;

    public override void _Ready()
    {
        _initialRotation = RotationDegrees;
        _noise.NoiseType = FastNoiseLite.NoiseTypeEnum.Perlin;
    }

    public override void _PhysicsProcess(double delta)
    {
        _time += (float) delta;
        _shake = (float) Mathf.Max(_shake - delta * _shakeReductionRate, 0.0);
        float rotationX = _initialRotation.X + _maxX * GetShakeIntensity() * GetNoiseSeed(0);
        float rotationY = _initialRotation.Y + _maxY * GetShakeIntensity() * GetNoiseSeed(1);
        float rotationZ = _initialRotation.Z + _maxZ * GetShakeIntensity() * GetNoiseSeed(2);
        RotationDegrees = new Vector3(rotationX, rotationY, rotationZ);
    }

    private void AddScreenShake(float shakeAmount)
    {
        _shake = (float) Mathf.Clamp(_shake + shakeAmount, 0.0, 1.0f);
    }

    // We are using an square function for intensity, can be adjusted for shake type
    private float GetShakeIntensity()
    {
        return _shake * _shake;
    }

    private float GetNoiseSeed(int seed)
    {
        _noise.Seed = seed;
        return _noise.GetNoise1D(_time * _noiseSpeed);
    }
}