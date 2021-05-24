using System;
using System.Collections.Generic;
using System.Text;

namespace Class_03.Interfaces
{
    public interface IStudent : IUser
    {
       List<int> Grades { get; set; }

    }
}
