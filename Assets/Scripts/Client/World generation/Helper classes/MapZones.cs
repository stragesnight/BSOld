using System;
using System.Linq;

/*
    IMPORTANT NOTE: integer value assigned to enum member means maximum appearance level on the map 
    # value should be divided by 100f to represent proper levels #

    For example: 
        'mountain = 75' means that mountains will appear on a map when height map value is BELOW 0.75f on a given x, y coords;
        'desert = 0' means that desert biome will appear on a map when temperature map value is BELOW 0f on a given x, y coords;
*/

// Elevation Zones defines height of a specific map region.
// Some of them are walkable, others are not
public enum ElevationZone
{
    water = 20,
    land = 80,
    mountain = 100
}

// Temperature Biome defines temperature of a specific map region
// Temperature will affect different parameters such as vegetation that can be grown here
public enum TemperatureBiome
{
    desert = 19,
    moderate = 80,
    snow = 100
}

// Fertility zone defines ability for vegetation to grow in a specific map region
// Higher the number, higher the ability for plant to grow
public enum FertilityZone
{
    low = 10,
    sparce = 75,
    high = 100
}


// Map Zones class is responsible of giving data about map parameters
public static class MapZones
{
    // Returns array of certain Map Zone Enum
    public static T[] GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>().ToArray();
}
