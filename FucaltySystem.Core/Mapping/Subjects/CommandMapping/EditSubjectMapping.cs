﻿using FacultySystem.Core.Features.Subjects.Commands.Models;
using FacultySystem.Data.Enteties;

namespace FacultySystem.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        public void EditSubjectMapping()
        {
            CreateMap<EditSubjectCommand, Subject>();
        }
    }
}
