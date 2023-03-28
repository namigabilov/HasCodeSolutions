using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasCodeSolution.Models
{
    class User
    {
        public int Id;
        public string[] LikedIngr;
        public string[] DisLikeIngr;
        public string UserLikedIngrPoint ;
        public string UserDisLikedIngrPoint;

        public string GetLikedIngr()
        {
            string ing = "";
            for (int i = 1; i < LikedIngr.Length; i++)
            {
                ing += $" {LikedIngr[i]}";
            }
            return ing;
        }
        public string GetDisLikedIngr()
        {
            string ing = "";

            for (int i = 1; i < DisLikeIngr.Length; i++)
            {
                ing += $" {DisLikeIngr[i]}";
            }
            return ing;
        }
    }
}
