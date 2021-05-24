using System;
using System.Collections.Generic;
using System.Text;

namespace Class_03.Interfaces
{
    public interface ITeacher : IUser
    {
        List<string> Subjects { get; set; }
    }
}
