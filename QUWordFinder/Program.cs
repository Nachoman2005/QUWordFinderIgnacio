// See https://aka.ms/new-console-template for more information
using QUWordFinder.Models;

Console.WriteLine("Hello, World!");


var matrix = new List<string>
{
    "abcdc",
    "fgwio",
    "chill",
    "pqncd",
    "uvdxy"
};

var wordstream = new List<string> { "chill", "cold", "wind", "heat" };

var wordFinder = new WordFinder(matrix);
var result = wordFinder.Find(wordstream);

foreach (var word in result)
{
    Console.WriteLine(word);
}