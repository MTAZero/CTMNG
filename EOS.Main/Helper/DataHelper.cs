using EXON.Model.Models;
using System;
using System.Collections.Generic;

namespace EXON.Main.Helper
{
    public class DataHelper
    {
        public static string GetCharacterAnswer(int i)
        {
            return ((char)(65 + i)).ToString();
        }

        public static List<List<QUESTION>> GetRandomByNumber(List<List<QUESTION>> list, int num)
        {
            if (list.Count < num)
                throw new Exception("Not Enough Question!");

            List<List<QUESTION>> listRandomQuestion = new List<List<QUESTION>>();

            List<ObjectForRandom> listRandom = new List<ObjectForRandom>();
            for (int q = 0; q < list.Count; q++)
            {
                ObjectForRandom qr = new ObjectForRandom()
                {
                    ObjectID = q,
                    IsGeted = false
                };
                listRandom.Add(qr);
            }

            int numQuestionRandom = 0;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            while (numQuestionRandom < num)
            {
                int id = 0;
                do
                {
                    id = rd.Next(0, listRandom.Count);
                } while (listRandom[id].IsGeted);

                listRandom[id].IsGeted = true;
                numQuestionRandom++;
                listRandomQuestion.Add(list[listRandom[id].ObjectID]);
            }
            return listRandomQuestion;
        }
    }

    public class ObjectForRandom
    {
        public int ObjectID { get; set; }
        public bool IsGeted { get; set; }
    }

    public class SubQuestion
    {
        public int SubQuestionID { get; set; }
        public List<int> ListAnswerID { get; set; }

        public SubQuestion()
        {
        }
    }

    public class QuestionOfType
    {
        public int QuestionTypeID;
        public int NumOfQuestion = 0;
        public int NumOfSubQestion = 0;
        public int NumOfQestionGet = 0;
    }
}