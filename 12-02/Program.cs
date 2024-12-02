// See https://aka.ms/new-console-template for more information
Part1();
Part2();
void Part1()
{
    var lines = File.ReadAllLines("input.txt");
    
    var countOfSafe = 0;
    foreach (var line in lines)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToArray();
        if (IsSafe(numbers))
        {
            countOfSafe++;
        }
    }
    
    Console.WriteLine(countOfSafe);
}

void Part2()
{
    var lines = File.ReadAllLines("input.txt");
    
    var countOfSafe = 0;
    foreach (var line in lines)
    {
        var numbers = line.Split(" ").Select(int.Parse).ToArray();
        for (var i = 0; i < numbers.Length; i++)
        {
            var modified = numbers.Where((_, index) => index != i).ToArray();
            if (IsSafe(modified))
            {
                countOfSafe++;
                break;
            }
        }
    }
    
    Console.WriteLine(countOfSafe);
}

bool IsSafe(int[] numbers)
{
    var order = numbers[0] > numbers[1];
    for (var i = 1; i < numbers.Length; i++)
    {
        if (numbers[i - 1] > numbers[i] != order
            || numbers[i - 1] == numbers[i]
            || Math.Abs(numbers[i - 1] - numbers[i]) > 3)
        {
            return false;
        }
    }

    return true;
}