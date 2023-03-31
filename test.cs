// create a dictionary to store information about swapped sections
Dictionary<uint, uint> swaps = new Dictionary<uint, uint>();

// swap the sections
for (int i = 0; i < numSections/2; i++) {
    Section lowScoreSection = sections[i];
    Section highScoreSection = sections[(int)numSections - i - 1];

    if (lowScoreSection.id != highScoreSection.id) {
        if (lowScoreSection.score < highScoreSection.score) {
            Console.WriteLine("Sekce {0} se prohodila se sekcí {1}.", lowScoreSection.id, highScoreSection.id);

            // Swap the sections in the list
            sections[i] = highScoreSection;
            sections[(int)numSections - i - 1] = lowScoreSection;

            // Store information about the swapped sections in the dictionary
            swaps[lowScoreSection.id] = highScoreSection.id;
            swaps[highScoreSection.id] = lowScoreSection.id;
        }
    } else {
        Console.WriteLine("Sekce {0} zůstala na své pozici.", lowScoreSection.id);
    }
}

// sort the sections by id
sections.Sort((s1, s2) => s1.id.CompareTo(s2.id));

// print the sorted sections with information about swapped sections
Console.WriteLine("Sections sorted by ID:");
foreach (Section section in sections) {
    uint swappedWithId;
    bool isSwapped = swaps.TryGetValue(section.id, out swappedWithId);
    if (isSwapped) {
        Console.WriteLine("Sekce {0} Score {1} (se prohodila se sekcí {2})", section.id, section.score, swappedWithId);
    } else {
        Console.WriteLine("Sekce {0} Score {1}", section.id, section.score);
    }
}
