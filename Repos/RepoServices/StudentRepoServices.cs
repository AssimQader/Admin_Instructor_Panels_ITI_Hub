﻿using Admin_Panel_ITI.Data;
using Admin_Panel_ITI.Models;
using Admin_Panel_ITI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Drawing.Printing;

namespace Admin_Panel_ITI.Repos
{
    public class StudentRepoServices : IStudentRepository
    {
        private readonly IStudent_CourseRepository student_CourseRepository;
        private readonly IStudent_SubmissionRepository student_SubmissionRepository;
        private readonly IExam_Std_QuestionRepository exam_Std_QuestionRepository;

        public MainDBContext Context { get; set; }

        public StudentRepoServices(MainDBContext context, 
            IStudent_CourseRepository student_CourseRepository, 
            IStudent_SubmissionRepository student_SubmissionRepository, 
            IExam_Std_QuestionRepository exam_Std_QuestionRepository)
        {
            Context = context;
            this.student_CourseRepository = student_CourseRepository;
            this.student_SubmissionRepository = student_SubmissionRepository;
            this.exam_Std_QuestionRepository = exam_Std_QuestionRepository;
        }

        void IStudentRepository.CreateStudent(Student student)
        {
            Context.Students.Add(student);
        }

        void IStudentRepository.DeleteStudent(string studentID)
        {
            student_CourseRepository.DeleteStudent_Course(studentID);
            student_SubmissionRepository.DeleteStudent_Submission(studentID);
            exam_Std_QuestionRepository.DeleteExam_Std_Question(studentID);

            var student = Context.Students.FirstOrDefault(s => s.AspNetUserID == studentID.ToString());
            Context.Students.Remove(student);
            Context.SaveChanges();
        }

        Student IStudentRepository.getStudentbyID(string studentID)
        {
            var student = Context.Students
                                 .Include(s=>s.Intake)
                                 .Include(s=>s.Track)
                                 .Include(s=>s.Admin)
                                 .FirstOrDefault(s => s.AspNetUserID == studentID);
            return student;
        }

        int IStudentRepository.getStudentNumber()
        {
            return Context.Students.Count();
        }   
        
        int IStudentRepository.getStudentNumberbyIntakeID(int intakeID)
        {
            return Context.Students.Where(s=>s.IntakeID== intakeID).Count();
        }

        int IStudentRepository.getStudentNumberbyTrackID(int trackID)
        {
            return Context.Students.Where(s => s.TrackID == trackID).Count();
        }

        List<Student> IStudentRepository.getStudents(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            return Context.Students.Include(s=>s.Admin)
                                   .Include(s=>s.Intake)
                                   .Include(s=>s.Track)
                                   .Include(s=>s.StudentCourses)
                                   .Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();
        }


        List<Student> IStudentRepository.getStudentsbyTrackID(int trackid, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            var students = Context.Students.Include(s => s.Admin)
                                   .Include(s => s.Intake)
                                   .Include(s => s.Track)
                                   .Include(s => s.StudentCourses)
                                   .Where(s=>s.TrackID== trackid)
                                   .Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToList();
            return students;
        }         
        
        List<Student> IStudentRepository.getStudentsbyTrackID(int trackID)
        {
            var students = Context.Students
                                   .Where(s=>s.TrackID== trackID)
                                
                                   .ToList();
            return students;
        }        
        
         List<Student> IStudentRepository.getStudentsbyIntakeID(int intakeID, int pageNumber, int pageSize)
         {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            return Context.Students.Include(s => s.Admin)
                                  .Include(s => s.Intake)
                                  .Include(s => s.Track)
                                  .Include(s => s.StudentCourses)
                                  .Where(s => s.IntakeID == intakeID)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();
        }  
        
        List<Student> IStudentRepository.getStudentsbyIntakeID(int intakeID)
         {
            return Context.Students
                                  .Where(s => s.IntakeID == intakeID)
                                 
                                  .ToList();
        }

        void IStudentRepository.UpdateStudent(string studentID, Student student)
        {
            var studentUpdated = Context.Students.FirstOrDefault(s=> s.AspNetUserID == studentID.ToString());

            studentUpdated.IsGraduated = student.IsGraduated;
            studentUpdated.AspNetUser.FullName = student.AspNetUser.FullName;
            studentUpdated.AspNetUser.UserName = student.AspNetUser.UserName;
            studentUpdated.AdminID = student.AdminID;
            studentUpdated.IntakeID = student.IntakeID;
            studentUpdated.TrackID = student.TrackID;

            Context.SaveChanges();

        }
    }
}
