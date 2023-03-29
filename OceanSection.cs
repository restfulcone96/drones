using System;
using System.Collections.Generic;

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
        } else if (saltPercentage >= 2) {
            saltScore = 2 / saltPercentage;
        } else {
            saltScore = 0;
        }

        float temperatureScore = 0;
        if (temperature >= 30) {
            temperatureScore = 0;
        } else if (temperature > 26) {
            temperatureScore = 0.6f - 0.1f * (temperature - 26);
        } else if (temperature >= 22) {
            temperatureScore = 1;
        } else if (temperature >= 18) {
            temperatureScore = 0.5f * (temperature - 18) / 4;
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
        
        //sort in ascending order
        sections.Sort((s1, s2) => s1.score.CompareTo(s2.score));
        
for (int i = 0; i < numSections; i++) {
    Console.WriteLine("Section {0} Score {1}", sections[i].id, sections[i].score);
}
        // swap the sections
for (int i = 0; i < numSections; i++) {
     Section lowScoreSection = sections[i];
     Section highScoreSection = sections[(int)numSections - i - 1];

     if (lowScoreSection.id != highScoreSection.id) {
         if (lowScoreSection.score < highScoreSection.score) {
             Console.WriteLine("Sekce {0} se prohodila se sekcí {1}.", lowScoreSection.id, highScoreSection.id);

             // Swap the sections in the list
            sections[i] = highScoreSection;
             sections[(int)numSections - i - 1] = lowScoreSection;
         }
     } else {
         Console.WriteLine("Sekce {0} zůstala na své pozici.", lowScoreSection.id, highScoreSection.id);
 }
}
}
}
