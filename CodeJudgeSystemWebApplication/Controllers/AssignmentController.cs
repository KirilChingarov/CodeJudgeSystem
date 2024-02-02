using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeJudgeSystemWebApplication.Models;
using CodeJudgeSystemWebApplication.AppModels;

namespace CodeJudgeSystemWebApplication.Controllers
{
    public class AssignmentController : ControllerBase
    {
      /*  private readonly YourDbContext _context;

        public AssignmentController(YourDbContext context)
        {
            _context = context;
        }
      */
        // Create
        public void AddAssignment(AssignmentModel assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
        }

        // Read
        public AssignmentModel GetAssignmentById(int assignmentId)
        {
            return _context.Assignments.Find(assignmentId);
        }

        public List<AssignmentModel> GetAllAssignments()
        {
            return _context.Assignments.ToList();
        }

        // Update
        public void UpdateAssignment(AssignmentModel updatedAssignment)
        {
            var existingAssignment = _context.Assignments.Find(updatedAssignment.Id);

            if (existingAssignment != null)
            {
                existingAssignment.Subject = updatedAssignment.Subject;
                existingAssignment.AssigmentName = updatedAssignment.AssignmentName;
                existingAssignment.DueDate = updatedAssignment.DueDate;
                existingAssignment.Course = updatedAssignment.Course;
                existingAssignment.Semester = updatedAssignment.Semester;
                existingAssignment.TargetGroup = updatedAssignment.TargetGroup;
                existingAssignment.Description = updatedAssignment.Description;

                _context.SaveChanges();
            }
        }

        // Delete
        public void DeleteAssignment(int assignmentId)
        {
            var assignmentToDelete = _context.Assignments.Find(assignmentId);

            if (assignmentToDelete != null)
            {
                _context.Assignments.Remove(assignmentToDelete);
                _context.SaveChanges();
            }
        }
    }
    private static AssignmentDTO AssignmentToDTO(AssignmentModel assignment) =>
        new AssignmentDTO
        {
            Subject = assignment.Subject,
            AssignmentName = assignment.AssignmentName,
            DueDate = assignment.DueDate,
            Course = assignment.Course,
            Semester = assignment.Semester,
            TargetGroup = assignment.TargetGroup,
            Description = assignment.Description,
        };
}
