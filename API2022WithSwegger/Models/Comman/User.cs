namespace API2022WithSwegger.Models.Comman
{
    public class User: ModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string Address { get; set; }
        public List<int> DepartmentIds { get; set; }
    }
}
