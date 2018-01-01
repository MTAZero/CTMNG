using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Services.Interface
{
    public partial interface IGeneralService
    {
        bool CheckLogin(string user, string pass, out int per);

        #region Cán bộ

        #endregion


        #region Môn thi


        #endregion

        #region Phân công câu hỏi

        #endregion
    }
}
