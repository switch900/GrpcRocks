using Grpc.Core;
using GrpcServer.Data;
using GrpcServer.Protos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class StudentsService : RemoteStudent.RemoteStudentBase
    {
        private readonly ILogger<StudentsService> _logger;
        private readonly SchoolDbContext _context;
        public StudentsService(ILogger<StudentsService> logger, SchoolDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<StudentModel> GetStudentInfo(StudentLookupModel request, ServerCallContext context)
        {
            StudentModel output = new StudentModel();
            var student = _context.Students.Find(request.StudentId);
            _logger.LogInformation("Sending Student response");
            if (student != null)
            {
                output.StudentId = student.StudentId.ToString();
                output.FirstName = student.FirstName;
                output.LastName = student.LastName;
                output.School = student.School;
            }
            return Task.FromResult(output);
        }
    }
}
