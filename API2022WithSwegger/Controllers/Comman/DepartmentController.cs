using API2022WithSwegger.Models;
using API2022WithSwegger.Models.Comman;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace API2022WithSwegger.Controllers.Comman
{
    [Area("Comman")]
    public class DepartmentController : CustomApiBase
    {
        private static List<Department> Departments = new List<Department>()
        {
            new Department() { Id = 1,Code="ACC",Name="Account Department"},
            new Department() { Id = 2,Code="RES",Name="Resarch Department"},
            new Department() { Id = 3,Code="SAL",Name="Sales Department"},
            new Department() { Id = 4,Code="STO",Name="Store Department"}
        };

        public DepartmentController()
        {
        }

        [HttpGet]
        [ActionName("GetDepartmentById")]
        public ResultReponse GetDepartmentById(int id)
        {
            ResultReponse resultReponse;
            Department? department;
            if (Departments != null)
            {
                department = Departments.FirstOrDefault(col => col.Id == id);
                if (department != null)
                {
                    resultReponse = ResponseSend(true, department);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
            }
            return resultReponse;
        }

        [HttpGet]
        [ActionName("GetAllDepartments")]
        public ResultReponse GetAllDepartments()
        {
            return ResponseSend(true, Departments); ;
        }

        [HttpPost]
        [ActionName("AddDepartment")]
        public ResultReponse AddDepartment(Department department)
        {
            Departments.Add(department);
            return ResponseSend(true, department);
        }

        [HttpPost]
        [ActionName("UpdateDepartment")]
        public ResultReponse UpdateUser(Department department)
        {
            ResultReponse? resultReponse;
            if (Departments != null)
            {
                Department? dbDepartment = Departments.FirstOrDefault(col => col.Id == department.Id);
                if (dbDepartment != null)
                {
                    dbDepartment.Code = department.Code;
                    dbDepartment.Name = department.Name;
                    resultReponse = ResponseSend(true, department);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"Department with id {department.Id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"Department with id {department.Id} does not exists.");
            }
            return resultReponse;
        }

        [HttpPost]
        [ActionName("DeleteDepartment")]
        public ResultReponse DeleteDepartment(int id)
        {
            ResultReponse? resultReponse;
            Department? department;
            if (Departments != null)
            {
                department = Departments.FirstOrDefault(col => col.Id == id);
                if (department != null)
                {
                    Departments.Remove(department);
                    resultReponse = ResponseSend(true, department);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
            }
            return resultReponse;
        }
    }
}
