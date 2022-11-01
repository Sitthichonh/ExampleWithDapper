using ExampleWithDapper.Interfaces;
using ExampleWithDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentAll()
        {
            try
            {
                var students = await _student.GetStudentAll();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetStudentById(int StudentId)
        {
            try
            {
                var student = await _student.GetStudentByIdAsync(StudentId);
                if (student is null)
                    return NotFound();

                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent(RequestStudentModel model)
        {
            try
            {
                await _student.InsertStudentByIdAsync(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateStudent(int StudentId, RequestStudentModel model)
        {
            try
            {
                var student = await _student.GetStudentByIdAsync(StudentId);
                if (student is null)
                    return NotFound();

                await _student.UpdateStudentByIdAsync(StudentId, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteStudent(int StudentId)
        {
            try
            {
                var student = await _student.GetStudentByIdAsync(StudentId);
                if (student is null)
                    return NotFound();

                await _student.DeleteStudentByIdAsync(student.StudentID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
