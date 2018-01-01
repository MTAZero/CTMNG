using EXON.Data.Infrastructures;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EXON.GenerateTest.Core.Helper
{
    public class DataHelper
    {
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

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}