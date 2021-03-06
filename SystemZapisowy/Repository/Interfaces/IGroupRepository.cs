﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZapisowy.Models;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IGroupRepository: IRepository<Group>
    {
        IEnumerable<Group> GetGroupsOfACourse(int courseId);
        IEnumerable<Group> GetGroupsOfAFieldOfStudy(int fieldOfStudyId);
        IEnumerable<Group> GetGroupsOfAFieldOfStudy(int fieldOfStudyId, int semesterId);
    }
}
