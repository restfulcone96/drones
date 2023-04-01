using System;
using System.Collections.Generic;
using System.Linq;

class Section
{
    public uint id;
    public float saltPercentage;
    public float temperature;
    public float score;

    public Section(uint id, float saltPercentage, float temperature)
    {
        this.id = id;
        this.saltPercentage = saltPercentage;
        this.temperature = temperature;
        this.score = CalculateScore(saltPercentage, temperature);
    }

    private float CalculateScore(float saltPercentage, float temperature)
    {
        float saltScore = 0;
        if (saltPercentage >= 50) {
            saltScore = 0;
        } else if (saltPercentage > 10) {
            saltScore = 1 / (2 * saltPercentage);
        } else if (saltPercentage > 2 && saltPercentage < 10) {
            saltScore = 2 / saltPercentage;
        } else if (saltPercentage <= 2) {
            saltScore = 2 / saltPercentage;
        } else {
            saltScore = 0;
        }

        float temperatureScore = 0;
        if (temperature >= 30) {
            temperatureScore = 0;
        } else if (temperature > 26) {
            temperatureScore = 0.6f - 0.1f * (temperature - 26);
        } else if (temperature > 22 && temperature < 26) {
            temperatureScore = 1;
        } else if (temperature <= 22) {
            temperatureScore = 0.5f * (temperature - 18) / 4;
        } else if (temperature <= 18) {
            temperatureScore = 0;
        } else {
            temperatureScore = 0;
        }

        return saltScore + temperatureScore;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // read the number of sections
        uint numSections = uint.Parse(Console.ReadLine());

        // create a list of sections
        List<Section> sections = new List<Section>();
        for (uint i = 0; i < numSections; i++) {
            string[] sectionData = Console.ReadLine().Split(' ');
            uint id = uint.Parse(sectionData[0]);
            float saltPercentage = float.Parse(sectionData[1]);
            float temperature = float.Parse(sectionData[2]);
            sections.Add(new Section(id, saltPercentage, temperature));
        }
        
        // sort the sections in ascending order by score using OrderBy
        sections = sections.OrderBy(s => s.score).ToList();

        // create a dictionary to store information about swapped sections
        Dictionary<uint, uint> swaps = new Dictionary<uint, uint>();
        
        foreach (Section section in sections) {
            Console.WriteLine("Section {0} Score {1}", section.id, section.score);
        }

        // swap the sections
        for (int i = 0; i < numSections/2; i++) {
            Section lowScoreSection = sections[i];
            Section highScoreSection = sections[(int)numSections - i - 1];

            if (lowScoreSection.id != highScoreSection.id) {
                if (lowScoreSection.score < highScoreSection.score) {
                    // Swap the sections in the list
                    sections[i] = highScoreSection;
                    sections[(int)numSections - i - 1] = lowScoreSection;

                    // Store information about the swapped sections in the dictionary
                    swaps[lowScoreSection.id] = highScoreSection.id;
                    swaps[highScoreSection.id] = lowScoreSection.id;
                }
            } else {
                Console.WriteLine("Sekce {0} zůstala na své pozici.", lowScoreSection.id, highScoreSection.id);
            }
        }

        // sort the sections by id
        sections = sections.OrderBy(s => s.id).ToList();



// print the sorted sections with information about swapped sections
foreach (Section section in sections) {
    uint swappedWithId;
    bool isSwapped = swaps.TryGetValue(section.id, out swappedWithId);
    if (isSwapped) {
        Console.WriteLine("Sekce {0} se prohodila se sekcí {2}.", section.id, section.score, swappedWithId);
    } else {
        Console.WriteLine("Sekce {0} zůstala na své pozici.", section.id, section.score);
    }
}

}
}
