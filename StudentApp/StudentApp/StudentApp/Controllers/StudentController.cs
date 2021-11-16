using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        List<StudentModel> st = new List<StudentModel>()
        {

            new StudentModel() { Id=1,Name="rk",Roll=10},
            new StudentModel() { Id=2,Name="fd",Roll=11},
            new StudentModel() { Id=3,Name="kl",Roll=12},
            new StudentModel() { Id=4,Name="dr",Roll=13}

        };

        List<StudMarksModel> stM = new List<StudMarksModel>()
        {

            new StudMarksModel() {   Studid=1,M1=50,M2=56,M3=67},
            new StudMarksModel() {   Studid=2,M1=54,M2=98,M3=66},
            new StudMarksModel() {   Studid=3,M1=55,M2=57,M3=60},
            new StudMarksModel() {   Studid=4,M1=57,M2=87,M3=62}

        };

        [HttpGet("")]
        public IActionResult Gets()
        {
            if (st.Count == 0)
            {
                return NotFound("not found");
            }
            return Ok(st);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {

            var stud = st.SingleOrDefault(x => x.Id == id);
            if (stud == null)
            {
                return NotFound("not found");
            }
            else
            {
                return Ok(stud);
            }

        }

        [HttpPut("")]
        public IActionResult AddStudent(StudentModel student)
        {
            st.Add(student);
            if (st.Count == 0)
            {
                return NotFound("not found");
            }
            else
            {
                return Ok(st);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var stud = st.SingleOrDefault(x => x.Id == id);
            st.Remove(stud);
            if (st.Count == 0)
            {
                return NotFound("not found");
            }
            else
            {
                return Ok(st);
            }

        }

        [HttpGet("{id}/marks")]
        public IActionResult GetStudMarks(int id)
        {

            var stud = st.SingleOrDefault(x => x.Id == id);
            if (stud == null)
            {
                return NotFound("not found");
            }
            else
            {
                var studM = stM.SingleOrDefault(x => x.Studid == id);
                return Ok(studM);
            }

        }




    }
}
