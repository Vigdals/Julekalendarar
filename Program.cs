using System.Net.WebSockets;
using System.Text;
using Julekalendarar;
using Julekalendarar.Knowit;
using Julekalendarar.Kode24;

// get base directory of the project
var baseDir = AppContext.BaseDirectory;
var projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;


// --- Advent of Code ---
var AdventOfCodeFilePath = Path.Combine(projectDir, "input\\input.txt");
var lines = File.ReadAllLines(AdventOfCodeFilePath);

//int answer = Day1.Solve(lines, debug: true);
//Console.WriteLine($"Answer for Day 1: {answer}");

// var answer = Day1.SolvePartTwo(lines, debug: true);
// Console.WriteLine($"Answer for Day 2: {answer}");

// --- Knowit ---
var inputKnowItFile = Path.Combine(projectDir, "input\\knowit\\knowit_Dag1_input.txt");
var solver = new KnowitSolver(inputKnowItFile);
string key = solver.SolveDay1();

//Console.WriteLine("Knowit Dag 1 – nøkkel:");
Console.WriteLine(key);


// kode24
await NisseSocketClient.RunAsync();