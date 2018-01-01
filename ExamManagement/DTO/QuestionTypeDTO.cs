using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagement.DTO
{
    public class QuestionTypeDTO
    {
        public int QuestionTypeID { get; set; } // mã loại câu hỏi
        public string QuestionTypeName { get; set; } // tên loại câu hỏi
        public string Description { get; set; } // Mô tả loại câu hỏi
        public bool IsQuiz { get; set; } /// có là câu trắc nghiệm không
        public bool IsSingleChoice { get; set; } // đáp án có phải lựa chọn duy nhất không
        public bool IsParagraph { get; set; } /// Câu hỏi có đoạn văn không
        public bool IsQuestionContent { get; set; } // Có nội dung câu hỏi con không
        public int NumberSubQuestion { get; set; } // Số lượng câu hỏi con
        public int NumberAnswer { get; set; } // Số câu trả lời cho mỗi câu hỏi
        public int Status { get; set; } /// trạng thái của loại câu hỏi (0: là đã bị xóa)

        public QuestionTypeDTO()
        {

        }
        public QuestionTypeDTO(DataRow row)
        {
            QuestionTypeID = (int)row["QuestionTypeID"];
            QuestionTypeName = (string)row["QuestionTypeName"];
            try
            {
                Description = (string)row["Description"];
            }
            catch
            {
                Description = "";
            }

            IsQuiz = (bool)row["IsQuiz"];
            IsSingleChoice = (bool)row["IsSingleChoice"];
            IsParagraph = (bool)row["Isparagraph"];
            IsQuestionContent = (bool)row["IsQuestionContent"];
            NumberSubQuestion = (int)row["NumberSubQuestion"];
            NumberAnswer = (int)row["NumberAnswer"];
            Status = (int)row["Status"];
        }
    }
}
