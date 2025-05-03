using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyOffice.Models
{
    public class EmpInfo
    {
        internal int empId;

        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? EmpDepartment { get; set; }
        public string? EmpDesignation { get; set; }
        public DateTime? EmpJoiningDate { get; set; }
        public DateTime? EmpDoB {  get; set; }
        public string? EmpGender { get; set; }
        public string? EmpBloodGroup { get; set; }
        public string? EmpPhone { get; set; }
        public string? EmpEmail { get; set; }
        public string? EmpAddress { get; set; }
        public byte[]? EmpImage { get; set; }
    };
}
