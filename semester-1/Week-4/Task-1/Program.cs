Console.Write("Input: ");
string input = Console.ReadLine();

char[] charInput = input.ToCharArray();

// If this is the English alphabet only, then it would mean that we have only 5 vowels: a, e, i, o, u.


int numberOfDigits = 0;
int numberOfLetters = 0;

char[] englishAlphabetVowels = new char[5] {'a', 'e', 'o', 'u', 'i'};
int numberOfVowels = 0;
// We collect the numbers
for (int i = 0; i < charInput.Length; i++) {
    if (char.IsDigit(charInput[i]) == true) {
        numberOfDigits++;
    }

    if (char.IsLetter(charInput[i]) == true) {
        numberOfLetters++;
    }


}

// If the vowel matches any of the characters contained within englishAlphabetVowels, then ++
for (int i = 0; i < charInput.Length; i++) {
    for (int j = 0; j < englishAlphabetVowels.Length; j++) {
        if (englishAlphabetVowels[j] == charInput [i]) {
            numberOfVowels++;
        }
    }
}

Console.WriteLine($"Number of letters: {numberOfLetters}");
Console.WriteLine($"Number of digits: {numberOfDigits}");
Console.WriteLine($"Number of vowels: {numberOfVowels}");
