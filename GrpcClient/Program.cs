using System;
using System.Threading.Tasks;
using GrpcServer;
using Grpc.Net.Client;
using GrpcServer.Protos;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var studentClient = new RemoteStudent.RemoteStudentClient(channel);
            var studentInput = new StudentLookupModel { StudentId = 22 };
            var studentReply = await studentClient.GetStudentInfoAsync(studentInput);
            Console.WriteLine($"{studentReply.FirstName} {studentReply.LastName}");
            Console.ReadLine();
        }

    }
}
