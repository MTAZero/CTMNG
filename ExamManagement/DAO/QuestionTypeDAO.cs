using ExamManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DAO
{
    public static class QuestionTypeDAO
    {
        public static List<QuestionTypeDTO> DanhSach()
        {
            List<QuestionTypeDTO> ans = new List<QuestionTypeDTO>();
            string query = "SELECT * FROM QUESTION_TYPES WHERE STATUS = 1";
            DataTable db = DAO.SqlServerHelper.ExecuteQuery(query);

            foreach (DataRow row in db.Rows)
            {
                QuestionTypeDTO loaicauhoi = new QuestionTypeDTO(row);
                ans.Add(loaicauhoi);
            }

            return ans;
        }

        public static List<QuestionTypeDTO> DanhSach(string timkiem)
        {
            List<QuestionTypeDTO> ans = new List<QuestionTypeDTO>();
            string query = "SELECT * FROM QUESTION_TYPES WHERE STATUS = 1 AND QuestionTypeName like '%'+ @TimKiem +'%'";
            DataTable db = DAO.SqlServerHelper.ExecuteQuery(query, new object[] { timkiem });

            foreach (DataRow row in db.Rows)
            {
                QuestionTypeDTO loaicauhoi = new QuestionTypeDTO(row);
                ans.Add(loaicauhoi);
            }

            return ans;
        }

        public static void Sua(QuestionTypeDTO cauhoi)
        {
            string query = "UPDATE QUESTION_TYPES " +
                           "SET QuestionTypeName = @QuestionTypeName , Description = @Description , IsQuiz = @IsQuiz , IsSingleChoice = @IsSingleChoice , IsParagraph = @IsParagraph , IsQuestionContent = @IsQuestionContent , NumberSubQuestion = @NumberSubQuestion , NumberAnswer = @NumberAnswer , Status = @Status " +
                           "WHERE QuestionTypeID = @QuestionTypeID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { cauhoi.QuestionTypeName, cauhoi.Description, cauhoi.IsQuiz, cauhoi.IsSingleChoice, cauhoi.IsParagraph, cauhoi.IsQuestionContent, cauhoi.NumberSubQuestion, cauhoi.NumberAnswer, cauhoi.Status, cauhoi.QuestionTypeID });
        }

        public static void Xoa(QuestionTypeDTO cauhoi)
        {
            string query = "UPDATE QUESTION_TYPES " +
                           "SET STATUS = 0 WHERE QUESTIONTYPEID = @QuestionTypeID";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { cauhoi.QuestionTypeID });
        }

        public static void Them(QuestionTypeDTO cauhoi)
        {
            string query = "INSERT INTO QUESTION_TYPES(QuestionTypeName, Description, IsQuiz, IsSingleChoice, IsParagraph , IsQuestionContent, NumberSubQuestion, NumberAnswer, Status ) "+
                           "VALUES( @QuestionTypeName , @Description , @IsQuiz , @IsSingleChoice , @IsParagraph , @IsQuestionContent , @NumberSubQuestion , @NumberAnswer , @Status )";
            DAO.SqlServerHelper.ExecuteNonQuery(query, new object[] { cauhoi.QuestionTypeName, cauhoi.Description, cauhoi.IsQuiz, cauhoi.IsSingleChoice, cauhoi.IsParagraph, cauhoi.IsQuestionContent, cauhoi.NumberSubQuestion, cauhoi.NumberAnswer, cauhoi.Status });
        }
    }
}
