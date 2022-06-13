
int[] answers = new int[5];

for (int i = 0; i < answers.Length; i++)
{
    Console.Write("Write a number to store: ");
    int answer = Convert.ToInt32(Console.ReadLine());
    answers[i] = answer;
}

int[] answersCopy = new int[5];

for (int i = 0; i < answers.Length; i++)
{
    answersCopy[i] = answers[i];
}

for (int i = 0; i < answers.Length; i++)
{
    Console.WriteLine($"{i} Answer: {answers[i]}");
    Console.WriteLine($"{i} Copy: {answersCopy[i]}");
}
