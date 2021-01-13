using UnityEngine;

/* Noise generator that generates float[,] with values ranging from 0 to 1 using Perlin noise */
public static class Noise
{
    public static float[,] GenerateNoiseMap(int seed, float scale, int octaves, float persistance, float lacunarity, float bias = 0f)
    {
        int mapWidth = MapData.Instance.GetMapWidth();
        int mapHeight = MapData.Instance.GetMapHeight();

        float[,] noiseMap = new float[mapWidth, mapHeight];

        // Initiating System.Random module with given seed
        System.Random prng = new System.Random(seed);

        // Choosing random offset for each octave
        // Range (-100000, 100000) works the besst because beyond those PerlinNoise returns the same value
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000);
            float offsetY = prng.Next(-100000, 100000);

            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        // Ensuring that scale would not be 0 beacuse of Division by Zero Exception
        scale = (scale == 0) ? 0.0001f : scale;

        // Those are needed for noise map normalization
        float minNoiseHeight = float.MaxValue;
        float maxNoiseHeight = float.MinValue;

        // Main loop
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                // Amplitude defines "influence" of current noise value on a map height
                // Gets lower with every octave iteration and controlled by persistance
                float amplitude = 1;
                // Frequency defines "scale" of current octave
                // Gets higher with every octave iteration and controlled by lacunarity
                float frequency = 1;
                // Noise height defines how much add to, or substract from current map height
                // Will be ranged from -1 to 1 in order to substract from map when needed
                float noiseHeight = 0;

                // Looping through every octave 
                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency + octaveOffsets[i].x;
                    float sampleY = y / scale * frequency + octaveOffsets[i].y;

                    // Sampling from Perlin noise and scaling value to range from -1 to 1
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;

                    noiseHeight += perlinValue * amplitude;

                    // Modifying amplitude and frequency as described above
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                // Checking if current noise height is higher than maximum
                if (noiseHeight > maxNoiseHeight)
                    maxNoiseHeight = noiseHeight;
                // Or lower than minimum noise height
                else if (noiseHeight < minNoiseHeight)
                    minNoiseHeight = noiseHeight;

                // And assigning current noise height to current map coords
                noiseMap[x, y] = noiseHeight;
            }
        }

        // Normalizing noise map into range from 0 to 1
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]) + bias;
                // Clamp map in case of it exceeding values from 0 to 1 as result of biasing 
                noiseMap[x, y] = Mathf.Clamp01(noiseMap[x, y]);
            }
        }

        return noiseMap;
    }
}
