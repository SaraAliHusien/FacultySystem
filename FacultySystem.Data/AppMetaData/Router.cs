namespace FacultySystem.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "/Api/V1/";
        public static class StudentRouring
        {
            public const string Prefix = root + "student/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id:int}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id:int}";

            public const string PaginatedList = Prefix + "PaginatedList";

        }
        public static class DepartmentRouring
        {
            public const string Prefix = root + "Department/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id:int}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id:int}";

            //public const string PaginatedList = Prefix + "PaginatedList";

        }
        public static class InstructorRouring
        {
            public const string Prefix = root + "Instructor/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id:int}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id:int}";

            //public const string PaginatedList = Prefix + "PaginatedList";

        }
        public static class SubjectRouring
        {
            public const string Prefix = root + "Subject/";
            public const string List = Prefix + "List";
            public const string GetById = Prefix + "{id:int}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id:int}";

            //public const string PaginatedList = Prefix + "PaginatedList";

        }

    }
}
