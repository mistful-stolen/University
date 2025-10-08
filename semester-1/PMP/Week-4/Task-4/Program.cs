// Lxxxxx

Random random = new Random();

string aplhabet = "abcdefghijklmnopqrstuvwxyz".ToUpper();
string numerals = "123456789";
string neptunCharacters = aplhabet + numerals;


string myNeptunCode = "ST2X0T";

int iteration = 0;



string neptunCode = "012345";

while (neptunCode != myNeptunCode) {
    neptunCode = "012345";
    neptunCode = neptunCode.Replace("0", aplhabet[random.Next(0, aplhabet.Length - 1)].ToString());
    neptunCode = neptunCode.Replace("1", neptunCharacters[random.Next(0, neptunCharacters.Length - 1)].ToString());
    neptunCode = neptunCode.Replace("2", neptunCharacters[random.Next(0, neptunCharacters.Length - 1)].ToString());
    neptunCode = neptunCode.Replace("3", neptunCharacters[random.Next(0, neptunCharacters.Length - 1)].ToString());
    neptunCode = neptunCode.Replace("4", neptunCharacters[random.Next(0, neptunCharacters.Length - 1)].ToString());
    neptunCode = neptunCode.Replace("5", neptunCharacters[random.Next(0, neptunCharacters.Length - 1)].ToString());
    
    iteration++;
}


Console.WriteLine(iteration);


