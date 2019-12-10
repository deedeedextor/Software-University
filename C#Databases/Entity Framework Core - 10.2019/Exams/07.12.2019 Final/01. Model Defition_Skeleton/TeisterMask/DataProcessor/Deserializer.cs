namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using System.Text;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var projects = new List<Project>();

            var xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));

            var projectsDto = (ImportProjectDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var projectDto in projectsDto)
            {
                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = string.IsNullOrEmpty(projectDto.DueDate) ?
                        (DateTime?)null
                        : DateTime.ParseExact(
                        projectDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture)
                };

                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var taskDto in projectDto.Tasks)
                {
                    var isExecutionTypeValid = Enum.IsDefined(typeof(ExecutionType), taskDto.ExecutionType);

                    var isLabelTypeValid = Enum.IsDefined(typeof(LabelType), taskDto.LabelType);

                    if (!isExecutionTypeValid || !isLabelTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = DateTime.ParseExact(taskDto.OpenDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        DueDate = DateTime.ParseExact(taskDto.DueDate, @"dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ExecutionType = (ExecutionType)
                            Enum.ToObject(typeof(ExecutionType), taskDto.ExecutionType),
                        LabelType = (LabelType)
                            Enum.ToObject(typeof(LabelType), taskDto.LabelType),
                        Project = project
                    };

                    if (!IsValid(task) || task.OpenDate < project.OpenDate || task.DueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    project.Tasks.Add(task);
                }

                projects.Add(project);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }//13-25 - nullable DateTime.ParseExact

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var employees = new List<Employee>();

            var employeesDto = JsonConvert.DeserializeObject<ExportBusiestEmployeeDto[]>(jsonString);

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    if (context.Tasks.Find(taskId) == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask { TaskId = taskId };

                    employee.EmployeesTasks.Add(employeeTask);
                }

                employees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}