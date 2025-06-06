﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using College_Managment_Model;

namespace College_Managment_DataAccess.Interface
{
    public interface ISubjectMasterRepository
    {
        DataTable GetAllSubjectList();

        List<SubjectMasterDataModel> GetSubjectIDWise(int SubjectID);

        bool SaveData(SubjectMasterDataModel request);

        bool DeleteData(int SubjectID);
    }
}
