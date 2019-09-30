using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanningE
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .ToList();           

            while (true)
            {
                string[] command = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string commandOne = command[0];

                if (commandOne == "course start")
                {
                    break;
                }

                if (commandOne == "Add")
                {
                    string lessonTitle = command[1];

                    if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                    }
                }

                else if (commandOne == "Insert")
                {
                    string lessonTitle = command[1];
                    int indexToInsert = int.Parse(command[2]);

                    if (!schedule.Contains(lessonTitle))
                    {
                        if (indexToInsert >= 0 && indexToInsert < schedule.Count)
                        {
                            schedule.Insert(indexToInsert, lessonTitle);
                        }
                    }
                }

                else if (commandOne == "Remove")
                {
                    string lessonTitle = command[1];

                    if (schedule.Contains(lessonTitle))
                    {
                        int index = schedule.IndexOf(lessonTitle);

                        if ((index + 1 < schedule.Count) && (schedule[index + 1] == $"{lessonTitle}-Exercise"))
                        {
                            schedule.RemoveRange(index, 2);

                        }
                        else
                        {
                            schedule.Remove(lessonTitle);
                        }
                    }
                }

                else if (commandOne == "Swap") 
                {
                    string firstLesson = command[1]; 
                    string secondLesson = command[2]; 

                    int firstLessonIndex = schedule.IndexOf(firstLesson); 
                    int secondLessonIndex = schedule.IndexOf(secondLesson);

                    if (firstLessonIndex != -1 && secondLessonIndex != -1)
                    {
                        schedule[firstLessonIndex] = secondLesson;
                        schedule[secondLessonIndex] = firstLesson;
                    }

                    if ((firstLessonIndex + 1 < schedule.Count) && (schedule[firstLessonIndex + 1] == $"{firstLesson}-Exercise"))
                    {
                        schedule.RemoveAt(firstLessonIndex + 1);
                        schedule.Insert(secondLessonIndex + 1, $"{firstLesson}-Exercise");
                    }

                    if ((secondLessonIndex + 1 < schedule.Count) && (schedule[secondLessonIndex + 1] == $"{secondLesson}-Exercise"))
                    {
                        schedule.RemoveAt(secondLessonIndex + 1);
                        schedule.Insert(firstLessonIndex + 1, $"{secondLesson}-Exercise");
                    }
                }

                else if (commandOne == "Exercise")
                {
                    string lessonTitle = command[1];
                    int indexLesson = schedule.IndexOf(lessonTitle);

                    if ((schedule.Contains(lessonTitle)) && (!schedule.Contains($"{lessonTitle}-Exercise")))
                    {
                        schedule.Insert(indexLesson + 1, $"{lessonTitle}-Exercise");
                    }

                    else if (!schedule.Contains(lessonTitle))
                    {
                        schedule.Add(lessonTitle);
                        schedule.Add($"{lessonTitle}-Exercise");
                    }
                }
            }

            for (int i = 0; i < schedule.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{schedule[i]}");
            }
        }
    }
}
